using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCalculatorNamespace
{
    /// <summary>
    /// Interface for reference and array based stacks
    /// </summary>
    interface AbstractStack
    {
        /// <summary>
        /// Pushes key to the stack
        /// </summary>
        /// <param name="key"> Pushed key </param>
        void Push(int key);

        /// <summary>
        /// Deletes element from the stack
        /// </summary>
        /// <returns> Deleted key </returns>
        int Pop();

        /// <summary>
        /// Checks stack on the emptiness
        /// </summary>
        /// <returns> 1 - empty, 0 - not empty </returns>
        bool IsEmpty();
    }
}
