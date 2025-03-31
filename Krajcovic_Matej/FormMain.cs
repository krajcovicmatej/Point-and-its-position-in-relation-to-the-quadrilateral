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
    public partial class Main : Form
    {
        private bool draggingPoint = false; // Variable for moving point P  
        private PointF lastValidPoint;
        private string draggedLabel = "";  // Variable for moving  

        public Main()
        {
            InitializeComponent();
            // Automatic update when values change in NumericUpDown  
            foreach (var num in new NumericUpDown[] { AX, AY, BX, BY, CX, CY, DX, DY, PX, PY })
            {
                num.ValueChanged += (s, e) => panelCanvas.Invalidate();
            }

            // Attach events to panelCanvas  
            panelCanvas.Paint += panelCanvas_Paint;
            panelCanvas.MouseDown += panelCanvas_MouseDown;
            panelCanvas.MouseMove += panelCanvas_MouseMove;
            panelCanvas.MouseUp += panelCanvas_MouseUp;
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
                    new PointF((float)AX.Value, (float)AY.Value),
                    new PointF((float)BX.Value, (float)BY.Value),
                    new PointF((float)CX.Value, (float)CY.Value),
                    new PointF((float)DX.Value, (float)DY.Value),
                    new PointF((float)AX.Value, (float)AY.Value)
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
                float px = (float)PX.Value;
                float py = (float)PY.Value;

                // Draw point P
                g.FillEllipse(brush, px - 3, py - 3, 6, 6);

                // Determine the position of the point and update the CheckBoxes
                string result = CheckPointPosition(new PointF(px, py), points);
                UpdateCheckBoxes(result);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Chyba pri kreslení: " + ex.Message);  // If inputs are incorrect, do not redraw
            }
        }


        // moving by mouse
        private void panelCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            PointF[] points = {
                new PointF((float)AX.Value, (float)AY.Value),
                new PointF((float)BX.Value, (float)BY.Value),
                new PointF((float)CX.Value, (float)CY.Value),
                new PointF((float)DX.Value, (float)DY.Value),
                new PointF((float)PX.Value, (float)PY.Value)
            };
            string[] labels = { "A", "B", "C", "D", "P" };
            NumericUpDown[] numericControls = { AX, AY, BX, BY, CX, CY, DX, DY, PX, PY };

            for (int i = 0; i < points.Length; i++)
            {
                if (Math.Abs(e.X - points[i].X) < 10 && Math.Abs(e.Y - points[i].Y) < 10)
                {
                    draggingPoint = true;
                    lastValidPoint = points[i];
                    draggedLabel = labels[i];
                    panelCanvas.Cursor = Cursors.Hand;
                    return;
                }
            }
        }

        private void panelCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            bool hoveringOverPoint = false;
            PointF[] points = {
                new PointF((float)AX.Value, (float)AY.Value),
                new PointF((float)BX.Value, (float)BY.Value),
                new PointF((float)CX.Value, (float)CY.Value),
                new PointF((float)DX.Value, (float)DY.Value),
                new PointF((float)PX.Value, (float)PY.Value)
            };

            for (int i = 0; i < points.Length; i++)
            {
                if (Math.Abs(e.X - points[i].X) < 10 && Math.Abs(e.Y - points[i].Y) < 10)
                {
                    panelCanvas.Cursor = Cursors.Hand;
                    hoveringOverPoint = true;
                    break;
                }
            }

            if (!hoveringOverPoint)
                panelCanvas.Cursor = Cursors.Default;

            if (draggingPoint)
            {
                int newX = Math.Max(0, Math.Min(450, e.X));
                int newY = Math.Max(0, Math.Min(450, e.Y));

                switch (draggedLabel)
                {
                    case "A": AX.Value = newX; AY.Value = newY; break;
                    case "B": BX.Value = newX; BY.Value = newY; break;
                    case "C": CX.Value = newX; CY.Value = newY; break;
                    case "D": DX.Value = newX; DY.Value = newY; break;
                    case "P": PX.Value = newX; PY.Value = newY; break;
                }
            }
        }

        private void panelCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!CheckPolygonValidity())
            {
                ShowErrorAndRevert(GetNumericUpDownByLabel(draggedLabel));
            }
            draggingPoint = false;
            panelCanvas.Cursor = Cursors.Default;
        }

        private void ShowErrorAndRevert(NumericUpDown num)
        {
            MessageBox.Show("Neplatná pozícia! Štvoruholník nie je platný.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            num.Value = (decimal)lastValidPoint.X;
        }

        private bool CheckPolygonValidity()
        {
            PointF[] points = {
                new PointF((float)AX.Value, (float)AY.Value),
                new PointF((float)BX.Value, (float)BY.Value),
                new PointF((float)CX.Value, (float)CY.Value),
                new PointF((float)DX.Value, (float)DY.Value)
            };

            // control if the points are not on one line
            if (FormsTriangle(points[0], points[1], points[2]) ||
                FormsTriangle(points[1], points[2], points[3]) ||
                FormsTriangle(points[2], points[3], points[0]) ||
                FormsTriangle(points[3], points[0], points[1]) ||
                FormsTriangle(points[0], points[2], points[3]) ||
                FormsTriangle(points[1], points[3], points[0]))
            {
                MessageBox.Show("Body tvoria trojuholník, nie štvoruholník!", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return IsConvexQuadrilateral(points);
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

        private NumericUpDown GetNumericUpDownByLabel(string label)
        {
            switch (label)
            {
                case "A": return AX;
                case "B": return BX;
                case "C": return CX;
                case "D": return DX;
                case "P": return PX;
                default: return null;
            }
        }

        // Calculating the position of point P relative to a quadrilateral
        private string CheckPointPosition(PointF P, PointF[] quad)
        {
            if (IsPointOnVertex(P, quad))
                return "Bod sa nachádza na vrchole štvoruholníka.";

            // If the point is inside the square
            bool inside1 = IsPointInTriangle(P, quad[0], quad[1], quad[2]);
            bool inside2 = IsPointInTriangle(P, quad[2], quad[3], quad[0]);

            if (inside1 || inside2)
                return "Bod je vo vnútri štvoruholníka.";

            // If a point lies on an edge
            for (int i = 0; i < 4; i++)
            {
                if (IsPointOnLine(P, quad[i], quad[(i + 1) % 4]))
                    return "Bod leží na hrane štvoruholníka.";
            }

            return "Bod je mimo štvoruholníka.";
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
                new PointF((float)AX.Value, (float)AY.Value),
                new PointF((float)BX.Value, (float)BY.Value),
                new PointF((float)CX.Value, (float)CY.Value),
                new PointF((float)DX.Value, (float)DY.Value)
            };

            if (points.Distinct().Count() < 4)
            {
                MessageBox.Show("Žiadne dva body nemôžu mať rovnaké súradnice!", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private bool ValidateSquareArea()
        {
            float ax = (float)AX.Value, ay = (float)AY.Value;
            float bx = (float)BX.Value, by = (float)BY.Value;
            float cx = (float)CX.Value, cy = (float)CY.Value;
            float dx = (float)DX.Value, dy = (float)DY.Value;

            // Calculating content using determinants
            float area = 0.5f * Math.Abs(
                ax * by + bx * cy + cx * dy + dx * ay - (ay * bx + by * cx + cy * dx + dy * ax));

            if (area < 1e-3) // A small area means that the points are on one straight line
            {
                MessageBox.Show("Bod D nemôže byť vypočítaný – body sú na jednej priamke!", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private bool FormsTriangle(PointF A, PointF B, PointF C)
        {
            float area = Math.Abs((A.X * (B.Y - C.Y) + B.X * (C.Y - A.Y) + C.X * (A.Y - B.Y)) / 2.0f);
            return area < 1e-3; // if the area is small, the points are on one straight line
        }


        //Auxiliary functions for calculating the position of point P
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

            if (result == "Bod je vo vnútri štvoruholníka.")
                lbl_result.BackColor = Color.Green;
            else if (result == "Bod je mimo štvoruholníka.")
                lbl_result.BackColor = Color.Red;
            else if (result == "Bod leží na hrane štvoruholníka.")
                lbl_result.BackColor = Color.Orange;
            else if (result == "Bod sa nachádza na vrchole štvoruholníka.")
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

        private void návodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nápoveda napoveda = new Nápoveda();
            napoveda.ShowDialog();
        }

        private void informácieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            info_sk info = new info_sk();
            info.ShowDialog();
        }

        private void panelCanvas_Resize(object sender, EventArgs e)
        {
            panelCanvas.Size = new Size(this.ClientSize.Width - 20, this.ClientSize.Height - 100);
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {


            MainForm_EN englishForm = new MainForm_EN();
            englishForm.Show();
            this.Hide();

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void Inputs_Enter(object sender, EventArgs e)
        {

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}



