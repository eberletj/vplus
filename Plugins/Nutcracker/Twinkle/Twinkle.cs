﻿using System.Windows.Forms;

using VixenPlus;

namespace Twinkle {
    public partial class Twinkle : UserControl, INutcrackerEffect {
        public Twinkle() {
            InitializeComponent();
        }


        public string EffectName {
            get { return "Twinkle"; }
        }

        public byte[] EffectData {
            get { throw new System.NotImplementedException(); }
        }

        public void Startup() {
            throw new System.NotImplementedException();
        }


        public void ShutDown() {
            throw new System.NotImplementedException();
        }
    }
}