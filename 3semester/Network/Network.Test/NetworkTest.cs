using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetworkNamespace;
using System.Collections.Generic;

namespace NetworkTestNamespace
{
    [TestClass]
    public class NetworkTest
    {
        private Network network;
        private Random myRandom;

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

        [TestMethod]
        public void TryToInfectTest()
        {
            Computer newPC1 = new LinuxComputer(false);
            Computer newPC2 = new WindowsComputer(false);
            Random myRandom = new MyRandom();
            Assert.IsTrue(newPC1.TryToInfect(myRandom));
            Assert.IsTrue(newPC2.TryToInfect(myRandom));
        }

        [TestMethod]
        public void NetworkMakeAMoveTest()
        {
            network = new Network();
            myRandom = new MyRandom();

            network.MakeAMove(myRandom);
            List<Computer> newList = network.GetAllConnectedWithInfectedComputers();
            foreach (var item in newList)
            {
                Assert.IsTrue(item.IsInfected);
            }
        }
    }
}
