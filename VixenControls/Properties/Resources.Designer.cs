﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1022
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VixenPlusCommon.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("VixenPlusCommon.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        public static System.Drawing.Bitmap cellbackground {
            get {
                object obj = ResourceManager.GetObject("cellbackground", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {3} has had a critical error and is closing.
        ///
        ///This issue was written to {0}, please e-mail this log, your sequence and profile (if applicable) with any support request.
        ///
        ///{1}
        ///
        ///{2}.
        /// </summary>
        public static string CriticalErrorOccurred {
            get {
                return ResourceManager.GetString("CriticalErrorOccurred", resourceCulture);
            }
        }
        
        public static System.Drawing.Bitmap edit {
            get {
                object obj = ResourceManager.GetObject("edit", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error Log Created.
        /// </summary>
        public static string ErrorLogCreated {
            get {
                return ResourceManager.GetString("ErrorLogCreated", resourceCulture);
            }
        }
        
        public static System.Drawing.Bitmap eyedropper {
            get {
                object obj = ResourceManager.GetObject("eyedropper", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Version {0}.
        /// </summary>
        public static string FormattedVersion {
            get {
                return ResourceManager.GetString("FormattedVersion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {3} has had a non-critical error and may be able to continue.
        ///
        ///If you continue, please save any open work and restart {3}.
        ///
        ///This issue was written to {0}, please e-mail this log, your sequence and profile (if applicable) with any support request.
        ///
        ///{1}
        ///
        ///{2}.
        /// </summary>
        public static string InformOnError {
            get {
                return ResourceManager.GetString("InformOnError", resourceCulture);
            }
        }
        
        public static System.Drawing.Bitmap none {
            get {
                object obj = ResourceManager.GetObject("none", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        public static System.Drawing.Bitmap palette_load {
            get {
                object obj = ResourceManager.GetObject("palette_load", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        public static System.Drawing.Bitmap palette_save {
            get {
                object obj = ResourceManager.GetObject("palette_save", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Lighting Control Software.
        /// </summary>
        public static string ProductDescription {
            get {
                return ResourceManager.GetString("ProductDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {3} has had a non-critical error and may be able to continue.
        ///
        ///If you continue, please save any open work and restart {3}.
        ///
        ///This issue was written to {0}, please e-mail this log, your sequence and profile (if applicable) with any support request.
        ///
        ///{1}
        ///
        ///{2}
        ///
        ///Do you wish to continue?.
        /// </summary>
        public static string SoftErrorOccured {
            get {
                return ResourceManager.GetString("SoftErrorOccured", resourceCulture);
            }
        }
        
        public static System.Drawing.Icon VixenPlus {
            get {
                object obj = ResourceManager.GetObject("VixenPlus", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
    }
}
