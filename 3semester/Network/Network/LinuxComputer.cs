using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkNamespace
{
    public class LinuxComputer : Computer
    {
        public LinuxComputer(bool isInfected)
            : base(isInfected)
        {
        }

        private const double probability = 0.35;

        public override bool CompareProbability(double generatedRandomNumber)
        {
            return !(probability < generatedRandomNumber);
        }

        const string type = "Linux computer";

        public override string Type 
        { 
            get 
            { 
                return type; 
            } 
        }
    }
}
