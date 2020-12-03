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
        void GetRegistroResultado(ResultadosRegistro resultado);

        [OperationContract(IsOneWay = true)]
        void GetValidacionResultado(ResultadoValidacion resultado);

        [OperationContract(IsOneWay = true)]
        void GetUsuariosOnline(List<string> usuariosConectados);

        [OperationContract(IsOneWay = true)]
        void RecibirMensajes(string source, string message);

        [OperationContract(IsOneWay = true)]
        void GetRanking(List<UsuarioRanking> ranking);
    }
}
