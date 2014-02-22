﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

using VixenPlusCommon.Properties;

namespace VixenPlusCommon {
    [DefaultProperty("Color")]
    [DefaultEvent("ColorChanged")]
    public partial class ColorPicker : Form {

        private const string ControlPb = "pbCustom";


        public ColorPicker(Color color, bool showNone = true) {
            InitializeComponent();
            ControlBox = false; // Workaround: If this is set to false in the designer.cs, it renders wrong.
            btnNone.Visible = showNone;
            SetColorOrImage(pbOriginalColor, color);
            SetEditorColor(color);
        }


        private void SetEditorColor(Color color) {
            //colorEditor1.Color = color == Color.Transparent ? Color.White : color; TODO Decide if I want to keep this.
            colorEditor1.Color = color;
        }


        public event EventHandler ColorEditorColorChanged;


        private void OnColorEditorColorChanged() {
            var handler = ColorEditorColorChanged;
            if (handler != null) {
                handler(this, new ColorEventArgs(colorEditor1.Color));
            }
        }


        private void colorEditor1_ColorChanged(object sender, EventArgs e) {
            SetColorOrImage(pbNewColor, colorEditor1.Color);
            OnColorEditorColorChanged();
        }


        public Color GetColor() {
            return pbNewColor.BackColor;
        }


        private static void SetColorOrImage(Control pb, Color color) {
            pb.BackColor = color;
            pb.BackgroundImage = color == Color.Transparent ? Resources.cellbackground : null;
        }


        private void pbCustom_Click(object sender, EventArgs e) {
            var control = sender as PictureBox;
            if (null == control) {
                return;
            }

            SetEditorColor(control.BackColor);
            pbNewColor.BackColor = control.BackColor;

            foreach (var c in from PictureBox c in (from object c in Controls where c is PictureBox select c) where c.Name.StartsWith(ControlPb) select c) {
                c.BorderStyle = c == sender ? BorderStyle.Fixed3D : BorderStyle.FixedSingle;
            }
        }


        private void btnAddColor_Click(object sender, EventArgs e) {
            if ((from object c in Controls select c as PictureBox).Count(
                    pb => pb != null && pb.Name.StartsWith(ControlPb) && pb.BorderStyle == BorderStyle.Fixed3D) > 0) {
                foreach (var c in from PictureBox c in (from object c in Controls where c is PictureBox select c)
                    where c.Name.StartsWith(ControlPb) && c.BorderStyle == BorderStyle.Fixed3D
                    select c) {
                    c.BackColor = colorEditor1.Color;
                }
            }
            else {
                pbCustom0.BackColor = colorEditor1.Color;
            }
        }

        private void pbOriginalColor_Click(object sender, EventArgs e) {
            SetEditorColor(pbOriginalColor.BackColor);
            pbNewColor.BackColor = pbOriginalColor.BackColor;
        }

        private void ColorPicker_Shown(object sender, EventArgs e) {
            var colors = Preference2.GetInstance().GetString(Preference2.CustomColorsPreference).Split(',');
            var colorCount = colors.Count() - 1;
            for (var i = 0; i < 16; i++) {
                var control = Controls.Find(string.Format("pbCustom{0:X}", i), true)[0];
                var color = Color.White;
                if (colorCount >= i) {
                    var raw = int.Parse(colors[i]);
                    var r = (raw & 0xFF);
                    var g = (raw & 0xFF00) >> 8;
                    var b = (raw & 0xFF0000) >> 16;
                    color = Color.FromArgb(r, g, b);
                }
                control.BackColor = color;
            }
        }

        private void ColorPicker_FormClosing(object sender, FormClosingEventArgs e) {
            var colors = (from PictureBox c in
                              (from object c in Controls where c is PictureBox select c)
                          where c.Name.StartsWith(ControlPb)
                          select c.BackColor).Reverse().ToArray();
            var color = new string[colors.Count()];
            for (var i = 0; i < colors.Count(); i++) {
                var raw = colors[i];
                color[i] = (raw.R + (raw.G << 8) + (raw.B << 16)).ToString(CultureInfo.InvariantCulture);
            }
            Preference2.GetInstance().SetString(Preference2.CustomColorsPreference,string.Join(",", color));
        }
    }
}