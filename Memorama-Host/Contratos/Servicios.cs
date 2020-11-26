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
                Usuario us = new Usuario();
                us.Correo = usuario.Correo;
                us.Nickname = usuario.Nickname;
                us.Password = usuario.Password;
                db.Usuario.Add(us);
                try
                {
                    db.SaveChanges();
                    Callback.GetRegistroResultado(ResultadosRegistro.RegistradoConExito);

                }
                catch (Exception e) {

                    Callback.GetRegistroResultado(ResultadosRegistro.NoEsPosibleRegistrar);
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


    }
}
