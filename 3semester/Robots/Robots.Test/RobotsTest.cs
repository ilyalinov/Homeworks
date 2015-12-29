using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotsNamespace;

namespace Robots.Test
{
    [TestClass]
    public class RobotsTest
    {
        private JumpingRobots robots;

        // There is odd cycle in the graph
        [TestMethod]
        public void HasOddCycleTest1()
        {
            var graph1 = new Graph("Graph1.txt");
            Assert.IsTrue(graph1.HasOddCycle());
        }

        // There is no odd cycle in the graph
        [TestMethod]
        public void HasOddCycleTest2()
        {
            var graph3 = new Graph("Graph3.txt");
            Assert.IsFalse(graph3.HasOddCycle());
        }

        [TestMethod]
        public void PrintInTwoColorsTest()
        {
            var graph = new Graph("Graph3.txt");
            graph.PaintGraphInTwoColors();
            var random = new Random();
            int vertice = random.Next(graph.NumberOfVertices);
            foreach (var item in graph.Adj[vertice])
            {
                Assert.IsTrue(graph.VerticeColor[vertice] != graph.VerticeColor[item]);
            }
        }

        // Robots can destroy themselves
        [TestMethod]
        public void CanAllRobotsBeDestroyedTest1()
        {
            var robots = new JumpingRobots("Robots1.txt");
            robots.CreateRobotsGraph("Graph1.txt");
            Assert.IsTrue(robots.CanRobotsBeDestroyed());
        }

        // Robots can destroy themselves
        [TestMethod]
        public void CanAllRobotsBeDestroyedTest2()
        {
            var robots = new JumpingRobots("Robots2.txt");
            robots.CreateRobotsGraph("Graph2.txt");
            Assert.IsTrue(robots.CanRobotsBeDestroyed());
        }

        // Robots can destroy themselves
        [TestMethod]
        public void CanAllRobotsBeDestroyedTest3()
        {
            var robots = new JumpingRobots("Robots3.txt");
            robots.CreateRobotsGraph("Graph3.txt");
            Assert.IsTrue(robots.CanRobotsBeDestroyed());
        }

        // Robots can't destroy themselves
        [TestMethod]
        public void CanAllRobotsBeDestroyedTest4()
        {
            var robots = new JumpingRobots("Robots4.txt");
            robots.CreateRobotsGraph("Graph4.txt");
            Assert.IsFalse(robots.CanRobotsBeDestroyed());
        }

        // Robots can be destroyed
        [TestMethod]
        public void CanAllRobotsBeDestroyedTest5()
        {
            var robots = new JumpingRobots("Robots5.txt");
            robots.CreateRobotsGraph("Graph5.txt");
            Assert.IsTrue(robots.CanRobotsBeDestroyed());
        }
    }
}
