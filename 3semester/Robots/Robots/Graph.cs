using System;
using System.Collections.Generic;
using System.IO;

namespace RobotsNamespace
{
    public class Graph
    {
        /// <summary>
        /// Adjacency-list representation
        /// </summary>
        public List<int>[] Adj { get; private set; }
        public int NumberOfVertices { get; private set; }
        // Used for DFS graph coloring
        private int[] DFSverticeColor;
        private int[] span;
        // Used for simple graph coloring in 2 colors
        public int[] VerticeColor { get; private set; }

        /// <summary>
        /// Read graph from input file
        /// </summary>
        /// <param name="filename"> File name </param>
        public Graph(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            NumberOfVertices = Int32.Parse(sr.ReadLine());
            Adj = new List<int>[NumberOfVertices];
            for (int i = 0; i < NumberOfVertices; i++)
            {
                Adj[i] = new List<int>();
            }

            string buffer = null;
            int temp = 0;
            while ((buffer = sr.ReadLine()) != null)
            {
                string[] splittedBuffer = buffer.Split(' ');
                if (splittedBuffer.Length < 2)
                {
                    throw new Exception();
                }
                for (int i = 1; i < splittedBuffer.Length; i++)
                {
                    Adj[temp].Add(Int32.Parse(splittedBuffer[i]));
                }
                temp++;
            }
        }
        
        /// <summary>
        /// Does the graph have a cycle of odd length?
        /// </summary>
        /// <returns></returns>
        public bool HasOddCycle()
        {
            DFSverticeColor = new int[NumberOfVertices];
            span = new int[NumberOfVertices];
            for (int i = 0; i < NumberOfVertices; i++)
            {
                DFSverticeColor[i] = 0;
            }

            span[0] = 0;
            bool hasGraphOddCycle = false;
            DFSVisit(0, ref hasGraphOddCycle);
            return hasGraphOddCycle;
        }

        private void DFSVisit(int vertice, ref bool hasGraphOddCycle)
        {
            if (hasGraphOddCycle)
            {
                return;
            }

            DFSverticeColor[vertice] = 1;

            foreach (var item in Adj[vertice])
            {
                if (DFSverticeColor[item] == 0)
                {
                    span[item] = span[vertice] + 1;
                    DFSVisit(item, ref hasGraphOddCycle);
                }
                else if (DFSverticeColor[item] == 1)
                {
                    if ((span[vertice] - span[item] + 1) % 2 == 1)
                    {
                        hasGraphOddCycle = true;
                    }
                }
            }

            DFSverticeColor[vertice] = 2;
        }

        /// <summary>
        /// Paint the graph in 2 colors that vertices of one color isn't connected by an edge.
        /// </summary>
        public void PaintGraphInTwoColors()
        {
            VerticeColor = new int[NumberOfVertices];
            for (int i = 0; i < NumberOfVertices; i++)
            {
                VerticeColor[i] = 0;
            }

            VerticeColor[0] = 1;
            Queue<int> verticeQueue = new Queue<int>();
            verticeQueue.Enqueue(0);
            while (verticeQueue.Count > 0)
            {
                PaintNeighbours(verticeQueue.Dequeue(), ref verticeQueue);
            }
        }

        /// <summary>
        /// Paint all vertices connected to the given one. Add these vertices to the queue.
        /// </summary>
        /// <param name="verticeNumber"> given vertice </param>
        /// <param name="verticeQueue"> vertice queue </param>
        private void PaintNeighbours(int verticeNumber, ref Queue<int> verticeQueue)
        {
            foreach (var item in Adj[verticeNumber])
            {
                if (VerticeColor[item] == 0)
                {
                    VerticeColor[item] = 3 - VerticeColor[verticeNumber];
                    if (!verticeQueue.Contains(item))
                    {
                        verticeQueue.Enqueue(item);
                    }
                }
            }
        }
    }
}
