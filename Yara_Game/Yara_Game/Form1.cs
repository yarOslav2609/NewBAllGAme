using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yara_Game
{
    public partial class Form1 : Form
    {
        public Bitmap Wall = Resource1.Wall;
        public Bitmap Block = Resource1.Без_названия;
        Field Matrix = new Field();
        Ball Ball = new Ball(3, 3, 'R');
        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint, true);

            UpdateStyles();
            Matrix.generate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Graphics b = e.Graphics;
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 22; j++)
                {
                    if (i == 0 || j == 0 || j == 21 || i == 11)
                        g.DrawImage(Wall, j * 40, i * 40, 40, 40);
                    else g.DrawImage(Block, j * 40, i * 40, 40, 40);
                }
            }
            b.DrawImage(Resource1.ball, Ball.X * 40, Ball.Y * 40, 40, 40);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Rectangle rc1 = new Rectangle(new Point(Ball.X * 40, Ball.Y * 40), new Size(40, 40));
            Invalidate(rc1);
            Ball.Move(Matrix, Ball);
            Rectangle rc = new Rectangle(new Point(Ball.X * 40, Ball.Y * 40), new Size(40, 40));
            Invalidate(rc);
            Update();
        }
    }
}
