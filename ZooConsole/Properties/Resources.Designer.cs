﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZooConsole.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ZooConsole.Properties.Resources", typeof(Resources).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 1. True
        ///2. False.
        /// </summary>
        internal static string BoolOptions {
            get {
                return ResourceManager.GetString("BoolOptions", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please select property to edit by index:
        ///.
        /// </summary>
        internal static string ChoosePropertyUserMessage {
            get {
                return ResourceManager.GetString("ChoosePropertyUserMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please choose Color:
        ///
        ///{0}. Orange
        ///{1}. Yellow
        ///{2}. Blue
        ///{3}. Red
        ///{4}. Green.
        /// </summary>
        internal static string ColorOptions {
            get {
                return ResourceManager.GetString("ColorOptions", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Oops, Something went wrong executing your choice. Try again!.
        /// </summary>
        internal static string ExceptionCaughtUserMessage {
            get {
                return ResourceManager.GetString("ExceptionCaughtUserMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please choose Gender:
        ///
        ///{0}. Male
        ///{1}. Female
        ///.
        /// </summary>
        internal static string GenderOptions {
            get {
                return ResourceManager.GetString("GenderOptions", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please enter {0}:.
        /// </summary>
        internal static string GetPropertyUserMessage {
            get {
                return ResourceManager.GetString("GetPropertyUserMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Hello!
        ///Welcome to the zoo console!
        ///.
        /// </summary>
        internal static string GreetUserMessage {
            get {
                return ResourceManager.GetString("GreetUserMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Thats not a possible option, try again!
        ///.
        /// </summary>
        internal static string InvalidOptionUserMessage {
            get {
                return ResourceManager.GetString("InvalidOptionUserMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Main Menu:
        ///
        ///{0}. View all animals
        ///{1}. Create new animal
        ///{2}. Edit existing animal 
        ///{3}. Save zoo
        ///{4}. Exit.
        /// </summary>
        internal static string MainMenu {
            get {
                return ResourceManager.GetString("MainMenu", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please select animal to edit by index:
        ///.
        /// </summary>
        internal static string SelectAnimalToEditUserMessage {
            get {
                return ResourceManager.GetString("SelectAnimalToEditUserMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please select animal type to create by index:
        ///.
        /// </summary>
        internal static string SelectAnimalTypeUserMessage {
            get {
                return ResourceManager.GetString("SelectAnimalTypeUserMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please choose Shark Type:
        ///
        ///{0}. Hammer Head
        ///{1}. Loan
        ///{2}. Great White.
        /// </summary>
        internal static string SharkTypeOptions {
            get {
                return ResourceManager.GetString("SharkTypeOptions", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Woops, Seems like there is no animals at the zoo currently.
        ///.
        /// </summary>
        internal static string ZooEmptyUserMessage {
            get {
                return ResourceManager.GetString("ZooEmptyUserMessage", resourceCulture);
            }
        }
    }
}
