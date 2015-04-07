using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QueueNamespace;

namespace Queue.Test
{
    [TestClass]
    public class UnitTest1
    {
        public QueueClass queue = null;

        [TestInitialize]
        public void Initialize()
        {
            queue = new QueueClass();
        }

        [TestMethod]
        public void EnqueueDequeueTest()
        {
            queue.Enqueue(1, 3);
            Assert.AreEqual(queue.Dequeue(), 1);
        }

        [TestMethod]
        public void SizeTest()
        {
            queue.Enqueue(1, 1);
            Assert.AreEqual(1, queue.Size);
        }

        [ExpectedException(typeof(System.NullReferenceException))]
        [TestMethod]
        public void ExceptionTest()
        {
            queue.Dequeue();
        }
    }
}
