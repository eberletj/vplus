﻿namespace FMOD
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Text;

    public delegate RESULT DSP_GETPARAMCALLBACK(ref DSP_STATE dsp_state, int index, ref float val, StringBuilder valuestr);
}
