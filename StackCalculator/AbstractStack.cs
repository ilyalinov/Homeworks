using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCalculatorNamespace
{
    interface AbstractStack
    {
        void Push(int key);

        int Pop();

        bool IsEmpty();
    }
}
