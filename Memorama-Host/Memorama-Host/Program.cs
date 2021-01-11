using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

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
