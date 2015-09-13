using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IteratorNamespace;
using System.Collections.Generic;

namespace Iterator.Test
{
    [TestClass]
    public class IteratorTest
    {
        private IteratorClass iterator;

        private BinaryTree tree;

        [TestInitialize]
        public void Initialize()
        {
            List<int> list = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }
            tree = new BinaryTree(list);
            iterator = new IteratorClass(tree);
        }

        [TestMethod]
        public void IteratorTest1()
        {
            int i = 0;
            while(!iterator.IsEmpty())
            {
                Assert.AreEqual(i, iterator.Next().Key);
                i++;
            }
        }
    }
}
