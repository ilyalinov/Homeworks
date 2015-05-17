using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ListMap;

namespace ListMap.Test
{
    [TestClass]
    public class UnitTest1
    {
        private List list = null;

        [TestInitialize]
        public void Initialize()
        {
            list = new List();
            list.Insert(2);
            list.Insert(3);
        }

        [TestMethod]
        public void TestMap()
        {
            list = MapClass.Map(list, x => (x + 2));
            Assert.IsTrue(list.Search(2 + 2));
            Assert.IsTrue(list.Search(3 + 2));
        }
    }
}
