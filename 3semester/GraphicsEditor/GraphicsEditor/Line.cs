using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GraphicsEditorNamespace
{
    /// <summary>
    /// Line class
    /// </summary>
    class Line
    {
        /// <summary>
        /// Constructs a line by 2 given points
        /// </summary>
        /// <param name="beginning"></param>
        /// <param name="end"></param>
        public Line(PointF beginning, PointF end)
        {
            this.Beginning = beginning;
            this.End = end;
        }

        /// <summary>
        /// Draw line on picture box
        /// </summary>
        /// <param name="e"></param>
        public void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(System.Drawing.Color.Blue, 3), Beginning, End);
        }

        private double DistanceBetweenPoints (PointF first, PointF second)
        {
            return Math.Sqrt(Math.Pow(first.X - second.X, 2) + Math.Pow(first.Y - second.Y, 2));
        }

        /// <summary>
        /// Distance between line and the given point
        /// </summary>
        /// <param name="point"></param>
        /// <returns> counted distance </returns>
        public double Distance(PointF point)
        {
            var maxX = Math.Max(Beginning.X, End.X);
            var maxY = Math.Max(Beginning.Y, End.Y);
            var minX = Math.Min(Beginning.X, End.X);
            var minY = Math.Min(Beginning.Y, End.Y);

            if (maxX < point.X && maxY < point.Y)
            {
                return Math.Min(DistanceBetweenPoints(Beginning, point), DistanceBetweenPoints(End, point));
            }
            else if (maxX > point.X && minY > point.Y)
            {
                return Math.Min(DistanceBetweenPoints(Beginning, point), DistanceBetweenPoints(End, point));
            }
            else if (minX > point.X && maxY < point.Y)
            {
                return Math.Min(DistanceBetweenPoints(Beginning, point), DistanceBetweenPoints(End, point));
            }
            else if (minX > point.X && minY > point.Y)
            {
                return Math.Min(DistanceBetweenPoints(Beginning, point), DistanceBetweenPoints(End, point));
            }

            double A = (Beginning.Y - End.Y);
            double B = (End.X - Beginning.X);
            double C = (End.Y - Beginning.Y) * Beginning.X + (Beginning.X - End.X) * Beginning.Y;
            return Math.Abs(A * point.X + B * point.Y + C) / (Math.Sqrt(A * A + B * B));
        }

        public PointF Beginning { get; set; }
        public PointF End { get; set; }
    }
}
