using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using Pelotas.Properties;

namespace Pelotas
{
    public partial class Pelotas : Form
    {
        static List<Pelota> balls;
        static Bitmap bmp;
        static Graphics g;
        static Random rand = new Random();
        static float deltaTime;

        public Pelotas()
        {
            InitializeComponent();
        }

        private void Init()
        {
            if (PCT_CANVAS.Width == 0)
                return;

            balls       = new List<Pelota>();
            bmp         = new Bitmap(PCT_CANVAS.Width, PCT_CANVAS.Height);
            g           = Graphics.FromImage(bmp);
            deltaTime   = 1;
            PCT_CANVAS.Image = bmp;
            pictureBox1.Image = Resources.volcan3;
            pictureBox1.Location = new Point(650, 700);

            for (int b = 0; b < 50; b++)
                balls.Add(new Pelota(rand, PCT_CANVAS.Size, b));
        }

        private void Pelotas_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Pelotas_SizeChanged(object sender, EventArgs e)
        {
            Init();
        }

        private void TIMER_Tick(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            
            Parallel.For(0, balls.Count, b =>//ACTUALIZAMOS EN PARALELO
            {
                Pelota P;
                balls[b].Update(deltaTime, balls);
                P = balls[b];               
            });

            Pelota p;
            //Image newImage = Image.FromFile(Resources.volcan3);
            for (int b = 0; b < balls.Count; b++)//PINTAMOS EN SECUENCIA
            {
                p = balls[b];
                //g.FillEllipse(new SolidBrush(p.c), p.x - p.radio, p.y - p.radio, p.radio * 2, p.radio * 2);
                RectangleF srcRect = new RectangleF(10.0F, 10.0F, 160.0F, 160.0F);
                GraphicsUnit units = GraphicsUnit.Pixel;
                
                
                g.DrawImage(Resources.fuego_lava, p.x-p.radio, p.y - p.radio, srcRect, units);
                


            }

            PCT_CANVAS.Invalidate();
            deltaTime += .1f;
        }

        private void PCT_CANVAS_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_3(object sender, EventArgs e)
        {

        }
    }
}
