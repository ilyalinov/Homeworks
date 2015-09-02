using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SetNamespace;

namespace Set.Test
{
    [TestClass]
    public class SetTests
    {
        private Set<int> set1;
        private Set<int> set2;

        [TestInitialize]
        public void Initialize()
        {
            set1 = new Set<int>();
            set2 = new Set<int>();
            for (int i = 0; i < 5; i++)
            {
                set1.AddElement(i);
                set2.AddElement(i + 4);
            }
        }

        [TestMethod]
        public void CrossingTest()
        {
            var crossingSet = set1.Crossing(set2);
            Assert.IsTrue(crossingSet.DoesContain(4));
            set1.DeleteElement(4);
            crossingSet = set1.Crossing(set2);
            Assert.IsFalse(crossingSet.DoesContain(4));
        }

        [TestMethod]
        public void AssociationTest()
        {
            var associationSet = set1.Association(set2);
            for (int i = 0; i < 8; ++i)
            {
                Assert.IsTrue(associationSet.DoesContain(i));
            }
        }
    }
}
