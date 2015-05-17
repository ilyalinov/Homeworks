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
        }

        [TestMethod]
        public void TestMap()
        {
            list = MapClass.Map(list, new MapClass.Modifier(MapClass.ListElementModifier));
            Assert.IsTrue(list.Search(2 * 2));
        }
    }
}
