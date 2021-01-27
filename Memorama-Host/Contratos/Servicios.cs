using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Common;

namespace Contratos
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    public class Servicios : IContratos
    {
        private List<int> globalTablero = new List<int>() { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6 };
        private List<int> tablero = new List<int>();

        /// <summary>
        /// Clase encargada del funcionamiento del servidor, aquí contien la implentacion de todos los metodos expuestos en la red
        /// </summary>

        private Dictionary<IContratosCallBack, string> usuariosConectados = new Dictionary<IContratosCallBack, string>();
        private List<string> usuariosMensaje = new List<string>();
        private int primeraCarta;
        private int segundaCarta;
        private IContratosCallBack personaEnTurno;

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
                us.EstadoVerificacion = usuario.EstadoVerificacion;
                us.CodigoVerificacion = usuario.CodigoVerificacion;
                
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
            msj.From = new System.Net.Mail.MailAddress("jhoni65475@gmail.com");

            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            cliente.Credentials = new System.Net.NetworkCredential("jhoni65475@gmail.com", "somos ajenos");
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
              
            }
        }





        public List<int> GenerarTablero(Random random)
        {
            tablero = globalTablero;
            int n = tablero.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                int value = tablero[k];
                tablero[k] = tablero[n];
                tablero[n] = value;
            }
            return tablero;
        }



        public void HacerMovimiento(int primeraCarta, int segundaCarta)
        {
            if (tablero[primeraCarta] == tablero[segundaCarta])
            {
                foreach (var cliente in usuariosConectados)
                {
                    Callback.GetMovimiento(true, primeraCarta, segundaCarta);
                }
            }
            else
            {
                foreach (var cliente in usuariosConectados)
                {
                    Callback.GetMovimiento(false, primeraCarta, segundaCarta);
                }
            }
        }




        public void PasarCarta(int posicion)
        {


            foreach (var cliente in usuariosConectados)
            {
                cliente.Key.GetCarta(posicion);
            } 
        }


        public void CartaEquivocada()
        {
            bool flag = true;
            bool passed = false;
            foreach (var cliente in usuariosConectados)
            {
                if (personaEnTurno == usuariosConectados.Last().Key && flag)
                {
                    cliente.Key.GetTurno(true);
                    personaEnTurno = cliente.Key;
                    flag = false;
                }
                else if (cliente.Key == personaEnTurno)
                {
                    cliente.Key.GetTurno(false);
                    passed = true;
                }
                else if (passed)
                {
                    cliente.Key.GetTurno(true);
                    personaEnTurno = cliente.Key;
                    passed = false;
                }
                else
                {
                    cliente.Key.GetTurno(false);
                }

            }
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

        public void BuscarParaCambiarContraseña(string usuario, string correo)
        {
            using (MemoramaDBEntities db = new MemoramaDBEntities()) 
            {

                var usuarioabuscar = db.Usuario.FirstOrDefault(x => x.Nickname == usuario);
                    if(usuarioabuscar != null)
                {
                    if (usuarioabuscar.Correo.Equals(correo))
                    {
                        Random random = new Random();
                        int codigoVerificacion = random.Next(100000, 1000000);
                        usuarioabuscar.CodigoVerificacion = codigoVerificacion.ToString();
                        db.SaveChanges();
                        enviarCorreo(correo, codigoVerificacion);

                        Callback.GetResultadoBusqueda(usuarioabuscar.Nickname);

                    }
                    else 
                    {
                        Callback.correoEquivocado();
                    }

                }
                else 
                {
                    Callback.NoExisteUsuario();
                }


            
            
            }
        }

        



        public void CambiarContraseña(string contraseña,string usuario)
        {
            using (MemoramaDBEntities db = new MemoramaDBEntities())
            {
                var usuarioEditar = db.Usuario.FirstOrDefault(x => x.Nickname == usuario);
                
                
                    usuarioEditar.Password = contraseña;
               
              
               
                
                
                try
                {
                    db.SaveChanges();
                    Callback.ContraseñaCambiada();
                }
                catch 
                {

                    Callback.NosepudocambiarLaContraseña();
                }



            }

        }

       

        public void validarCodigoContraseña(string codigo, string usuario)
        {
            using (MemoramaDBEntities db = new MemoramaDBEntities())
            {
                var usuarioabuscar = db.Usuario.FirstOrDefault(x => x.Nickname == usuario);
                if (usuarioabuscar != null)
                {
                    if (usuarioabuscar.CodigoVerificacion == codigo)
                    {
                        Callback.CodigoValidado(usuario);
                    }
                    else
                    {
                        Callback.GetValidacionResultado(ResultadoValidacion.CodigoIncorrecto);
                    }


                }
                else {
                    Callback.GetValidacionResultado(ResultadoValidacion.NoseEncuentraElUsuario);
                }
            }
        }

        public void verificarReportes(string usuario)
        {
            using (MemoramaDBEntities db = new MemoramaDBEntities()) 
            {

                var usuarioabuscar = db.Usuario.FirstOrDefault(x => x.Nickname == usuario);
                if (usuarioabuscar != null)
                {
                    if (usuarioabuscar.CantidadReportes == null)
                    {
                        usuarioabuscar.CantidadReportes = 1;
                        db.SaveChanges();
                        Callback.EstadoReporte();

                    }
                    else
                    {
                        usuarioabuscar.CantidadReportes = usuarioabuscar.CantidadReportes + 1;
                        db.SaveChanges();
                        Callback.EstadoReporte();

                    }



                    if (usuarioabuscar.CantidadReportes >= 3)
                    {
                        db.Usuario.Remove(usuarioabuscar);
                        db.SaveChanges();


                    }
                }
                else 
                {

                    Callback.NoExisteUsuario();
                }
            }
        }

        public void Empezarjuego()
        {
            Random random = new Random();
            int numero = random.Next(0, 5);
            

            foreach (var cliente in usuariosConectados)
            {
                cliente.Key.GetJuego(numero);
                cliente.Key.GetTurno(false);

            }
            personaEnTurno = usuariosConectados.First().Key;
            usuariosConectados.First().Key.GetTurno(true);


        }

    }
}
 