using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ListFilter;

namespace ListFilter.Test
{
    [TestClass]
    public class ListFilterTest
    {
        public List list = null;

        [TestInitialize]
        public void TestInitialize()
        {
            list = new List();
            list.Insert(2);
            list.Insert(3);
        }

        /// <summary>
        /// Fiter function test
        /// </summary>
        [TestMethod]
        public void FilterTest()
        {
            
            list = FilterClass.Filter(list, x => (x % 2 == 0));
            Assert.IsTrue(list.Search(2));
            Assert.IsFalse(list.Search(3));
        }
    }
}
