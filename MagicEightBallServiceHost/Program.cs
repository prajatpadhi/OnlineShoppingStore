using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using MagicEightBallClassLibrary;

namespace MagicEightBallServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Console based WCF host");
            using (ServiceHost host = new ServiceHost(typeof(MagicEightBallService)))
            {
                host.Open();
                Console.WriteLine("Host is ready");
                Console.WriteLine("Press the enter key to terminate service");
                Console.ReadLine();
            }
        }
    }
}
