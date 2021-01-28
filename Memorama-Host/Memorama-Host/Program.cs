using System;
using System.ServiceModel;

namespace Memorama_Host
{
    /// <summary>
    /// Main del programa, Es donde inicia el servidor
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(Contratos.Servicios)))
            {
                host.Open();
                Console.WriteLine("Server corriendo");
                Console.ReadLine();
            }
        }
    }
}
