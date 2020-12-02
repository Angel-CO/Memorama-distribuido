using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Contratos
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    public class Servicios :IContratos
    {
        public void Login(Usuario usuario)
        {
            using (MemoramaDBEntities db = new MemoramaDBEntities())
            {
                var usu = db.Usuario.Where((x) => x.Nickname == usuario.Nickname).FirstOrDefault();
                if (usu != null)
                {
                    if (usu.Password.Equals(usuario.Password))
                    {
                        Callback.GetLoginResult(LoginResults.UsuarioEncontrado);
                    }
                    else
                    {
                        Callback.GetLoginResult(LoginResults.ContraseñaIncorrecta);
                    }
                }
                else
                {
                    Callback.GetLoginResult(LoginResults.NoExisteUrsuario);
                }
            }
            
        }

        public void RegistrarUsuario(Usuario usuario)
        {
            using (MemoramaDBEntities db = new MemoramaDBEntities()) 
            {
                Random random = new Random();
                int codigoVerificacion = random.Next(100000, 1000000);


                Usuario us = new Usuario();
                us.Correo = usuario.Correo;
                us.Nickname = usuario.Nickname;
                us.Password = usuario.Password;
                us.EstadoVerificacion = "Sin verificar";
                us.CodigoVerificacion = codigoVerificacion.ToString();
                db.Usuario.Add(us);
                try
                {
                    db.SaveChanges();
                    Callback.GetRegistroResultado(ResultadosRegistro.RegistradoConExito);
                    enviarCorreo(usuario.Correo, codigoVerificacion);

                }
                catch (Exception e) {

                    Callback.GetRegistroResultado(ResultadosRegistro.NoEsPosibleRegistrar);
                }
                
               

            }
        }

        public void ValidarRegistro(Usuario usuario, string codigoVerificacion)
        {
            using (MemoramaDBEntities db = new MemoramaDBEntities())
            {
                var usu = db.Usuario.Where((x) => x.Nickname == usuario.Nickname).FirstOrDefault();
                if(usu != null)
                {
                    if (usu.CodigoVerificacion.Equals(codigoVerificacion))
                    {
                        usu.EstadoVerificacion = "Verificado";
                        db.SaveChanges();
                        Callback.GetValidacionResultado(ResultadoValidacion.CodigoCorrecto);
                    }
                    else
                    {
                        Callback.GetValidacionResultado(ResultadoValidacion.CodigoIncorrecto);
                    }
                }
            }
        }

        IContratosCallBack Callback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<IContratosCallBack>();
            }
        }

        private void enviarCorreo(string destinatario, int codigoVerificacion)
        {
            System.Net.Mail.MailMessage msj = new System.Net.Mail.MailMessage();

            msj.To.Add(destinatario);
            msj.Subject = "Confirmación de correo electronico";
            msj.SubjectEncoding = System.Text.Encoding.UTF8;
            msj.Body = "Código de verificación '" + codigoVerificacion + "'";
            msj.BodyEncoding = System.Text.Encoding.UTF8;
            msj.IsBodyHtml = true;
            msj.From = new System.Net.Mail.MailAddress("angeljcalderono@gmail.com");

            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            cliente.Credentials = new System.Net.NetworkCredential("angeljcalderono@gmail.com", "15%DmP5&");
            cliente.Port = 587;
            cliente.EnableSsl = true;
            cliente.Host = "smtp.gmail.com";

            try
            {
                cliente.Send(msj);
                Console.WriteLine("Envio exitoso {0}", destinatario);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
