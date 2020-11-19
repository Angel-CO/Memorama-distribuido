using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contratos
{
    public enum LoginResults
    {
        PasswordIncorrecto = 2,
        NoExisteUsuario = 3,
        ExisteUsuario = 4
    }
}
