using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsEditorNamespace
{
    public partial class GraphicsEditor : Form
    {
        // 1 - if we are adding a new line at the moment, 0 - otherwise
        private bool paintFlag = false;
        // 1 - if we are removing a line at the moment, 0 - otherwise
        private bool removalFlag = false;
        // 1 - if we already chase the beginning point for the new line, 0 - otherwise
        private bool isBeginningPointChoosen = false;
        // 1 - if manipulation is in progress, 0 - otherwise
        private bool manipulationFlag = false;
        // 1 - if line end is dragged by user, 0 - otherwise
        private bool isLineEndDragged = false;
        private PointF currentMousePosition;
        private PointF lastHandledClick;
        private PointF notDraggedLineEnd;
        private GraphicsEditorLogic graphicsEditorLogic = new GraphicsEditorLogic();
        UndoRedoHandler undo = new UndoRedoHandler();
        UndoRedoHandler redo = new UndoRedoHandler();

        /// <summary>
        /// Initialize form
        /// </summary>
        public GraphicsEditor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Deactivate all buttons
        /// </summary>
        private void DeactivateAllButtons()
        {
            buttonsTable.Enabled = false;
        }

        /// <summary>
        /// Activate all buttons
        /// </summary>
        private void ActivateAllButtons()
        {
            buttonsTable.Enabled = true;
        }

        /// <summary>
        /// Button click handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClickHandler(object sender, EventArgs e)
        {
            Button button = sender as Button;
            switch (button.Text)
            {
                case ("add"):
                    DeactivateAllButtons();
                    paintFlag = true;
                    isBeginningPointChoosen = false;
                    break;
                case ("remove"):
                    DeactivateAllButtons();
                    removalFlag = true;
                    break;
                case ("undo"):
                    if (!undo.IsEmpty())
                    {
                        updateRedo();
                        graphicsEditorLogic.SetState(undo.GetState());
                        pictureBox.Invalidate();
                    }
                    break;
                case ("redo"):
                    if (!redo.IsEmpty())
                    {
                        updateUndo();
                        graphicsEditorLogic.SetState(redo.GetState());
                        pictureBox.Invalidate();
                    }
                    break;
                case ("manipulate"):
                    DeactivateAllButtons();
                    manipulationFlag = true;
                    break;
            }
        }

        /// <summary>
        /// picture box paint handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxPaintHandler(object sender, PaintEventArgs e)
        {
            graphicsEditorLogic.Draw(e);

            if (paintFlag && isBeginningPointChoosen)
            {
                e.Graphics.DrawLine(new Pen(System.Drawing.Color.Blue, 3), lastHandledClick, currentMousePosition);    
            }
            else if (manipulationFlag && isLineEndDragged)
            {
                e.Graphics.DrawLine(new Pen(System.Drawing.Color.Blue, 3), notDraggedLineEnd, currentMousePosition);
            }
        }

        private void pictureBoxMouseMoveHandler(object sender, MouseEventArgs e)
        {
            currentMousePosition.X = e.X;
            currentMousePosition.Y = e.Y;
            if (paintFlag && isBeginningPointChoosen || (manipulationFlag && isLineEndDragged))
            {
                pictureBox.Invalidate();
            }
        }

        /// <summary>
        /// Mouse click on picture box handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxMouseClickHandler(object sender, MouseEventArgs e)
        {
            var prevClick = lastHandledClick;
            lastHandledClick.X = e.X;
            lastHandledClick.Y = e.Y;

            if (paintFlag && isBeginningPointChoosen)
            {
                AddLine(prevClick, lastHandledClick);
            }
            else if (paintFlag && !isBeginningPointChoosen)
            {
                isBeginningPointChoosen = true;
            }
            else if (removalFlag)
            {
                RemoveLine(lastHandledClick);
            }
            else if (manipulationFlag && !isLineEndDragged)
            {
                StartManipulation();
            }
            else if (manipulationFlag && isLineEndDragged)
            {
                AddManipulatedLine();
            }
        }

        /// <summary>
        /// Undo state updater
        /// </summary>
        private void updateUndo()
        {
            undo.AddState(graphicsEditorLogic.GetState());
        }

        /// <summary>
        /// Redo state updater
        /// </summary>
        private void updateRedo()
        {
            redo.AddState(graphicsEditorLogic.GetState());
        }

        /// <summary>
        /// Add new line
        /// </summary>
        /// <param name="prevClick"></param>
        /// <param name="lastHandledClick"></param>
        private void AddLine(PointF prevClick, PointF lastHandledClick)
        {
            updateUndo();
            graphicsEditorLogic.AddLine(new Line(prevClick, lastHandledClick));
            paintFlag = false;
            ActivateAllButtons();
        }

        /// <summary>
        /// Remove line
        /// </summary>
        /// <param name="lastHandledClick"></param>
        private void RemoveLine(PointF lastHandledClick)
        {
            updateUndo();
            if (!graphicsEditorLogic.RemoveLine(lastHandledClick))
            {
                undo.GetState();
            }
            removalFlag = false;
            ActivateAllButtons();
            pictureBox.Invalidate();
        }

        /// <summary>
        /// Add manipulated line
        /// </summary>
        private void AddManipulatedLine()
        {
            manipulationFlag = false;
            isLineEndDragged = false;
            graphicsEditorLogic.AddLine(new Line(notDraggedLineEnd, lastHandledClick));
            ActivateAllButtons();
        }

        /// <summary>
        /// Start the line manipulation
        /// </summary>
        private void StartManipulation()
        {
            updateUndo();
            notDraggedLineEnd = graphicsEditorLogic.FindNotDraggedLineEnd(lastHandledClick);
            if (!notDraggedLineEnd.IsEmpty)
            {
                isLineEndDragged = true;
            }
            else
            {
                undo.GetState();
            }
        }
    }
}