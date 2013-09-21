﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace VixenPlus // ReSharper disable EmptyGeneralCatchClause
{
    internal class HardwarePlugins {
        private static readonly Dictionary<string, IHardwarePlugin> PluginCache = new Dictionary<string, IHardwarePlugin>();


        public static IHardwarePlugin FindPlugin(string pluginName, string directory, string interfaceName) {
            return FindPlugin(pluginName, false, directory, interfaceName);
        }


        public static IHardwarePlugin FindPlugin(string pluginName, bool uniqueInstance, string directory, string interfaceName) {
            foreach (var plugin2 in PluginCache.Values) {
                if (plugin2.Name != pluginName) {
                    continue;
                }
                if (uniqueInstance) {
                    return (IHardwarePlugin) Activator.CreateInstance(plugin2.GetType());
                }
                return plugin2;
            }
            foreach (var str in Directory.GetFiles(directory, "*.dll")) {
                try {
                    var assembly = Assembly.LoadFile(str);
                    foreach (var type in assembly.GetExportedTypes()) {
                        foreach (var type2 in type.GetInterfaces()) {
                            if (type2.Name != interfaceName) {
                                continue;
                            }
                            var plugin = (IHardwarePlugin) Activator.CreateInstance(type);
                            if (!PluginCache.ContainsKey(str)) {
                                PluginCache[str] = plugin;
                            }
                            if (plugin.Name == pluginName) {
                                return plugin;
                            }
                        }
                    }
                }
                catch {}
            }
            return null;
        }


        public static List<string> LoadPluginNames(string directory, string interfaceName) {
            var list = new List<string>();
            foreach (var str in Directory.GetFiles(directory, "*.dll")) {
                IHardwarePlugin plugin;
                if (!PluginCache.TryGetValue(str, out plugin)) {
                    try {
                        var assembly = Assembly.LoadFile(str);
                        foreach (var type in assembly.GetExportedTypes()) {
                            foreach (var type2 in type.GetInterfaces()) {
                                if (type2.Name != interfaceName) {
                                    continue;
                                }
                                plugin = (IHardwarePlugin) Activator.CreateInstance(type);
                                PluginCache[str] = plugin;
                            }
                        }
                    }
                    catch {}
                }
                if (plugin != null) {
                    list.Add(plugin.Name);
                }
            }
            return list;
        }


        public static List<IHardwarePlugin> LoadPlugins(string directory, string interfaceName) {
            var list = new List<IHardwarePlugin>();
            if (!Directory.Exists(directory)) {
                return list;
            }
            foreach (var str in Directory.GetFiles(directory, "*.dll", SearchOption.TopDirectoryOnly)) {
                IHardwarePlugin plugin;
                if (!PluginCache.TryGetValue(str, out plugin)) {
                    try {
                        var assembly = Assembly.LoadFile(str);
                        foreach (var type in from type in assembly.GetExportedTypes() from type2 in type.GetInterfaces() where type2.Name == interfaceName select type) {
                            plugin = (IHardwarePlugin) Activator.CreateInstance(type);
                            PluginCache[str] = plugin;
                        }
                    }
                    catch {}
                }
                if (plugin != null) {
                    list.Add(plugin);
                }
            }
            return list;
        }
    }

    // ReSharper restore EmptyGeneralCatchClause

}
