﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SplendorCommonLibrary.Data {
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
    internal class Messages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SplendorCommonLibrary.Data.Messages", typeof(Messages).Assembly);
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
        ///   Looks up a localized string similar to Deck is not present.
        /// </summary>
        internal static string Error_DeckIsNotPresent {
            get {
                return ResourceManager.GetString("Error_DeckIsNotPresent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Game has already ended.
        /// </summary>
        internal static string Error_GameHasFinished {
            get {
                return ResourceManager.GetString("Error_GameHasFinished", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Game has not yet started.
        /// </summary>
        internal static string Error_GameHasNotStartedYet {
            get {
                return ResourceManager.GetString("Error_GameHasNotStartedYet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Game is already in progress.
        /// </summary>
        internal static string Error_GameIsAlreadyStarted {
            get {
                return ResourceManager.GetString("Error_GameIsAlreadyStarted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This player is not eligible for move right now.
        /// </summary>
        internal static string Error_PlayerNotEligibleForMove {
            get {
                return ResourceManager.GetString("Error_PlayerNotEligibleForMove", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There have to be at most 4 players.
        /// </summary>
        internal static string Error_ThereHaveToBeFourPlayers {
            get {
                return ResourceManager.GetString("Error_ThereHaveToBeFourPlayers", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There have to be at least 2 players.
        /// </summary>
        internal static string Error_ThereHaveToBeTwoPlayers {
            get {
                return ResourceManager.GetString("Error_ThereHaveToBeTwoPlayers", resourceCulture);
            }
        }
    }
}