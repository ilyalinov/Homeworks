using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DifferentHashFunctions;

namespace UnitTestProject1
{
    [TestClass]
    public class HashFunctionsTest
    {
        private HashTable hashTable1 = null;
        private HashTable hashTable2 = null;

        [TestInitialize]
        public void Initialize()
        {
            hashTable1 = new HashTable(100, new HashFunction1());
            hashTable2 = new HashTable(100, new HashFunction2());
            hashTable1.Insert("ololo");
            hashTable2.Insert("ololo");
        }

        /// <summary>
        /// Insert + Search test
        /// </summary>
        [TestMethod]
        public void InsertSearchTest()
        {
            Assert.IsTrue(SearchInsertedElement(hashTable1));
            Assert.IsTrue(SearchInsertedElement(hashTable2));
        }

        public bool SearchInsertedElement(HashTable hashTable)
        {
            hashTable.Insert("lala");
            return hashTable.Search("lala");
        }

        /// <summary>
        /// Delete + search test
        /// </summary>
        [TestMethod]
        public void DeleteSearchTest()
        {
            Assert.IsFalse(SearchDeletedElement(hashTable1));
            Assert.IsFalse(SearchDeletedElement(hashTable2));
        }

        public bool SearchDeletedElement(HashTable hashTable)
        {
            hashTable.Delete("ololo");
            return (hashTable.Search("ololo"));
        }
    }
}
