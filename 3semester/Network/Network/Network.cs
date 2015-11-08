using System;
using System.Collections.Generic;
using System.IO;

namespace NetworkNamespace
{
    public class Network
    {
        private int[ , ] arrayOfConnections;

        public List<Computer> listOfComputers { get; private set;}

        public List<int> NumbersOfInfected { get; private set; }

        public int NumberOfNotInfected { get; private set; }

        /// <summary>
        /// Create network using text data from file "Input.txt"
        /// </summary>
        public Network()
        {
            listOfComputers = new List<Computer>();
            NumbersOfInfected = new List<int>();
            StreamReader sr = new StreamReader("Input.txt");
            string buffer = sr.ReadLine();
            int numberOfComputers = Int32.Parse(buffer);
            NumberOfNotInfected = numberOfComputers;
            arrayOfConnections = new int[numberOfComputers, numberOfComputers];
            for (int i = 0; i < numberOfComputers; i++)
            {
                for (int j = i; j < numberOfComputers; j++)
                {
                    arrayOfConnections[i, j] = 0;
                    arrayOfConnections[j, i] = 0;
                }
            }

            ReadComputersFromFile(sr, numberOfComputers);
            ReadConnections(sr);

            sr.Close();
        }

        /// <summary>
        /// Read computers from file
        /// </summary>
        /// <param name="sr"> stream reader </param>
        /// <param name="numberOfComputers"> total number of computers </param>
        private void ReadComputersFromFile(StreamReader sr, int numberOfComputers)
        {
            for (int i = 0; i < numberOfComputers; i++)
            {
                string buffer = sr.ReadLine();
                string[] splittedBuffer = buffer.Split(' ');
                switch (splittedBuffer[0])
                {
                    case "windows":
                        bool isInfected = Convert.ToBoolean(Convert.ToInt32(splittedBuffer[1]));
                        if (isInfected)
                        {
                            NumberOfNotInfected--;
                            NumbersOfInfected.Add(listOfComputers.Count);
                        }
                        listOfComputers.Add(new WindowsComputer(isInfected));
                        break;
                    case "linux":
                        isInfected = Convert.ToBoolean(Convert.ToInt32(splittedBuffer[1]));
                        if (isInfected)
                        {
                            NumberOfNotInfected--;
                            NumbersOfInfected.Add(listOfComputers.Count);
                        }
                        listOfComputers.Add(new LinuxComputer(isInfected));
                        break;
                }
            }
        }

        /// <summary>
        /// Get connections between computers from file
        /// </summary>
        /// <param name="sr"> stream reader </param>
        private void ReadConnections(StreamReader sr)
        {
            string buffer;
            while ((buffer = sr.ReadLine()) != null)
            {
                string[] splittedBuffer = buffer.Split(' ');
                int i = Int32.Parse(splittedBuffer[0]);
                int j = Int32.Parse(splittedBuffer[1]);
                arrayOfConnections[i, j] = 1;
                arrayOfConnections[j, i] = 1;
            }
        }

        public List<Computer> GetAllConnectedWithInfectedComputers()
        {
            List<Computer> newList = new List<Computer>();
            foreach (var i in NumbersOfInfected)
            {
                for (int j = 0; j < listOfComputers.Count; j++)
                {
                    if (arrayOfConnections[i, j] == 1)
                    {
                        newList.Add(listOfComputers[j]);
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
            for (int i = 0; i < listOfComputers.Count; i++)
            {
                if (MayComputerBeInfected(i))
                {
                    bool temp = listOfComputers[i].TryToInfect(random);
                    if (temp)
                    {
                        this.NumberOfNotInfected--;
                        NumbersOfInfected.Add(i);
                    }
                }
            }

            PrintCurrentState();
        }

        /// <summary>
        /// Prints current network state to console
        /// </summary>
        private void PrintCurrentState()
        {
            Console.Write("Current state: ");
            for (int i = 0; i < listOfComputers.Count; i++)
            {
                Console.Write("{0}){1} ", i + 1, listOfComputers[i].Type);
                if (listOfComputers[i].IsInfected)
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
            if (listOfComputers[computerNumber].IsInfected)
            {
                return false;
            }

            for (int j = 0; j < arrayOfConnections.GetUpperBound(0); j++)
            {
                if (arrayOfConnections[computerNumber, j] == 1 && listOfComputers[j].IsInfected)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
