﻿using System.Xml;

namespace VixenPlus {
    internal class MappedOutputPlugIn
    {
        public readonly byte[] Buffer;
        public bool ContextInitialized;
        public readonly int From;
        public readonly IHardwarePlugin PlugIn;
        public readonly XmlNode SetupDataNode;
        public readonly int To;

        public MappedOutputPlugIn(IHardwarePlugin plugin, int from, int to, XmlNode setupDataNode)
        {
            PlugIn = plugin;
            From = from;
            To = to;
            Buffer = new byte[(to - from) + 1];
            SetupDataNode = setupDataNode;
        }
    }
}