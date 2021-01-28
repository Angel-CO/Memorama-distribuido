using System;
using System.Linq;

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
                


                Usuario us = new Usuario();
                us.Correo = correo;
                us.Nickname = nickname;
                us.Password = password;

              

                
                us.EstadoVerificacion = estadoverificar;
                us.CodigoVerificacion = codigodeverificacion;

                try
                {
                    db.Usuario.Add(us);
                    db.SaveChanges();

                    return ResultadosRegistro.RegistradoConExito;


                }
                catch (Exception)
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
