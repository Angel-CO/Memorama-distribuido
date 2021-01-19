using Microsoft.VisualStudio.TestTools.UnitTesting;
using Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contratos.Tests
{
    [TestClass()]
    public class PruebasServiciosTests
    {
        [TestMethod()]
        public void LoginTest()
        {

            

            PruebasServicios prueba = new PruebasServicios();
            string usuario = "techjonlogi";
            string contraseña = "Musica0102";
            Assert.AreEqual(LoginResults.UsuarioEncontrado, prueba.Login(usuario,contraseña));

        }

        [TestMethod()]
        public void LoginTestContraseñaincorrecta()
        {



            PruebasServicios prueba = new PruebasServicios();
            string usuario = "techjonlogi";
            string contraseña = "Musica";
            Assert.AreEqual(LoginResults.ContraseñaIncorrecta, prueba.Login(usuario, contraseña));

        }


        [TestMethod()]
        public void LoginTestNoExisteUsuario()
        {



            PruebasServicios prueba = new PruebasServicios();
            string usuario = "weasWeon";
            string contraseña = "Musica";
            Assert.AreEqual(LoginResults.NoExisteUrsuario, prueba.Login(usuario, contraseña));

        }



        [TestMethod()]
        public void RegistrarUsuarioTest()
        {
            PruebasServicios prueba = new PruebasServicios();
            string correo = "jhoni65475@gmail.com";
            string nickname = "eljajas2020";
            string password = "wenas2020";
            string estadoverificar = "Sin Verificar";
            string codigodeverificacion = "202015";
            Assert.AreEqual(ResultadosRegistro.RegistradoConExito, prueba.RegistrarUsuario(correo,nickname,password,estadoverificar,codigodeverificacion));


        }

        [TestMethod()]
        public void ValidarRegistroTest()
        {
            PruebasServicios prueba = new PruebasServicios();
            string usuario = "eljajas2020";
            string codigo = "202015";
            Assert.AreEqual(ResultadoValidacion.CodigoCorrecto, prueba.Login(usuario, codigo));

        }

        [TestMethod()]
        public void ValidarRegistroTestCodigoIncorrecto()
        {
            PruebasServicios prueba = new PruebasServicios();
            string usuario = "eljajas2020";
            string codigo = "2020156";
            Assert.AreEqual(ResultadoValidacion.CodigoIncorrecto, prueba.Login(usuario, codigo));

        }


        [TestMethod()]
        public void ValidarRegistroTestNoExisteUsuario()
        {
            PruebasServicios prueba = new PruebasServicios();
            string usuario = "weasWeon";
            string codigo = "2020156";
            Assert.AreEqual(ResultadoValidacion.NoseEncuentraElUsuario, prueba.Login(usuario, codigo));

        }

    }
}