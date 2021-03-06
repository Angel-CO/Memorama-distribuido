﻿using System;
using System.ServiceModel;

namespace Contratos
{
    [ServiceContract(CallbackContract = typeof(IContratosCallBack))]
    public interface IContratos
    {
        /// <summary>
        /// Esta interface contiene los contratos que se expondran en la red
        /// </summary>
        /// <param name="usuario"></param>

        
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

        [OperationContract(IsOneWay = true)]
        void RankingUsuarios();

        [OperationContract(IsOneWay = true)]
        void Empezarjuego();

        [OperationContract(IsOneWay = true)]
        void HacerMovimiento(int primeraCarta, int segundaCarta);

        [OperationContract(IsOneWay = true)]
        void PasarCarta(int id);

        [OperationContract(IsOneWay = true)]
        void LogOutLobby(String usuario);

        [OperationContract(IsOneWay = true)]
        void AgregarPuntuacion(String usuario, int puntaje);

        [OperationContract(IsOneWay = true)]
        void BuscarParaCambiarContraseña(string usuario, string correo);


        [OperationContract(IsOneWay = true)]
        void CambiarContraseña(string contraseña, string usuario);

        [OperationContract(IsOneWay = true)]
        void validarCodigoContraseña(string codigo,string usuario);


        [OperationContract(IsOneWay = true)]
        void verificarReportes(string usuario);






        [OperationContract(IsOneWay = true)]
        void CartaEquivocada();
    }
}
