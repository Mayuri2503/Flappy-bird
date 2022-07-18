using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flappy_bird1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int gravity = 10;
        int speed = 25;
        int score = 0;

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                gravity = 20;

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                gravity = -20;
            else if (e.KeyCode == Keys.Enter)
                timer1.Start();

        }
        Random rnd = new Random();

        private void timer1_Tick(object sender, EventArgs e)
        {
            bird.Top += gravity;
            pipedown.Left -= speed;
            pipeup.Left -= speed;
            weather.Left -= speed;
            lblScore.Text = $"Score:{score}";
            if (pipedown.Left < -170)
            {
                pipedown.Left = rnd.Next(100,400);
                score++;
            }
            if (pipeup.Left < -170)
            {
                int top= rnd.Next(300,500);
                pipeup.Left = top;
                weather.Left = rnd.Next(top + 50, 800);
                score++;

            }
            if (bird.Bounds.IntersectsWith(pipedown.Bounds) || bird.Bounds.IntersectsWith(pipeup.Bounds) || bird.Bounds.IntersectsWith(ground.Bounds))
                {
                timer1.Stop();
                lblScore.Text += "Game Over !!!";
            }
            if (score > 10)
                speed += 5;
        }
    }
}
