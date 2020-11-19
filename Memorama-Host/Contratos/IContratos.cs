using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contratos
{
    public interface IContratos
    {
        [OperationContract(IsOneWay = true)]
        void Login(Usuario usuario);

        [OperationContract(IsOneWay = true)]
        void SendMessage(string destination, string message);
    }
}
