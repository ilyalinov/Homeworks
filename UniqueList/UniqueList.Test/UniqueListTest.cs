using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniqueListNamespace;

namespace UniqueList.Test
{
    [TestClass]
    public class UniqueListTest
    {
        public UniqueListClass list = null;

        [TestInitialize]
        public void Initizalize()
        {
            list = new UniqueListClass();
        }

        [TestMethod]
        [ExpectedException(typeof(UniqueListClass.AddExistentElementException))]
        public void InsertTest()
        {
            list.Insert(1);
            list.Insert(1);
        }

        [TestMethod]
        [ExpectedException(typeof(UniqueListClass.ElementDoesntExistException))]
        public void DeleteTest()
        {
            list.Delete(1);
        }

        [TestMethod]
        public void IsEmptyTest()
        {
            Assert.IsTrue(list.IsEmpty());
        }

        [TestMethod]
        public void SearchTest()
        {
            list.Insert(1);
            Assert.IsTrue(list.Search(1));
        }
    }
}
