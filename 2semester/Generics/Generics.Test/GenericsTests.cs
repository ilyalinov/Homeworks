using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Generics.Test
{
    [TestClass]
    public class GenericsTests
    {
        private List<int> list = new List<int>();
        private Stack<int> intStack = new Stack<int>();
        private Stack<string> stringStack = new Stack<string>();

        [TestInitialize]
        public void Initialize()
        {
            for (int i = 0; i < 10; ++i)
            {
                list.Insert(i);
            }
        }

        [TestMethod]
        public void ListEnumeratorTest()
        {
            int counter = 9;
            foreach(var item in list)
            {
                Assert.AreEqual(item, counter);
                counter--;
            }
        }

        [TestMethod]
        public void IntStackTest()
        {
            const int testInt = 1;
            intStack.Push(testInt);
            Assert.AreEqual(intStack.Pop(), testInt);
        }

        [TestMethod]
        public void StringTestMethod()
        {
            const string testString = "1";
            stringStack.Push(testString);
            Assert.AreEqual(stringStack.Pop(), testString);
        }
    }
}
