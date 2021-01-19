using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace Contratos
{
    public class PruebasServicios
    {



        public  LoginResults Login(string username, string password)
        {
            using (MemoramaDBEntities db = new MemoramaDBEntities())
            {
                var usu = db.Usuario.Where((x) => x.Nickname == username).FirstOrDefault();
                if (usu != null)
                {
                    if (usu.Password.Equals(password))
                    {

                        return LoginResults.UsuarioEncontrado;
                    }
                    else
                    {
                        return LoginResults.ContraseñaIncorrecta;
                    }
                }
                else
                {
                    return LoginResults.NoExisteUrsuario;
                }
            }

        }



        public ResultadosRegistro RegistrarUsuario(string correo,string nickname, string password, string estadoverificar,string codigodeverificacion)
        {
            using (MemoramaDBEntities db = new MemoramaDBEntities())
            {
                Random random = new Random();
                int codigoVerificacion = random.Next(100000, 1000000);


                Usuario us = new Usuario();
                us.Correo = correo;
                us.Nickname = nickname;
                us.Password = password;

                //us.EstadoVerificacion = "Sin verificar";
                //us.CodigoVerificacion = codigoVerificacion.ToString();

                ;
                us.EstadoVerificacion = estadoverificar;
                us.CodigoVerificacion = codigodeverificacion;

                try
                {
                    db.Usuario.Add(us);
                    db.SaveChanges();

                    return ResultadosRegistro.RegistradoConExito;


                }
                catch (Exception e)
                {

                    return ResultadosRegistro.NoEsPosibleRegistrar;
                }

            } 


        }


        public ResultadoValidacion ValidarRegistro(string usuario, string codigoVerificacion)
        {
            using (MemoramaDBEntities db = new MemoramaDBEntities())
            {
                var usu = db.Usuario.Where((x) => x.Nickname == usuario).FirstOrDefault();
                if (usu != null)
                {
                    if (usu.CodigoVerificacion.Equals(codigoVerificacion))
                    {
                        usu.EstadoVerificacion = "Verificado";
                        db.SaveChanges();
                       return ResultadoValidacion.CodigoCorrecto;
                    }
                    else
                    {
                        return ResultadoValidacion.CodigoIncorrecto;
                    }
                }
            }
            return ResultadoValidacion.NoseEncuentraElUsuario;
        }


    } 
}
