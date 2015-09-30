using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TreeIterator.Test
{
    [TestClass]
    public class TreeIteratorTest
    {
        private BinaryTree<int> intBinaryTree;
        private BinaryTree<string> stringBinaryTree;
        
        [TestInitialize]
        public void Initialize()
        {
            intBinaryTree = new BinaryTree<int>();
            stringBinaryTree = new BinaryTree<string>();
            for (int i = 0; i < 10; i++)
            {
                intBinaryTree.Add(i);
                stringBinaryTree.Add(Convert.ToString(i));
            }
        }
        [TestMethod]
        public void AddSearchTest()
        {
            intBinaryTree.Add(11);
            stringBinaryTree.Add("11");
            Assert.IsTrue(stringBinaryTree.Search("11"));
            Assert.IsTrue(intBinaryTree.Search(11));
        }

        [TestMethod]
        public void DeleteSearchTest() 
        {
            intBinaryTree.Remove(5);
            stringBinaryTree.Remove("5");
            Assert.IsFalse(intBinaryTree.Search(5));
            Assert.IsFalse(stringBinaryTree.Search("5"));
            Assert.IsTrue(stringBinaryTree.Search("4"));
        }

        [TestMethod]
        public void IteratorTest()
        {
            BinaryTree<int> testBinaryTree = new BinaryTree<int>();
            foreach (var item in intBinaryTree)
            {
                testBinaryTree.Add(item);
            }
            foreach (var item in testBinaryTree)
            {
                Assert.IsTrue(intBinaryTree.Search(item));
            }
        }
    }
}
