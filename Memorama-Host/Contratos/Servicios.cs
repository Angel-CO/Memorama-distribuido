using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contratos
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    public class Servicios : IContratos
    {
        public void Login(Usuario usuario)
        {
            
        }

        public void SendMessage(string destination, string message)
        {
           
        }
    }
}
