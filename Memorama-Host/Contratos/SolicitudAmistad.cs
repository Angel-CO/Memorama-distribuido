//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Contratos
{
    using System;
    using System.Collections.Generic;
    
    public partial class SolicitudAmistad
    {
        public int IdSolicitud { get; set; }
        public string UsuarioRemitente { get; set; }
        public string UsuarioDestinatario { get; set; }
        public string Estado { get; set; }
    
        public virtual Usuario Usuario { get; set; }
    }
}