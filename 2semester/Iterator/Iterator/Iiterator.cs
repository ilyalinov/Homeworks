using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorNamespace
{
    interface IIterator
    {

        TreeElement Next();

        IteratorClass Reset(BinaryTree tree);

        bool IsEmpty();

        //public void Remove();
    }
}
