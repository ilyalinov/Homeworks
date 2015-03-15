using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ListNamespace;

namespace ListTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Insert test
        /// </summary>
        [TestMethod]
        public void InsertTest()
        {
            List list = new List();
            list.Insert(10);
            Assert.IsFalse(list.IsEmpty());
        }

        /// <summary>
        /// Delete from empty list test
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void NullReferenceExceptionDeleteTest()
        {
            List list = new List();
            list.Delete(5);
        }

        /// <summary>
        /// Delete test
        /// </summary>
        [TestMethod]
        public void DeleteTest()
        {
            List list = new List();
            list.Insert(5);
            list.Delete(5);
            Assert.IsTrue(list.IsEmpty());
        }

        /// <summary>
        /// Search + insert test
        /// </summary> 
        [TestMethod]
        public void PushInsertTest()
        {
            List list = new List();
            list.Insert(2);
            list.Insert(5);
            Assert.IsTrue(list.Search(2));
        }
    }
}

