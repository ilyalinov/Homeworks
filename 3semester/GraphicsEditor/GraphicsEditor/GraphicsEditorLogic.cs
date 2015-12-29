using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsEditorNamespace
{
    /// <summary>
    /// Graphics editor main logic class
    /// </summary>
    class GraphicsEditorLogic
    {
        private List<Line> lines;
        const int pxConst = 5;

        /// <summary>
        /// Creates null graphics editor logic 
        /// </summary>
        public GraphicsEditorLogic()
        {
            lines = new List<Line>();
        }

        /// <summary>
        /// Gets current graphics editor logic state
        /// </summary>
        /// <returns> Got state </returns>
        public List<Line> GetState()
        {
            List<Line> newList = new List<Line>();
            foreach (var item in this.lines)
            {
                newList.Add(item);
            }
            return newList;
        }

        /// <summary>
        /// Sets given graphics editor logic state
        /// </summary>
        /// <param name="newList"> given state </param>
        public void SetState(List<Line> newList)
        {
            this.lines = newList;
        }

        /// <summary>
        /// Add new line
        /// </summary>
        /// <param name="newLine"> Added line </param>
        public void AddLine(Line newLine)
        {
            lines.Add(newLine);
        }

        /// <summary>
        /// Remove line
        /// </summary>
        /// <param name="line"> Removed line </param>
        private void RemoveLine(Line line)
        {
            lines.Remove(line);
        }

        /// <summary>
        /// Draw all lines
        /// </summary>
        /// <param name="e"></param>
        public void Draw(PaintEventArgs e)
        {
            foreach (var item in lines)
            {
                item.Draw(e);
            }
        }

        /// <summary>
        /// Remove the nearest line to the given point
        /// </summary>
        /// <param name="point"> point </param>
        /// <returns> 1 - if such line exists, 0 - otherwise </returns>
        public bool RemoveLine(System.Drawing.PointF point)
        {
            foreach (var item in lines)
            {
                if (item.Distance(point) < pxConst)
                {
                    RemoveLine(item);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Count distance between 2 points
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns> Counted distance </returns>
        private double DistanceBetweenPoints(System.Drawing.PointF first, System.Drawing.PointF second)
        {
            return Math.Sqrt(Math.Pow(first.X - second.X, 2) + Math.Pow(first.Y - second.Y, 2));
        }

        /// <summary>
        /// Find line that was dragged by user and return its not dragged end
        /// </summary>
        /// <param name="point"> dragged point </param>
        /// <returns> not dragged line end </returns>
        public System.Drawing.PointF FindNotDraggedLineEnd(System.Drawing.PointF point)
        {
            foreach (var item in lines)
            {
                if (DistanceBetweenPoints(item.Beginning, point) < pxConst)
                {
                    var temp = item.End;
                    RemoveLine(item);
                    return temp;
                }
                else if (DistanceBetweenPoints(item.End, point) < pxConst)
                {
                    var temp = item.Beginning;
                    RemoveLine(item);
                    return temp;
                }
            }
            return new System.Drawing.PointF();
        }
    }
}
