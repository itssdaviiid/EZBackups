﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EZBackups {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Res {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Res() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("EZBackups.Res", typeof(Res).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
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
        ///   Busca una cadena traducida similar a Comprimir backups.
        /// </summary>
        internal static string cbComprimir {
            get {
                return ResourceManager.GetString("cbComprimir", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Preguntar antes.
        /// </summary>
        internal static string cbPregunta {
            get {
                return ResourceManager.GetString("cbPregunta", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Carpeta de Proyextos.
        /// </summary>
        internal static string edRuta {
            get {
                return ResourceManager.GetString("edRuta", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Nombre de archivos ejemplo: &quot;AAAAMMDD_MiProyectoEnDesarrollo&quot;.
        /// </summary>
        internal static string lbEjemplo {
            get {
                return ResourceManager.GetString("lbEjemplo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Normativa de nomenclatura backups.
        /// </summary>
        internal static string lbNormativa {
            get {
                return ResourceManager.GetString("lbNormativa", resourceCulture);
            }
        }
    }
}
