using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Contratos
{
    public class ValidarCampos
    {


        public enum ResultadosValidacion {


            contraseñavalida,
            contraseñainvalida,

            usuarioinvalido,
            usuariovalido,

            correoinvalido,
            correovalido,

            
        }

        public ResultadosValidacion ValidarContraseña(String contraseña) 
        {
            string ValidChar = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,50}$";

            if (Regex.IsMatch(contraseña, ValidChar))
            {

                return ResultadosValidacion.contraseñavalida;

            }

            return ResultadosValidacion.contraseñainvalida;


        }

        public ResultadosValidacion ValidarCorreo(string correo)
        {
            string patrón = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            if (Regex.IsMatch(correo, patrón))
            {
                return ResultadosValidacion.correovalido;
            }
            return ResultadosValidacion.correoinvalido;
        }



        public ResultadosValidacion ValidarUsuario(string usuario)
        {
            string ValidChar = @"^[a-zA-Z0-9]+$";
            if (Regex.IsMatch(usuario, ValidChar))
            {
                return ResultadosValidacion.usuariovalido;
            }
            return ResultadosValidacion.usuarioinvalido;





        }


    }

  
}
