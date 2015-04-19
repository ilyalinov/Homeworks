using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ListFold;

namespace ListFold.Test
{
    [TestClass]
    public class ListFoldTest
    {
        public List list = null;
        public FoldClass.UpdateValue updateValue = null;

        [TestInitialize]
        public void Initialize()
        {
            list = new List();
            updateValue = new FoldClass.UpdateValue(FoldClass.Sum);
            for (int i = 0; i <= 10; i++)
            {
                list.Insert(i);
            }
        }

        /// <summary>
        /// Counting sum 1 + ... + 10
        /// </summary>
        [TestMethod]
        public void FoldTest()
        {
            Assert.AreEqual(FoldClass.Fold(list, 0, updateValue), 10 * 11 / 2);
        }
    }
}
