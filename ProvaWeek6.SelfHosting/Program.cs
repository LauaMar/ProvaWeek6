using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ProvaWeek6.WCF;

namespace ProvaWeek6.SelfHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(ManagerService)))
            {
                host.Open();

                Console.WriteLine("=== Esercitazioni WCF Running ===");
                Console.WriteLine("Press any key to end ...");
                Console.ReadKey();
            }
        }
    }
}
