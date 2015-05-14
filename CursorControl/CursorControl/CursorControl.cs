using System;
using System.Threading;

namespace CursorControlNamespace
{
    /// <summary>
    /// Hadler class for cursor
    /// </summary>
    public class Cursor
    {
        public void OnLeft()
        {
            if (Console.CursorLeft == 0)
            {
                return;
            }
            Console.CursorLeft -= 1;
        }

        /// <summary>
        /// Cursor right
        /// </summary>
        public void OnRight()
        {
            if (Console.CursorLeft >= Console.WindowWidth - 1)
            {
                return;
            }
            Console.CursorLeft += 1;
        }

        /// <summary>
        /// Cursor up
        /// </summary>
        public void Up()
        {
            if (Console.CursorTop <= 0)
            {
                return;
            }
            Console.CursorTop -= 1;
        }

        /// <summary>
        /// Cursor down
        /// </summary>
        public void Down()
        {
            if (Console.CursorTop >= Console.WindowHeight - 1)
            {
                return;
            }
            Console.CursorTop += 1;
        }
    }
}
