using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            var robots = new JumpingRobots("Robots5.txt");
            robots.CreateRobotsGraph("Graph5.txt");
            Console.WriteLine(robots.CanRobotsBeDestroyed());
        }
    }
}
