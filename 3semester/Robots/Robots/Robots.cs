using System;
using System.IO;

namespace RobotsNamespace
{
    public class JumpingRobots
    {
        private int[] robotsLocation;
        private Graph robotsGraph;
        private int numberOfRobots;

        /// <summary>
        /// Get robots locations
        /// </summary>
        /// <param name="filename"> input file name </param>
        public JumpingRobots(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            numberOfRobots = Int32.Parse(sr.ReadLine());
            robotsLocation = new int[numberOfRobots];
            for (int i = 0; i < numberOfRobots; i++)
            {
                string buffer = sr.ReadLine();
                robotsLocation[i] = Int32.Parse(buffer);
            }
        }

        /// <summary>
        /// Create graph
        /// </summary>
        /// <param name="filename"> input file </param>
        public void CreateRobotsGraph(string filename)
        {
            robotsGraph = new Graph(filename);
        }

        /// <summary>
        /// Can robots be destroyed? 
        /// </summary>
        /// <returns> Returns "true" if there is a jumps sequence resulting in destruction of all robots, otherwise "false" </returns>
        public bool CanRobotsBeDestroyed()
        {
            if (numberOfRobots <= 1)
            {
                return false;
            }
            if (robotsGraph.HasOddCycle())
            {
                return true;
            }

            robotsGraph.PaintGraphInTwoColors();
            return DoAllRobotsHaveTheSameColor();
        }

        /// <summary>
        /// Do all robots have the same color? 
        /// </summary>
        /// <returns> True if all robots have same color, otherwise false </returns>
        private bool DoAllRobotsHaveTheSameColor()
        {
            int color = robotsGraph.VerticeColor[0];
            foreach (var item in robotsLocation)
            {
                if (robotsGraph.VerticeColor[item] != color)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
