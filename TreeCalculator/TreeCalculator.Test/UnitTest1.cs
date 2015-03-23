using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreeCalculator;

namespace TreeCalculator.Test
{
    [TestClass]
    public class UnitTest1
    {
        string expression = null;
        BinaryTree binaryTree = null;

        [TestInitialize]
        public void Initialize()
        {
            expression = "( + 2 3 )";
            binaryTree = new BinaryTree(expression);
        }

        [TestMethod]
        public void CountAndCreateTest()
        {
            Assert.AreEqual(5, binaryTree.Count());
        }

        [TestMethod]
        public void DivideStringTest()
        {
            string[] array = ParseString.DivideOperand(expression);
            Assert.AreEqual("+", array[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(System.DivideByZeroException))]
        public void NullReferenceEXceptionTest()
        {
            expression = "( / 2 0 )";
            binaryTree = new BinaryTree(expression);
            binaryTree.Count();
        }
    }
}
