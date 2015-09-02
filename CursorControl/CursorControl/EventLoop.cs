using System;

namespace CursorControlNamespace
{
    /// <summary>
    /// Main program loop
    /// </summary>
    public class EventLoop
    {
        public event Action LeftHandler;
        public event Action RightHandler;
        public event Action UpHandler;
        public event Action DownHandler;

        /// <summary>
        /// Method that generates endless cycle and handles the events 
        /// </summary>
        public void Run()
        {
            while (true)
            {
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        LeftHandler();
                        break;
                    case ConsoleKey.RightArrow:
                        RightHandler();
                        break;
                    case ConsoleKey.UpArrow:
                        UpHandler();
                        break;
                    case ConsoleKey.DownArrow:
                        DownHandler();
                        break;
                    default:
                        break;
                }
            }
        }
    }

}
