using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Krajcovic_Matej
{
    public partial class MainForm_EN : Form
    {
        private bool draggingPoint = false; // Variable for moving point P  
        private PointF lastValidPoint;
        private string draggedLabel = "";  // Variable for moving  

        // Declare NumericUpDown controls
        private Panel panelCanvas_1;
        private Label lbl_result;

        public MainForm_EN()
        {
            InitializeComponent();
            // Automatic update when values change in NumericUpDown  
            foreach (var num in new NumericUpDown[] { AX_1, AY_1, BX_1, BY_1, CX_1, CY_1, DX_1, DY_1, PX_1, PY_1 })
            {
                num.ValueChanged += (s, e) => panelCanvas_1.Invalidate();
            }

            // Attach events to panelCanvas  
            panelCanvas_1.Paint += panelCanvas_Paint;
            panelCanvas_1.MouseDown += panelCanvas_MouseDown;
            panelCanvas_1.MouseMove += panelCanvas_MouseMove;
            panelCanvas_1.MouseUp += panelCanvas_MouseUp;
        }


        private void panelCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (!ValidateUniquePoints() || !ValidateSquareArea()) return;

            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Blue, 2);
            Brush brush = Brushes.Green;
            Brush blueBrush = Brushes.Blue;
            Font font = new Font("Arial", 12, FontStyle.Bold);
            Brush textBrush = Brushes.Black;

            try
            {
                // Load square points
                PointF[] points = {
                        new PointF((float)AX_1.Value, (float)AY_1.Value),
                        new PointF((float)BX_1.Value, (float)BY_1.Value),
                        new PointF((float)CX_1.Value, (float)CY_1.Value),
                        new PointF((float)DX_1.Value, (float)DY_1.Value),
                        new PointF((float)AX_1.Value, (float)AY_1.Value)
                    };

                // Draw the square
                g.DrawPolygon(pen, points);

                // Draw vertices ABCD and their labels
                string[] labels = { "A", "B", "C", "D" };
                for (int i = 0; i < 4; i++)
                {
                    g.FillEllipse(blueBrush, points[i].X - 3, points[i].Y - 3, 6, 6);
                    g.DrawString(labels[i], font, textBrush, points[i].X + 5, points[i].Y - 20);
                }

                // Load point P
                float pointPX = (float)PX_1.Value;
                float pointPY = (float)PY_1.Value;

                // Draw point P
                g.FillEllipse(brush, pointPX - 3, pointPY - 3, 6, 6);

                // Determine the position of the point and update the CheckBoxes
                string result = CheckPointPosition(new PointF(pointPX, pointPY), points);
                UpdateCheckBoxes(result);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while drawing: " + ex.Message);  // If inputs are incorrect, do not redraw
            }
        }


        // moving by mouse

        private void panelCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            PointF[] points = {
                    new PointF((float)AX_1.Value, (float)AY_1.Value),
                    new PointF((float)BX_1.Value, (float)BY_1.Value),
                    new PointF((float)CX_1.Value, (float)CY_1.Value),
                    new PointF((float)DX_1.Value, (float)DY_1.Value),
                    new PointF((float)PX_1.Value, (float)PY_1.Value)
                };
            string[] labels = { "A", "B", "C", "D", "P" };
            NumericUpDown[] numericControls = { AX_1, AY_1, BX_1, BY_1, CX_1, CY_1, DX_1, DY_1, PX_1, PY_1 };

            for (int i = 0; i < points.Length; i++)
            {
                if (Math.Abs(e.X - points[i].X) < 10 && Math.Abs(e.Y - points[i].Y) < 10)
                {
                    draggingPoint = true;
                    lastValidPoint = points[i];
                    draggedLabel = labels[i];
                    panelCanvas_1.Cursor = Cursors.Hand;
                    return;
                }
            }
        }

        private void panelCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            bool hoveringOverPoint = false;
            PointF[] points = {
                    new PointF((float)AX_1.Value, (float)AY_1.Value),
                    new PointF((float)BX_1.Value, (float)BY_1.Value),
                    new PointF((float)CX_1.Value, (float)CY_1.Value),
                    new PointF((float)DX_1.Value, (float)DY_1.Value),
                    new PointF((float)PX_1.Value, (float)PY_1.Value)
                };

            for (int i = 0; i < points.Length; i++)
            {
                if (Math.Abs(e.X - points[i].X) < 10 && Math.Abs(e.Y - points[i].Y) < 10)
                {
                    panelCanvas_1.Cursor = Cursors.Hand;
                    hoveringOverPoint = true;
                    break;
                }
            }

            if (!hoveringOverPoint)
                panelCanvas_1.Cursor = Cursors.Default;

            if (draggingPoint)
            {
                int newX = Math.Max(0, Math.Min(450, e.X));
                int newY = Math.Max(0, Math.Min(450, e.Y));

                switch (draggedLabel)
                {
                    case "A": AX_1.Value = newX; AY_1.Value = newY; break;
                    case "B": BX_1.Value = newX; BY_1.Value = newY; break;
                    case "C": CX_1.Value = newX; CY_1.Value = newY; break;
                    case "D": DX_1.Value = newX; DY_1.Value = newY; break;
                    case "P": PX_1.Value = newX; PY_1.Value = newY; break;
                }
            }
        }

        private void panelCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!CheckPolygonValidity())
            {
                ShowErrorAndRevert(GetNumericUpDownBY_1Label(draggedLabel));
            }
            draggingPoint = false;
            panelCanvas_1.Cursor = Cursors.Default;
        }

        private void ShowErrorAndRevert(NumericUpDown num)
        {
            MessageBox.Show("Invalid position! The quadrilateral is not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            num.Value = (decimal)lastValidPoint.X;
        }

        private bool CheckPolygonValidity()
        {
            PointF[] points = {
                    new PointF((float)AX_1.Value, (float)AY_1.Value),
                    new PointF((float)BX_1.Value, (float)BY_1.Value),
                    new PointF((float)CX_1.Value, (float)CY_1.Value),
                    new PointF((float)DX_1.Value, (float)DY_1.Value)
                };
            // control if the points are not on one line
            if (FormsTriangle(points[0], points[1], points[2]) ||
                FormsTriangle(points[1], points[2], points[3]) ||
                FormsTriangle(points[2], points[3], points[0]) ||
                FormsTriangle(points[3], points[0], points[1]) ||
                FormsTriangle(points[0], points[2], points[3]) ||
                FormsTriangle(points[1], points[3], points[0]))
            {
                MessageBox.Show("The points form a triangle, not a quadrilateral!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return IsConvexQuadrilateral(points);
        }

        private bool FormsTriangle(PointF A, PointF B, PointF C)
        {
            float area = Math.Abs((A.X * (B.Y - C.Y) + B.X * (C.Y - A.Y) + C.X * (A.Y - B.Y)) / 2.0f);
            return area < 1e-3; // if the area is small, the points are on one straight line
        }

        private bool IsConvexQuadrilateral(PointF[] points)
        {
            // check if the quadrilateral is convex
            return !(DoLinesIntersect(points[0], points[1], points[2], points[3]) ||
                     DoLinesIntersect(points[1], points[2], points[3], points[0]) ||
                     DoLinesIntersect(points[2], points[3], points[0], points[1]) ||
                     DoLinesIntersect(points[3], points[0], points[1], points[2]));
        }

        // function to check if two lines intersect
        private bool DoLinesIntersect(PointF A, PointF B, PointF C, PointF D)
        {
            float d1 = Direction(C, D, A);
            float d2 = Direction(C, D, B);
            float d3 = Direction(A, B, C);
            float d4 = Direction(A, B, D);

            // check if the points are on different sides of the line
            if (((d1 > 0 && d2 < 0) || (d1 < 0 && d2 > 0)) &&
                ((d3 > 0 && d4 < 0) || (d3 < 0 && d4 > 0)))
                return true;

            // checking special cases
            if (d1 == 0 && OnSegment(C, D, A)) return true;
            if (d2 == 0 && OnSegment(C, D, B)) return true;
            if (d3 == 0 && OnSegment(A, B, C)) return true;
            if (d4 == 0 && OnSegment(A, B, D)) return true;

            return false;
        }

        // function to calculate the direction of the points
        private float Direction(PointF A, PointF B, PointF C)
        {
            return (C.X - A.X) * (B.Y - A.Y) - (C.Y - A.Y) * (B.X - A.X);
        }

        // function to check if the point is on the segment
        private bool OnSegment(PointF A, PointF B, PointF P)
        {
            return Math.Min(A.X, B.X) <= P.X && P.X <= Math.Max(A.X, B.X) &&
                   Math.Min(A.Y, B.Y) <= P.Y && P.Y <= Math.Max(A.Y, B.Y);
        }

        private NumericUpDown GetNumericUpDownBY_1Label(string label)
        {
            switch (label)
            {
                case "A": return AX_1;
                case "B": return BX_1;
                case "C": return CX_1;
                case "D": return DX_1;
                case "P": return PX_1;
                default: return null;
            }
        }

        // Calculating the position of point P relative to a quadrilateral
        private string CheckPointPosition(PointF P, PointF[] quad)
        {
            if (IsPointOnVertex(P, quad))
                return "The point is on the vertex of the quadrilateral.";

            // If the point is inside the square
            bool inside1 = IsPointInTriangle(P, quad[0], quad[1], quad[2]);
            bool inside2 = IsPointInTriangle(P, quad[2], quad[3], quad[0]);

            if (inside1 || inside2)
                return "The point is inside the quadrilateral.";

            // If a point lies on an edge
            for (int i = 0; i < 4; i++)
            {
                if (IsPointOnLine(P, quad[i], quad[(i + 1) % 4]))
                    return "The point is on the edge of the quadrilateral.";
            }

            return "The point is outside the quadrilateral.";
        }

        private bool IsPointOnVertex(PointF P, PointF[] quad)
        {
            foreach (var vertex in quad)
            {
                if (Math.Abs(P.X - vertex.X) < 1e-3 && Math.Abs(P.Y - vertex.Y) < 1e-3)
                    return true;
            }
            return false;
        }

        private bool ValidateUniquePoints()
        {
            List<PointF> points = new List<PointF>
                {
                    new PointF((float)AX_1.Value, (float)AY_1.Value),
                    new PointF((float)BX_1.Value, (float)BY_1.Value),
                    new PointF((float)CX_1.Value, (float)CY_1.Value),
                    new PointF((float)DX_1.Value, (float)DY_1.Value)
                };

            if (points.Distinct().Count() < 4)
            {
                MessageBox.Show("No two points can have the same coordinates!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool ValidateSquareArea()
        {
            float ax1 = (float)AX_1.Value, ay1 = (float)AY_1.Value;
            float bx1 = (float)BX_1.Value, by1 = (float)BY_1.Value;
            float cx1 = (float)CX_1.Value, cy1 = (float)CY_1.Value;
            float dx1 = (float)DX_1.Value, dy1 = (float)DY_1.Value;

            // Calculating content using determinants
            float area = 0.5f * Math.Abs(
                ax1 * by1 + bx1 * cy1 + cx1 * dy1 + dx1 * ay1 - (ay1 * bx1 + by1 * cx1 + cy1 * dx1 + dy1 * ax1));

            if (area < 1e-3) // A small area means that the points are on one straight line
            {
                MessageBox.Show("Point D cannot be calculated – points are on one line!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // Auxiliary functions for calculating the position of point P
        private bool IsPointInTriangle(PointF P, PointF A, PointF B, PointF C)
        {
            float Area(PointF p1, PointF p2, PointF p3)
            {
                return Math.Abs((p1.X * (p2.Y - p3.Y) +
                                 p2.X * (p3.Y - p1.Y) +
                                 p3.X * (p1.Y - p2.Y)) / 2.0f);
            }

            float A1 = Area(P, A, B);
            float A2 = Area(P, B, C);
            float A3 = Area(P, C, A);
            float TotalArea = Area(A, B, C);

            return Math.Abs((A1 + A2 + A3) - TotalArea) < 1e-6;
        }

        private void MainForm_EN_Load(object sender, EventArgs e)
        {

        }


        private bool IsPointOnLine(PointF P, PointF A, PointF B)
        {
            float d1 = Distance(A, P);
            float d2 = Distance(P, B);
            float d = Distance(A, B);

            // We will use a tolerance of 1 pixel.
            return Math.Abs((d1 + d2) - d) < 1.0f;
        }


        private float Distance(PointF A, PointF B)
        {
            return (float)Math.Sqrt(Math.Pow(B.X - A.X, 2) + Math.Pow(B.Y - A.Y, 2));
        }

        // Updating CheckBoxes based on point position

        private void UpdateCheckBoxes(string result)
        {
            // Setting background and text color according to the result
            lbl_result.Text = result;

            if (result == "The point is inside the quadrilateral.")
                lbl_result.BackColor = Color.Green;
            else if (result == "The point is outside the quadrilateral.")
                lbl_result.BackColor = Color.Red;
            else if (result == "The point is on the edge of the quadrilateral.")
                lbl_result.BackColor = Color.Orange;
            else if (result == "The point is on the vertex of the quadrilateral.")
                lbl_result.BackColor = Color.Blue;
            else
                lbl_result.BackColor = SystemColors.Control;
        }

        private void P_out_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.ShowDialog();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Info info = new Info();
            info.ShowDialog();
        }

        private void panelCanvas_Resize(object sender, EventArgs e)
        {
            panelCanvas_1.Size = new Size(this.ClientSize.Width - 20, this.ClientSize.Height - 100);
        }

        private void slovakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main mainForm = new Main();
            mainForm.Show();
            this.Hide();
        }

        private void MainForm_EN_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}