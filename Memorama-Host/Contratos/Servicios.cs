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
