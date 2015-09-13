using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ListNamespace;

namespace ListTest
{
    [TestClass]
    public class UnitTest1
    {
        private List list;

        [TestInitialize()]
        public void Initialize()
        {
            list = new List();
        }

        /// <summary>
        /// Insert test
        /// </summary>
        [TestMethod()]
        public void InsertTest()
        {
            list.Insert(10);
            Assert.IsFalse(list.IsEmpty());
        }

        /// <summary>
        /// Delete from empty list test
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void NullReferenceExceptionDeleteTest()
        {
            list.Delete(5);
        }

        /// <summary>
        /// Delete test
        /// </summary>
        [TestMethod()]
        public void DeleteTest()
        {
            list.Insert(5);
            list.Delete(5);
            Assert.IsTrue(list.IsEmpty());
        }

        /// <summary>
        /// Search + insert test
        /// </summary> 
        [TestMethod()]
        public void PushInsertTest()
        {
            list.Insert(2);
            list.Insert(5);
            Assert.IsTrue(list.Search(2));
        }
    }
}

