using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkNamespace
{
    public abstract class Computer
    {
        public Computer()
        {
        }

        /// <summary>
        /// Is this computer infected
        /// </summary>
        /// <param name="isInfected"></param>
        public Computer(bool isInfected)
        {
            this.IsInfected = isInfected;
        }

        /// <summary>
        /// Compare generated random number with computer probability being infected
        /// </summary>
        /// <param name="generatedRandomNumber"> random number </param>
        /// <returns> </returns>
        public abstract bool CompareProbability(double generatedRandomNumber);

        /// <summary>
        /// Try to infect current computer
        /// </summary>
        /// <param name="random"> random numbers generator </param>
        /// <returns> 1 - if computer was infected in this iteration, else - 0 </returns>
        public bool TryToInfect(Random random)
        {
            double generatedRandomNumber = random.NextDouble();
            return CompareProbability(generatedRandomNumber);
        }

        /// <summary>
        /// Computer type
        /// </summary>
        public abstract string Type{ get; }

        /// <summary>
        /// Is this computer infected (1 - yes, 0 - no)
        /// </summary>
        public bool IsInfected { get; set; }
    }
}
