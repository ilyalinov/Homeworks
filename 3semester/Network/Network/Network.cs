using System;
using System.Collections.Generic;
using System.IO;

namespace NetworkNamespace
{
    public class Network
    {
        public NetworkGraph Graph { get; private set; }

        /// <summary>
        /// Creates network
        /// </summary>
        public Network()
        {
            Graph = new NetworkGraph();
        }

        public List<Computer> GetAllConnectedWithInfectedComputers()
        {
            List<Computer> newList = new List<Computer>();
            foreach (var i in Graph.NumbersOfInfected)
            {
                for (int j = 0; j < Graph.ListOfComputers.Count; j++)
                {
                    if (Graph.ArrayOfConnections[i, j] == 1)
                    {
                        newList.Add(Graph.ListOfComputers[j]);
                    }
                }
            }
            return newList;
        }

        /// <summary>
        /// Make a step. Network tries to infect all not infected computers which are directly connected with infected.
        /// </summary>
        /// <param name="random"></param>
        public void MakeAMove(Random random)
        {
            for (int i = 0; i < Graph.ListOfComputers.Count; i++)
            {
                if (MayComputerBeInfected(i))
                {
                    bool temp = Graph.ListOfComputers[i].TryToInfect(random);
                    if (temp)
                    {
                        Graph.NumberOfNotInfected--;
                        Graph.NumbersOfInfected.Add(i);
                    }
                }
            }

            foreach (var item in Graph.NumbersOfInfected)
            {
                Graph.ListOfComputers[item].IsInfected = true;
            }

            PrintCurrentState();
        }

        /// <summary>
        /// Prints current network state to console
        /// </summary>
        private void PrintCurrentState()
        {
            Console.Write("Current state: ");
            for (int i = 0; i < Graph.ListOfComputers.Count; i++)
            {
                Console.Write("{0}){1} ", i + 1, Graph.ListOfComputers[i].Type);
                if (Graph.ListOfComputers[i].IsInfected)
                {
                    Console.Write("is infected; ");
                }
                else
                {
                    Console.Write("isn't infected; ");
                }
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Check if computer may be infected
        /// </summary>
        /// <param name="computerNumber"> computer number </param>
        /// <returns></returns>
        private bool MayComputerBeInfected(int computerNumber)
        {
            if (Graph.ListOfComputers[computerNumber].IsInfected)
            {
                return false;
            }

            for (int j = 0; j < Graph.ArrayOfConnections.GetUpperBound(0); j++)
            {
                if (Graph.ArrayOfConnections[computerNumber, j] == 1 && Graph.ListOfComputers[j].IsInfected)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
