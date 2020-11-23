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
        private Dictionary<IContratosCallBack, string> usuariosConectados = new Dictionary<IContratosCallBack, string>();
        private List<string> usuariosMensaje = new List<string>();
        public void Login(Usuario usuario)
        {
            LoginResults resultado;
            List<Usuario> usuarios = new List<Usuario>
            {
                new Usuario()
                {
                    Nickname = "techjonlogi",
                    Password = "musica0102"
                },

               
            };


            if (usuarios.Any(user => user.Nickname.Equals(usuario.Nickname)))
            {
                if (usuarios.Any(user => user.Password.Equals(usuario.Password)))
                {
                    resultado = LoginResults.UsuarioEncontrado;


                }
                else
                {
                    resultado = LoginResults.ContraseñaIncorrecta;
                }

            }
            else
            {
                resultado = LoginResults.NoExisteUrsuario;
            }


            Callback.GetLoginResult(resultado);
            
        }

        IContratosCallBack Callback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<IContratosCallBack>();
            }
        }


    }
}
