using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contratos
{
    /// <summary>
    /// Enumeracion que contiene los posibles resultados de la calidacion
    /// </summary>
    public enum ResultadoValidacion
    {
        CodigoCorrecto = 1,
        CodigoIncorrecto = 0,
        NoseEncuentraElUsuario =2
    }
}
