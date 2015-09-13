using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorNamespace
{
    /// <summary>
    /// Tree element class
    /// </summary>
    public class TreeElement
    {
        public TreeElement(int key)
        {
            this.Key = key;
        }
        public int Key { get; set; }
        public TreeElement Right { get; set; }
        public TreeElement Left { get; set; }
        public TreeElement Parent { get; set; }
    }
}
