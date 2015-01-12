﻿using System.Globalization;
using System.Linq;
using System.Xml;

using VixenPlus;
using VixenPlus.Annotations;

namespace SeqIOHelpers {
    [UsedImplicitly]
    public class Vixen25FileIO : VixenFileIOBase {

        public override string DialogFilterList() {
            return string.Format("Vixen 2.5 Sequence (*{0})|*{0}", FileExtension());
        }

        public override string Name() {
            return "Vixen 2.5";
        }


        public override int PreferredOrder() {
            return 2;
        }

        public override bool CanSave() {
            return true;
        }

        public override void SaveSequence(EventSequence eventSequence) {
            var contextNode = Xml.CreateXmlDocument();
            BaseSaveSequence(contextNode, eventSequence, FormatChannel);
            contextNode.Save(eventSequence.FileName);
        }


        //TODO Sort orders! @#$%^&*
        public override void SaveProfile(Profile profile) {
            var profileXml = Xml.CreateXmlDocument("Profile");
            profile.FileIOHandler = this;

            BaseSaveProfile(profileXml, profile, FormatChannel);
            //Sort Orders go here

            profileXml.Save(profile.FileName);
            profile.IsDirty = false;
        }


        private static XmlNode FormatChannel(XmlDocument doc, Channel ch) {
            XmlNode node = doc.CreateElement("Channel");
            Xml.SetAttribute(node, "name", ch.Name);
            Xml.SetAttribute(node, "color", ch.Color.ToArgb().ToString(CultureInfo.InvariantCulture));
            Xml.SetAttribute(node, "output", (ch.OutputChannel).ToString(CultureInfo.InvariantCulture));
            Xml.SetAttribute(node, "id", ch.Id.ToString(CultureInfo.InvariantCulture));
            Xml.SetAttribute(node, "enabled", ch.Enabled.ToString());

            if (ch.DimmingCurve != null) {
                Xml.SetValue(node, "Curve", string.Join(",", ch.DimmingCurve.Select(num => num.ToString(CultureInfo.InvariantCulture)).ToArray()));
            }

            return node;
        }


        public override bool CanOpen() {
            return true;
        }
    }
}