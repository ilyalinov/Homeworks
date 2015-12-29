using System;
using System.Threading.Tasks;
using System.Timers;
using System.Collections.Generic;

namespace NetworkNamespace
{
    class Program
    {
        /// <summary>
        /// "Random" number is always equals to 1
        /// </summary>
        private class MyRandom : Random
        {
            public override double NextDouble()
            {
                return 0;
            }
        }

        static void Main(string[] args)
        {
            //var network = new Network();
            //var random = new Random();

            //while (network.Graph.NumberOfNotInfected > 0)
            //{
            //    network.MakeAMove(random);
            //}

            var network = new Network();
            var myRandom = new MyRandom();

            network.MakeAMove(myRandom);
            Console.WriteLine(network.Graph.NumberOfNotInfected > 0);
        }
    }
}
