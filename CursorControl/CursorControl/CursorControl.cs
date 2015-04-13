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
            try
            {
                Console.CursorLeft -= 1;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.Clear();
                Console.WriteLine("Can't move further (sleep for 3 seconds, then cleaning the console)");
                Thread.Sleep(3000);
                Console.Clear();
            }
        }

        /// <summary>
        /// Cursor right
        /// </summary>
        public void OnRight()
        {
            try
            {
                Console.CursorLeft += 1;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.Clear();
                Console.WriteLine("Can't move further (sleep for 3 seconds, then cleaning the console)");
                Thread.Sleep(3000);
                Console.Clear();
            }
        }

        /// <summary>
        /// Cursor up
        /// </summary>
        public void Up()
        {
            try
            {
                Console.CursorTop -= 1;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.Clear();
                Console.WriteLine("Can't move further (sleep for 3 seconds, then cleaning the console)");
                Thread.Sleep(3000);
                Console.Clear();
            }
        }

        /// <summary>
        /// Cursor down
        /// </summary>
        public void Down()
        {
            try
            {
                Console.CursorTop += 1;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.Clear();
                Console.WriteLine("Can't move further (sleep for 3 seconds, then cleaning the console)");
                Thread.Sleep(3000);
                Console.Clear();
            }
        }
    }
}
