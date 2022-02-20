using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sierpinski_triangle_generator
{
    public partial class Form1 : Form
    {

        private int iter = 1;
        public Form1()
        {
            InitializeComponent();
        }
        override
    protected void OnPaint(PaintEventArgs e)
        {
            RectangleF border = e.Graphics.VisibleClipBounds;
            PointF p1 = new PointF(border.X, border.Y);
            PointF p2 = new PointF(border.X + border.Width, border.Y);
            PointF p3 = new PointF(border.X + border.Width / 2, border.Y + border.Height);
            PointF[] pArr = { p1, p2, p3 };
            SierpinskiTriangle(e.Graphics, Brushes.Purple, pArr, iter);
        }
        private void SierpinskiTriangle(Graphics g, Brush brush, PointF[] points, int iteration)
        {
            if (iteration == 1)
            {
                g.FillPolygon(brush, points);
            }
            else if (iteration > 1)
            {
                iteration--;
                PointF[] tri1 = {
                new PointF(points[0].X, points[0].Y),
                new PointF( (points[0].X + points[1].X) / 2, (points[0].Y + points[1].Y) / 2 ),
                new PointF( (points[0].X + points[2].X) / 2, (points[0].Y + points[2].Y) / 2 )
            };

                PointF[] tri2 = {
                new PointF(points[1].X, points[1].Y),
                new PointF( (points[0].X + points[1].X) / 2, (points[0].Y + points[1].Y) / 2 ),
                new PointF( (points[2].X + points[1].X) / 2, (points[2].Y + points[1].Y) / 2 )
            };

                PointF[] tri3 = {
                new PointF(points[2].X, points[2].Y),
                new PointF( (points[2].X + points[1].X) / 2, (points[2].Y + points[1].Y) / 2 ),
                new PointF( (points[2].X + points[0].X) / 2, (points[2].Y + points[0].Y) / 2 )
            };

                SierpinskiTriangle(g, brush, tri1, iteration);
                SierpinskiTriangle(g, brush, tri2, iteration);
                SierpinskiTriangle(g, brush, tri3, iteration);
            }
        }

        override
        protected void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                this.iter++;
                this.Refresh();
            }
            else if (e.KeyCode == Keys.Down && iter > 1)
            {
                this.iter--;
                this.Refresh();
            }
        }
    }


}
