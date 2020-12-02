using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contratos
{
    [ServiceContract(CallbackContract = typeof(IContratosCallBack))]
    public interface IContratos
    {
        [OperationContract(IsOneWay = true)]
        void Login(Usuario usuario);

        [OperationContract(IsOneWay = true)]
        void RegistrarUsuario(Usuario usuario);

        [OperationContract(IsOneWay = true)]
        void ValidarRegistro(Usuario usuario, string codigoVerificacion);


        [OperationContract(IsOneWay = true)]
        void EnviarMensaje(string destino, string mensaje);

        [OperationContract(IsOneWay = true)]
        void AgregarUsuariosLobby(Usuario usuario);

    }
}
