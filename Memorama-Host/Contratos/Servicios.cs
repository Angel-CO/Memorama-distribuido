using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Contratos
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    public class Servicios : IContratos
    {

        /// <summary>
        /// Clase encargada del funcionamiento del servidor, aquí contien la implentacion de todos los metodos expuestos en la red
        /// </summary>

        private Dictionary<IContratosCallBack, string> usuariosConectados = new Dictionary<IContratosCallBack, string>();
        private List<string> usuariosMensaje = new List<string>();

        public void Login(Usuario usuario)
        {
            using (MemoramaDBEntities db = new MemoramaDBEntities ())
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
                
                //us.EstadoVerificacion = "Sin verificar";
                //us.CodigoVerificacion = codigoVerificacion.ToString();

                usuario.CodigoVerificacion = codigoVerificacion.ToString();
                usuario.EstadoVerificacion = "Sin verificar";
                
                try
                {
                    db.Usuario.Add(us);
                    db.SaveChanges();

                    Callback.GetRegistroResultado(ResultadosRegistro.RegistradoConExito);
                    enviarCorreo(usuario.Correo, codigoVerificacion);

                }
                catch (Exception e){

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



        public void AgregarUsuariosLobby(Usuario usuario)
        {
            Boolean existe = false;


            foreach (var usuarioC in usuariosConectados)
            {
                if (usuario.Nickname.Equals(usuarioC.Value)) 
                {
                    existe = true;
                    break;


                }


            
            }
            if(!existe) 
            {
                usuariosConectados.Add(Callback, usuario.Nickname);
                usuariosMensaje.Add(usuario.Nickname);
                NotificarDeNuevoUsuario();
            }
            else
            {
                NotificarDeNuevoUsuario();

            }

            
        }

        private void NotificarDeNuevoUsuario()
        {
            
            
                Callback.GetUsuariosOnline(usuariosMensaje);
           
        }
    
    
        public void EnviarMensaje(string destino, string mensaje)
        {
            foreach (var usuario in usuariosConectados)
            {
                if (usuario.Value.Equals(destino))
                {
                    usuario.Key.RecibirMensajes(GetSourceUser(), mensaje);
                }
            }
        }

        private string GetSourceUser()
        {
            string sourceUser = "";

            foreach (var usuario in usuariosConectados)
            {
                if (usuario.Key == Callback)
                {
                    sourceUser = usuario.Value;
                }

            }

            return sourceUser;
        }

        public void RankingUsuarios()
        {
            using (MemoramaDBEntities db = new MemoramaDBEntities())
            {
                List<UsuarioRanking> ranking = new List<UsuarioRanking>();
                var usuarios = db.Usuario.Where(p => p.PuntajeTotal != null).OrderByDescending(x => x.PuntajeTotal);
                
                foreach (var usu in usuarios)
                {
                    UsuarioRanking usuarioRanking = new UsuarioRanking();
                    usuarioRanking.Nickname = usu.Nickname;
                    usuarioRanking.Puntuacion = (int)usu.PuntajeTotal;

                    ranking.Add(usuarioRanking);
                }
                Callback.GetRanking(ranking);
                //usuarios.Max<>
            }
        }

        public void Empezarjuego()
        {
            Boolean bandera = false;
            Random random = new Random();
           int numero =  random.Next(0, 5);
            if (usuariosConectados.Count >= 2)
            {
                bandera = true;
               
                foreach(var cliente in usuariosConectados)
                {
                    Callback.GetJuego(bandera, numero);
                }
                
            }
            else 
            {
                foreach (var cliente in usuariosConectados)
                {
                    Callback.GetJuego(bandera,numero);
                }
            }
        }

        public void PasarCarta(String objeto, String objeto2)
        {
            
            Callback.GetCarta(objeto,objeto2);
            
        }

        public void LogOutLobby(String usuario)
        {
            foreach (var usuarioC in usuariosConectados)
            {

                if (usuarioC.Value.Equals(usuario)) 
                {
                    usuariosConectados.Remove(usuarioC.Key);
                    usuariosMensaje.Remove(usuario);
                    break;
                
                }

               

            }
            NotificarDeNuevoUsuario();
            
        }

        public void AgregarPuntuacion(string usuario, int puntaje)
        {
            
            using (MemoramaDBEntities db = new MemoramaDBEntities()) 
            {
                var usuarioEditar = db.Usuario.FirstOrDefault(x => x.Nickname == usuario);
                usuarioEditar.PuntajeTotal = puntaje;
                db.SaveChanges();
            
            
            
            
            }

        }
    }
}
