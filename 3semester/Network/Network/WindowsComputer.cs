using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkNamespace
{
    public class WindowsComputer : Computer
    {
        public WindowsComputer(bool isInfected) : base(isInfected)
        {
        }

        private const double probability = 0.65;

        public override bool CompareProbability(double generatedRandomNumber)
        {
            return !(generatedRandomNumber > probability);
        }

        const string type = "Windows computer";

        public override string Type 
        { 
            get
            {
                return type;  
            } 
        }
    }
}
