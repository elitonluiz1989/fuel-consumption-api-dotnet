﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FuelConsumptionApp.Resources {
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
    internal class StringResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal StringResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("FuelConsumptionApp.Resources.StringResource", typeof(StringResource).Assembly);
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
        ///   Looks up a localized string similar to O carro com Número de Série {0} não encontrado.
        /// </summary>
        internal static string CarWasNotFound {
            get {
                return ResourceManager.GetString("CarWasNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Dados inválidos.
        /// </summary>
        internal static string InvalidData {
            get {
                return ResourceManager.GetString("InvalidData", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O valor informado para abastacer excede a capacidade disponível para o carro com Número de Série {0}.
        /// </summary>
        internal static string RefuelExceedsCapacity {
            get {
                return ResourceManager.GetString("RefuelExceedsCapacity", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O tanque de combustível do carro com Número de Série {0} está vazio.
        /// </summary>
        internal static string TankIsEmpty {
            get {
                return ResourceManager.GetString("TankIsEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O tanque de combustível do carro com Número de Série {0} está cheio.
        /// </summary>
        internal static string TankIsFull {
            get {
                return ResourceManager.GetString("TankIsFull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O valor infomado execede a capacidade abastecida para rodar o carro com Número de Série {0}.
        /// </summary>
        internal static string ThereAreNotEnoughLitersToRun {
            get {
                return ResourceManager.GetString("ThereAreNotEnoughLitersToRun", resourceCulture);
            }
        }
    }
}
