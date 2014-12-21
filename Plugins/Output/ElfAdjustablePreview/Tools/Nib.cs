﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ElfAdjustablePreview.Core.Controllers;
using ElfAdjustablePreview.Core.Util;
using ElfRes = ElfAdjustablePreview.Properties.Resources;

namespace ElfAdjustablePreview.Tools {
    /// <summary>
    ///     Nib data and methods for Tools that use one
    /// </summary>
    public class Nib {
        #region NibShape enum

        public enum NibShape {
            NotSet = -1,
            Square,
            Round
        }

        #endregion

        #region [ Private Variables ]

        private readonly SortedList<string, ButtonImages> _buttonFaces;
        private readonly Settings _settings = Settings.Instance;
        private readonly Workshop _workshop = Workshop.Instance;
        private bool _eventsAttached;
        private float _size;

        #endregion [ Private Variables ]

        #region [ Public Fields ]

        public ToolStripComboBox NibSize_Control = null;
        public Rectangle Rect_Canvas;
        public Rectangle Rect_Lattice;

        // Toolstrip controls
        public ToolStripButton RoundNib_Control = null;
        public NibShape Shape = NibShape.NotSet;
        public ToolStripButton SquareNib_Control = null;

        //public PictureBox CanvasControl = null;	

        #endregion [ Public Fields ]

        #region [ Properties ]

        /// <summary>
        ///     The CanvasPane PictureBox on the form CanvasWindow
        /// </summary>
        /// <summary>
        ///     Custom Cursor, created based on the nib size and shape
        /// </summary>
        public Cursor Cursor {
            get { return CustomCursors.NibCursor(_size, (Shape == NibShape.Round)); }
        }

        public float Size {
            get { return _size; }
            set {
                _size = value;
                Rect_Lattice = new Rectangle(0, 0, (int) _size, (int) _size);
                if (_workshop.Profile == null) {
                    return;
                }
                float CellScaleF = _workshop.Profile.Scaling.CellScaleF;
                Rect_Canvas = new Rectangle(0, 0, (int) (_size * CellScaleF), (int) (_size * CellScaleF));
            }
        }

        public float HalfSize {
            get { return _size / 2f; }
        }

        #endregion [ Properties ]

        #region [ Constructor ]

        public Nib() {
            Size = 1;
            _buttonFaces = new SortedList<string, ButtonImages>();
        }

        #endregion [ Constructor ]

        #region [ Methods ]

        /// <summary>
        ///     Recalculates the Canvas rectangle to account for any changes in Cell scaling. This should be called on MouseDown
        /// </summary>
        public void AdjustForCellSize() {
            float CellScaleF = _workshop.Profile.Scaling.CellScaleF;
            Rect_Canvas = new Rectangle(0, 0, (int) (_size * CellScaleF), (int) (_size * CellScaleF));
        }


        /// <summary>
        ///     Attach events to the ToolStrip controls
        /// </summary>
        /// <param name="attach">Indicates if the event delegate should be attached or detached.</param>
        public void AttachEvents(bool attach) {
            // If we've already either attached or detached, exit out.
            if (attach && _eventsAttached) {
                return;
            }

            if (attach) {
                if (NibSize_Control != null) {
                    NibSize_Control.SelectedIndexChanged += NibSize_SelectedIndexChanged;
                }
                if (SquareNib_Control != null) {
                    SquareNib_Control.Click += SquareNib_Click;
                }
                if (RoundNib_Control != null) {
                    RoundNib_Control.Click += RoundNib_Click;
                }
            }
            else {
                if (NibSize_Control != null) {
                    NibSize_Control.SelectedIndexChanged -= NibSize_SelectedIndexChanged;
                }
                if (SquareNib_Control != null) {
                    SquareNib_Control.Click -= SquareNib_Click;
                }
                if (RoundNib_Control != null) {
                    RoundNib_Control.Click -= RoundNib_Click;
                }
            }

            _eventsAttached = attach;
        }


        /// <summary>
        ///     Create a bitmap to be used as a cursor.
        /// </summary>
        /// <returns></returns>
        public Bitmap CursorBitmap(out Point hotSpot) {
            hotSpot = Point.Empty;
            float Diameter = this.Size * _workshop.Profile.Scaling.CellScaleF;
            int Size = Convert.ToInt32(Math.Ceiling(Diameter + 2));

            var CursorBmp = new Bitmap(Size, Size);
            using (Graphics g = Graphics.FromImage(CursorBmp)) {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);
                Pen CursorPen = null;

                if (Shape == NibShape.Round) {
                    CursorPen = new Pen(Color.AntiqueWhite, 1.8f);
                    g.DrawEllipse(CursorPen, 1, 1, Diameter, Diameter);
                }
                else {
                    CursorPen = new Pen(Color.AntiqueWhite, 1f);
                    g.DrawRectangle(CursorPen, 1, 1, Diameter, Diameter);
                }
                CursorPen.Dispose();
            }

            Diameter /= 2;
            Size = Convert.ToInt32(Math.Ceiling(Diameter)) + 1;
            hotSpot = new Point(Size, Size);

            return CursorBmp;
        }


        /// <summary>
        ///     Load the Nib value from settings
        /// </summary>
        /// <param name="_settings">Settings object</param>
        /// <param name="parentPath">Save path from the Tool that owns this object</param>
        public void LoadSettings(string parentPath) {
            Size = _settings.GetValue(_settings.AppendPath(parentPath, Constants.NIB_SIZE), 1);
            Shape =
                EnumHelper.GetEnumFromValue<NibShape>(_settings.GetValue(_settings.AppendPath(parentPath, Constants.NIB_SHAPE), (int) NibShape.Square));

            if (_buttonFaces.Count == 0) {
                AddButtonFaces(RoundNib_Control.Name, new ButtonImages(ElfRes.round_nib, ElfRes.round_nib_selected));
                AddButtonFaces(SquareNib_Control.Name, new ButtonImages(ElfRes.square_nib, ElfRes.square_nib_selected));
            }

            NibSize_Control.SelectedIndex = (int) _size - 1;
            RoundNib_Control.Checked = (Shape == NibShape.Round);
            SquareNib_Control.Checked = (Shape == NibShape.Square);

            SetSelected(RoundNib_Control);
            SetSelected(SquareNib_Control);
        }


        /// <summary>
        ///     Move the rectangles to be centered on this point
        /// </summary>
        public void OffsetRects(Point pt) {
            Rect_Lattice.X = pt.X - (int) HalfSize;
            Rect_Lattice.Y = pt.Y - (int) HalfSize;
            int CellScale = _workshop.Profile.Scaling.CellScale;
            Rect_Canvas.X = _workshop.CalcCanvasPoint(pt).X - (int) HalfSize * CellScale;
            Rect_Canvas.Y = _workshop.CalcCanvasPoint(pt).Y - (int) HalfSize * CellScale;
        }


        /// <summary>
        ///     Save the Nib values to Settings
        /// </summary>
        /// <param name="settings">Settings object</param>
        /// <param name="parentPath">Save path from the Tool that owns this object</param>
        public void SaveSettings(Settings settings, string parentPath) {
            settings.SetValue(settings.AppendPath(parentPath, Constants.NIB_SIZE), _size);
            settings.SetValue(settings.AppendPath(parentPath, Constants.NIB_SHAPE), (int) Shape);
        }


        private void SetSelected(ToolStripButton button) {
            button.Image = _buttonFaces[button.Name].GetImage(button.Checked);
        }


        protected void AddButtonFaces(string key, ButtonImages buttonImages) {
            if (buttonImages == null) {
                return;
            }
            if (_buttonFaces.ContainsKey(key)) {
                return;
            }
            _buttonFaces.Add(key, buttonImages);
        }

        #endregion [ Methods ]

        #region [ Events ]

        private void RoundNib_Click(object sender, EventArgs e) {
            if (RoundNib_Control.Checked) {
                return;
            }
            SquareNib_Control.Checked = false;
            RoundNib_Control.Checked = true;
            Shape = NibShape.Round;
            SetSelected(RoundNib_Control);
            SetSelected(SquareNib_Control);
            OnChanged();
        }


        private void SquareNib_Click(object sender, EventArgs e) {
            if (SquareNib_Control.Checked) {
                return;
            }
            RoundNib_Control.Checked = false;
            SquareNib_Control.Checked = true;
            Shape = NibShape.Square;
            SetSelected(RoundNib_Control);
            SetSelected(SquareNib_Control);

            OnChanged();
        }


        private void NibSize_SelectedIndexChanged(object sender, EventArgs e) {
            string Value = NibSize_Control.SelectedItem.ToString();
            if (Value.Length > 0) {
                Size = Convert.ToInt32(Value);
            }
            OnChanged();
        }

        #region [ Event Handlers ]

        public EventHandler Changed;

        #endregion [ Event Handlers ]

        #region [ Event Triggers ]

        private void OnChanged() {
            if (Changed == null) {
                return;
            }
            Changed(this, new EventArgs());

            //if (Profile.Canvas != null)
            //    Profile.Cursor = this.Cursor;
        }

        #endregion [ Event Triggers ]

        #endregion [ Events ]
    }
}