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
            throw new NotImplementedException();
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
