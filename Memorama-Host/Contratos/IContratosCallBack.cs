using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contratos
{
    public interface IContratosCallBack
    {
        [OperationContract(IsOneWay = true)]
        void GetLoginResult(LoginResults resultado);

        [OperationContract(IsOneWay = true)]
        void GetUsersOnline(List<string> usuariosConectados);

        [OperationContract(IsOneWay = true)]
        void ReceiveMessage(string source, string message);
    }
}
