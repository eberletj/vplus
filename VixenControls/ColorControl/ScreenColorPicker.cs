﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace CommonControls {
    // Cyotek Color Picker controls library
    // Copyright © 2013 Cyotek. All Rights Reserved.
    // http://cyotek.com/blog/tag/colorpicker

    // If you use this code in your applications, donations or attribution are welcome

    /// <summary>
    /// Represents a control that allows the selection of a color by dragging the mouse across the desktop
    /// </summary>
    [DefaultProperty("Color")]
    [DefaultEvent("ColorChanged")]
    public class ScreenColorPicker : Control, IColorEditor {
        #region Instance Fields

        private Color _color;

        private Cursor _eyedropperCursor;

        private Color _gridColor;

        private Image _image;

        private bool _showGrid;

        private bool _showTextWithSnapshot;

        private int _zoom;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ScreenColorPicker"/> class.
        /// </summary>
        public ScreenColorPicker() {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.Selectable | ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, false);
            UpdateStyles();
            Zoom = 8;
            Color = Color.Empty;
            ShowTextWithSnapshot = false;
            TabStop = false;
            TabIndex = 0;
            ShowGrid = true;
            GridColor = SystemColors.ControlDark;
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when the Color property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler ColorChanged;

        /// <summary>
        /// Occurs when the GridColor property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler GridColorChanged;

        /// <summary>
        /// Occurs when the Image property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler ImageChanged;

        /// <summary>
        /// Occurs when the ShowGrid property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler ShowGridChanged;

        /// <summary>
        /// Occurs when the ShowTextWithSnapshot property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler ShowTextWithSnapshotChanged;

        /// <summary>
        /// Occurs when the Zoom property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler ZoomChanged;

        #endregion

        #region Overridden Members

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.Control" /> and its child controls and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (_eyedropperCursor != null)
                    _eyedropperCursor.Dispose();

                if (SnapshotImage != null)
                    SnapshotImage.Dispose();
            }

            base.Dispose(disposing);
        }


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.FontChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnFontChanged(EventArgs e) {
            base.OnFontChanged(e);

            Invalidate();
        }


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.ForeColorChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnForeColorChanged(EventArgs e) {
            base.OnForeColorChanged(e);

            Invalidate();
        }


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e) {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left && !IsCapturing) {
                if (_eyedropperCursor == null)
                    // ReSharper disable AssignNullToNotNullAttribute
                    _eyedropperCursor =
                        new Cursor(
                            GetType().Assembly.GetManifestResourceStream(string.Concat(GetType().Namespace, ".Resources.eyedropper.cur")));
                // ReSharper restore AssignNullToNotNullAttribute

                Cursor = _eyedropperCursor;
                IsCapturing = true;
                Invalidate();
            }
        }


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e) {
            base.OnMouseMove(e);

            if (IsCapturing)
                UpdateSnapshot();
        }


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e) {
            base.OnMouseUp(e);

            if (IsCapturing) {
                Cursor = Cursors.Default;
                IsCapturing = false;
                Invalidate();
            }
        }


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            base.OnPaintBackground(e); // HACK: Easiest way of supporting things like BackgroundImage, BackgroundImageLayout etc

            // draw the current snapshot, if present
            if (SnapshotImage != null) {
                e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                e.Graphics.DrawImage(SnapshotImage,
                    new Rectangle(0, 0, SnapshotImage.Width * Zoom, SnapshotImage.Height * Zoom),
                    new Rectangle(Point.Empty, SnapshotImage.Size), GraphicsUnit.Pixel);
            }

            PaintAdornments(e);
        }


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e) {
            base.OnResize(e);

            CreateSnapshotImage();
        }


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.TextChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnTextChanged(EventArgs e) {
            base.OnTextChanged(e);

            Invalidate();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the component color.
        /// </summary>
        /// <value>The component color.</value>
        [Category("Behavior")]
        [DefaultValue(typeof (Color), "Empty")]
        public virtual Color Color {
            get { return _color; }
            set {
                if (Color != value) {
                    _color = value;

                    OnColorChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the grid.
        /// </summary>
        /// <value>The color of the grid.</value>
        [Category("Appearance")]
        [DefaultValue(typeof (Color), "ControlDark")]
        public virtual Color GridColor {
            get { return _gridColor; }
            set {
                if (GridColor != value) {
                    _gridColor = value;

                    OnGridColorChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Returns if a snapshot image is available
        /// </summary>
        /// <value><c>true</c> if a snapshot image is available; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public bool HasSnapshot { get; protected set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        [Category("Appearance")]
        [DefaultValue(typeof (Image), null)]
        public virtual Image Image {
            get { return _image; }
            set {
                if (Image != value) {
                    _image = value;

                    OnImageChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether a pixel grid is displayed.
        /// </summary>
        /// <value><c>true</c> if a pixel grid is displayed; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [DefaultValue(true)]
        public virtual bool ShowGrid {
            get { return _showGrid; }
            set {
                if (ShowGrid != value) {
                    _showGrid = value;

                    OnShowGridChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether text should be shown when a snapshot is present.
        /// </summary>
        /// <value><c>true</c> if text is to be shown when a snapshot is present; otherwise, <c>false</c> to only show text when no snapshot is available.</value>
        [Category("Appearance")]
        [DefaultValue(false)]
        public virtual bool ShowTextWithSnapshot {
            get { return _showTextWithSnapshot; }
            set {
                if (ShowTextWithSnapshot != value) {
                    _showTextWithSnapshot = value;

                    OnShowTextWithSnapshotChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the tab order of the control within its container.
        /// </summary>
        /// <value>The index of the tab.</value>
        /// <returns>The index value of the control within the set of controls within its container. The controls in the container are included in the tab order.</returns>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(0)]
        public new int TabIndex {
            get { return base.TabIndex; }
            set { base.TabIndex = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the user can give the focus to this control using the TAB key.
        /// </summary>
        /// <value><c>true</c> if [tab stop]; otherwise, <c>false</c>.</value>
        /// <returns>true if the user can give the focus to the control using the TAB key; otherwise, false. The default is true.Note:This property will always return true for an instance of the <see cref="T:System.Windows.Forms.Form" /> class.</returns>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(false)]
        public new bool TabStop {
            get { return base.TabStop; }
            set { base.TabStop = value; }
        }

        /// <summary>
        /// Gets or sets the zoom level of the snapshot image.
        /// </summary>
        /// <value>The zoom level.</value>
        [Category("Appearance")]
        [DefaultValue(8)]
        public virtual int Zoom {
            get { return _zoom; }
            set {
                if (Zoom != value) {
                    _zoom = value;

                    OnZoomChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating snapshot capture is in progress.
        /// </summary>
        /// <value><c>true</c> if snapshot capture is in progress; otherwise, <c>false</c>.</value>
        protected bool IsCapturing { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether redraw operations should occur.
        /// </summary>
        /// <value><c>true</c> if redraw operations should occur; otherwise, <c>false</c>.</value>
        protected bool LockUpdates { get; set; }

        /// <summary>
        /// Gets or sets the snapshot image.
        /// </summary>
        /// <value>The snapshot image.</value>
        protected Bitmap SnapshotImage { get; set; }

        #endregion

        #region Members

        /// <summary>
        /// Creates the snapshot image.
        /// </summary>
        protected virtual void CreateSnapshotImage() {
            Size size;

            if (SnapshotImage != null) {
                SnapshotImage.Dispose();
                SnapshotImage = null;
            }

            size = GetSnapshotSize();
            if (!size.IsEmpty) {
                SnapshotImage = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb);
                Invalidate();
            }
        }


        /// <summary>
        /// Gets the center point based on the current zoom level.
        /// </summary>
        protected virtual Point GetCenterPoint() {
            int x;
            int y;

            x = (ClientSize.Width / Zoom) / 2;
            y = (ClientSize.Height / Zoom) / 2;

            return new Point(x, y);
        }


        /// <summary>
        /// Gets the size of the snapshot.
        /// </summary>
        protected virtual Size GetSnapshotSize() {
            int snapshotWidth;
            int snapshotHeight;

            snapshotWidth = (int) Math.Ceiling(ClientSize.Width / (double) Zoom);
            snapshotHeight = (int) Math.Ceiling(ClientSize.Height / (double) Zoom);

            return snapshotHeight != 0 && snapshotWidth != 0 ? new Size(snapshotWidth, snapshotHeight) : Size.Empty;
        }


        /// <summary>
        /// Raises the <see cref="ColorChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnColorChanged(EventArgs e) {
            EventHandler handler;

            handler = ColorChanged;

            if (handler != null)
                handler(this, e);
        }


        /// <summary>
        /// Raises the <see cref="GridColorChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnGridColorChanged(EventArgs e) {
            EventHandler handler;

            Invalidate();

            handler = GridColorChanged;

            if (handler != null)
                handler(this, e);
        }


        /// <summary>
        /// Raises the <see cref="ImageChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnImageChanged(EventArgs e) {
            EventHandler handler;

            Invalidate();

            handler = ImageChanged;

            if (handler != null)
                handler(this, e);
        }


        /// <summary>
        /// Raises the <see cref="ShowGridChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnShowGridChanged(EventArgs e) {
            EventHandler handler;

            Invalidate();

            handler = ShowGridChanged;

            if (handler != null)
                handler(this, e);
        }


        /// <summary>
        /// Raises the <see cref="ShowTextWithSnapshotChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnShowTextWithSnapshotChanged(EventArgs e) {
            EventHandler handler;

            Invalidate();

            handler = ShowTextWithSnapshotChanged;

            if (handler != null)
                handler(this, e);
        }


        /// <summary>
        /// Raises the <see cref="ZoomChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnZoomChanged(EventArgs e) {
            EventHandler handler;

            CreateSnapshotImage();

            handler = ZoomChanged;

            if (handler != null)
                handler(this, e);
        }


        /// <summary>
        /// Paints adornments onto the control.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected virtual void PaintAdornments(PaintEventArgs e) {
            // grid
            if (ShowGrid)
                PaintGrid(e);

            // center marker
            if (HasSnapshot)
                PaintCenterMarker(e);

            // image
            if (Image != null && (!HasSnapshot || ShowTextWithSnapshot))
                e.Graphics.DrawImage(Image, (ClientSize.Width - Image.Size.Width) / 2,
                    (ClientSize.Height - Image.Size.Height) / 2);

            // draw text
            if (!string.IsNullOrEmpty(Text) && (!HasSnapshot || ShowTextWithSnapshot))
                TextRenderer.DrawText(e.Graphics, Text, Font, ClientRectangle, ForeColor, BackColor,
                    TextFormatFlags.ExpandTabs | TextFormatFlags.NoPrefix | TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter |
                    TextFormatFlags.WordBreak | TextFormatFlags.WordEllipsis);
        }


        /// <summary>
        /// Paints the center marker.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected virtual void PaintCenterMarker(PaintEventArgs e) {
            Point center;

            center = GetCenterPoint();

            using (Pen pen = new Pen(ForeColor))
                e.Graphics.DrawRectangle(pen, center.X * Zoom, center.Y * Zoom, Zoom + 2, Zoom + 2);
        }


        /// <summary>
        /// Paints the pixel grid.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected virtual void PaintGrid(PaintEventArgs e) {
            Rectangle viewport;
            int pixelSize;

            pixelSize = Zoom;
            viewport = ClientRectangle;

            using (Pen pen = new Pen(GridColor) {DashStyle = DashStyle.Dot}) {
                for (int x = viewport.Left + 1; x < viewport.Right; x += pixelSize)
                    e.Graphics.DrawLine(pen, x, viewport.Top, x, viewport.Bottom);

                for (int y = viewport.Top + 1; y < viewport.Bottom; y += pixelSize)
                    e.Graphics.DrawLine(pen, viewport.Left, y, viewport.Right, y);

                e.Graphics.DrawRectangle(pen, viewport);
            }
        }


        /// <summary>
        /// Updates the snapshot.
        /// </summary>
        protected virtual void UpdateSnapshot() {
            Point cursor;

            cursor = MousePosition;
            cursor.X -= SnapshotImage.Width / 2;
            cursor.Y -= SnapshotImage.Height / 2;

            using (Graphics graphics = Graphics.FromImage(SnapshotImage)) {
                Point center;

                // clear the image first, in case the mouse is near the borders of the screen so there isn't enough copy content to fill the area
                graphics.Clear(Color.Empty);

                // copy the image from the screen
                graphics.CopyFromScreen(cursor, Point.Empty, SnapshotImage.Size);

                // update the active color
                center = GetCenterPoint();
                Color = SnapshotImage.GetPixel(center.X, center.Y);

                // force a redraw
                HasSnapshot = true;
                Refresh(); // just calling Invalidate isn't enough as the display will lag
            }
        }

        #endregion
    }
}
