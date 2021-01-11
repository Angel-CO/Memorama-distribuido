using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contratos
{
    /// <summary>
    /// Enumeracion que contiene los posibles resultados de un login
    /// </summary>
    public enum LoginResults
    {
        ContraseñaIncorrecta = 2,
        NoExisteUrsuario = 3,
        UsuarioEncontrado = 4
    }
}