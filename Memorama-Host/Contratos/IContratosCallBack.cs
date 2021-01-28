using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Contratos
{
    public interface IContratosCallBack
    {
        /// <summary>
        /// Esta interface contiene los metodos que serviran de respuesta a los clientes.
        /// </summary>
        /// <param name="resultado"></param>
        
        
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

        [OperationContract(IsOneWay = true)]
        void GetCarta(int posicion);


        [OperationContract(IsOneWay = true)]
        void GetJuego(int numero);

        [OperationContract(IsOneWay = true)]
        void GetMovimiento(Boolean bandera, int primeraCarta, int segundaCarta);


        [OperationContract(IsOneWay = true)]
        void GetResultadoBusqueda(string usuario);

        [OperationContract(IsOneWay = true)]
        void NoExisteUsuario();

        [OperationContract(IsOneWay = true)]
        void correoEquivocado();

        [OperationContract(IsOneWay = true)]
        void NosepudocambiarLaContraseña();


        [OperationContract(IsOneWay = true)]
        void UsuarioEncontrado(string usuario);

        [OperationContract(IsOneWay = true)]
        void CodigoValidado(string usuario);

        [OperationContract(IsOneWay = true)]
        void ContraseñaCambiada();

        [OperationContract(IsOneWay = true)]
        void EstadoReporte();


        [OperationContract(IsOneWay = true)]
        void FaltanJugadores();

        [OperationContract(IsOneWay = true)]
        void LobbyLleno();


        [OperationContract(IsOneWay = true)]
        void GetTurno(bool turno);

    }
}
