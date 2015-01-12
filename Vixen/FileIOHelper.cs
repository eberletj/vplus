﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Schema;

using VixenPlusCommon;

namespace VixenPlus {
    public static class FileIOHelper {

        private static readonly Dictionary<string, IFileIOHandler> PluginCache = new Dictionary<string, IFileIOHandler>();


        static FileIOHelper() {
            LoadPlugins();
        }



        private static void LoadPlugins() {
            foreach (var dllFile in Directory.GetFiles(Paths.OutputPluginPath, Vendor.SeqFileIO + Vendor.AppExtension, SearchOption.TopDirectoryOnly)) {
                try {
                    var assembly = Assembly.LoadFile(dllFile);

                    var validTypes = from exportedType in assembly.GetExportedTypes()
                        from Interface in exportedType.GetInterfaces()
                        where Interface.Name == "IFileIOHandler"
                        select exportedType;

                    foreach (var desiredType in validTypes) {
                        // Cant use abstract types so skip it.
                        if (desiredType.IsAbstract) continue;

                        // If we have a cache hit, we can just skip this one.
                        IFileIOHandler plugin;
                        if (PluginCache.TryGetValue(desiredType.Name, out plugin)) continue;

                        PluginCache[desiredType.Name] = (IFileIOHandler) Activator.CreateInstance(desiredType);
                    }

                }
                catch (Exception e) {
                    e.ToString().CrashLog();
                }
            }
        }


        public static string GetOpenFilters() {
            var filter = PluginCache.Select(v => v.Value).Where(v => v.CanOpen()).OrderBy(handler => handler.PreferredOrder()).ToArray();

            var sb = new StringBuilder();
            foreach (var f in filter) {
                sb.Append(f.DialogFilterList()).Append("|");
            }

            return sb.Remove(sb.Length - 1, 1).ToString();
        }


        public static string GetSaveFilters() {
            var filter = PluginCache.Select(v => v.Value).Where(v => v.CanSave()).OrderBy(handler => handler.PreferredOrder()).ToArray();

            var sb = new StringBuilder();
            foreach (var f in filter) {
                sb.Append(f.DialogFilterList()).Append("|");
            }

            return sb.Length > 0 ? sb.Remove(sb.Length - 1, 1).ToString() : String.Empty;
        }


        public static IFileIOHandler GetHelperByName(string s) {
            return PluginCache.First(v => v.Value.DialogFilterList().StartsWith(s)).Value;
        }


        public static IFileIOHandler GetNativeHelper() {
            return PluginCache.First(fio => fio.Value.IsNativeToVixenPlus()).Value;
        }


        public static IFileIOHandler GetByExtension(string fileName) {
            var s = Path.GetExtension(fileName);
            if (s == null) {
                return null;
            }

            // first get all matching extentions
            var candidates = PluginCache.Select(v => v.Value).Where(v => v.FileExtension() == s).OrderBy(v=>v.PreferredOrder()).ToList();
            
            // If there are not any, then return the native Vixen+ helper and hope for the best.
            if (!candidates.Any()) {
                return GetNativeHelper();
            }

            // If there is only one or there are more than one for non vixen files, then return the first item
            if (candidates.Count() == 1 || s != ".vix") {
                return candidates.First();
            }

            // So it is a vixen file, which version?
            return GetVixenVersion(fileName); 

        }


        private static IFileIOHandler GetVixenVersion(string fileName) {
            var doc = new XmlDocument();
            doc.Load(fileName);
            var programContextNode = Xml.GetRequiredNode(doc, "Program");
            var profileNode = programContextNode.SelectSingleNode("Profile");

            XmlNodeList channels;
            
            if (profileNode == null) {
                channels = programContextNode.SelectNodes("Channels/Channel");
            }
            else {
                var path = Path.Combine(Paths.ProfilePath, profileNode.InnerText + Vendor.ProfileExtension);
                if (!File.Exists(path)) {
                    throw new FileNotFoundException("Cant locate profile.", path);
                }

                doc.Load(path);

                programContextNode = Xml.GetRequiredNode(doc, "Profile");
                channels = programContextNode.SelectNodes("ChannelObjects/Channel");
            }

            if (channels == null) {
                throw new FormatException("No profile or channels in sequence");
            }

            var channelToCheck = channels.Cast<XmlNode>().FirstOrDefault();

            if (channelToCheck != null 
                && channelToCheck.Attributes != null 
                && channelToCheck.Attributes["name"] == null) {
                return GetHelperByName("Vixen 2.1");
            }

            return programContextNode.SelectSingleNode("Groups") == null ? GetHelperByName("Vixen 2.5") : GetNativeHelper();
        }

    }
}