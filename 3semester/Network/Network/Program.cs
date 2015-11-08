using System;
using System.Threading.Tasks;
using System.Timers;

namespace NetworkNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            var network = new Network();
            var random = new Random();

            while (network.NumberOfNotInfected > 0)
            {
                network.MakeAMove(random);
            }
        }
    }
}
