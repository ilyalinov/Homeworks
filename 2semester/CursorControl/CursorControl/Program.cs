using System;

namespace CursorControlNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventLoop = new EventLoop();
            var cursorControl = new Cursor();

            eventLoop.RightHandler += new System.Action(cursorControl.OnRight);
            eventLoop.LeftHandler += new System.Action(cursorControl.OnLeft);
            eventLoop.UpHandler += new System.Action(cursorControl.Up);
            eventLoop.DownHandler += new System.Action(cursorControl.Down);

            eventLoop.Run();
        }
    }
}
