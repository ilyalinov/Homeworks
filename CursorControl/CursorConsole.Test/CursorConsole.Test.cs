using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CursorControlNamespace;

namespace CursorConsole.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Initialize()
        {
            var eventLoop = new EventLoop();
            var cursorControl = new Cursor();

            eventLoop.RightHandler += new System.Action(cursorControl.OnRight);
            eventLoop.LeftHandler += new System.Action(cursorControl.OnLeft);
            eventLoop.UpHandler += new System.Action(cursorControl.Up);
            eventLoop.DownHandler += new System.Action(cursorControl.Down);

            //eventLoop.Run();
        }

        [TestMethod]
        public void UpTest()
        {

        }

        [TestMethod]
        public void UpDownTest()
        {
            cursorControl.OnLeft();
            cursorControl.OnRight();
        }

        [TestMethod]
        public void OnRightLeftTest()
        {

        }

        [TestMethod]
        public void OnLeftTest()
        {

        }

        [TestMethod]
        public void ExceptionTest()
        {

        }
    }
}
