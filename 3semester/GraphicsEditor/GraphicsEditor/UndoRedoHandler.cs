using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditorNamespace
{
    /// <summary>
    /// Handler class for undo and redo operations
    /// </summary>
    class UndoRedoHandler
    {
        /// <summary>
        /// Creates null undo/redo handler
        /// </summary>
        public UndoRedoHandler()
        {
            states = new Stack<List<Line>>();
        }

        private Stack<List<Line>> states;

        /// <summary>
        /// Add undo/redo state 
        /// </summary>
        /// <param name="list"> Added state </param>
        public void AddState(List<Line> list)
        {
            states.Push(list);
        }

        /// <summary>
        /// Get undo/redo state 
        /// </summary>
        /// <param name="list"> got state </param>
        public List<Line> GetState()
        {
            return states.Pop();
        }

        /// <summary>
        /// Is the undo/redo stack empty
        /// </summary>
        /// <returns> 1 - if stack is empty, 0 - otherwise </returns>
        public bool IsEmpty()
        {
            return (states.Count() == 0);
        }
    }
}
