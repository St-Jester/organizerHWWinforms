using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Organizer
{
    public partial class Form1 : Form
    {
       //Animation variables

        int x;
        int y;
        Point p;

        //AlarmClock Variables
        int H = 0, M = 0, S = 0, timeleft;

        //taskListVariables
       


        private void button3_Click(object sender, EventArgs e)
        {
            H = Convert.ToInt32(Hour.Value);
            M = Convert.ToInt32(minute.Value);
            S = Convert.ToInt32(Second.Value);

           timeleft =  SecondsTillAllrm();

            timer1.Start();
            MessageBox.Show($"{timeleft}");
        }
        private int SecondsTillAllrm()
        {
            int inSeconds = S + M * 60 + H * 3600;
            int inSecondsCurrent = DateTime.Now.Second + DateTime.Now.Minute * 60 + DateTime.Now.Hour * 3600;

            return inSeconds - inSecondsCurrent;
        }
        public Form1()
        {
            InitializeComponent();
            x = pictureBox1.ClientRectangle.Width / 2;
            y = pictureBox1.ClientRectangle.Height / 2;
            p = new Point(x, y);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            
            if(f.ShowDialog() == DialogResult.OK)
            {
                comboBox1.Items.Add(f.taskTitle);
                //textBox1.Text = f.taskinfo;
            }
        }

        private void DisplayTime(Graphics g)
        {
            int s = DateTime.Now.Second;
            int m = DateTime.Now.Minute;
            int h = DateTime.Now.Hour;

            float a1 = (float)s * 6;
            float a2 = ((float)m + (float)s / 60) * 6;
            float a3 = ((float)h + (float)m / 60 +
                (float)s / 3600) * 30;

            Matrix M = new Matrix();
            M.RotateAt(a1, p);
            g.Transform = M;
            g.DrawLine(new Pen(Color.Red, 3), x, 
                y - 180, x, 220);

            M.Reset();
            M.RotateAt(a2, p);
            g.Transform = M;
            g.DrawLine(new Pen(Color.Green, 5), x, 
                y - 150, x, 220);

            M.Reset();
            M.RotateAt(a3, p);
            g.Transform = M;
            g.DrawLine(new Pen(Color.Blue, 7), x, y - 140, x, 220);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();

            if (timeleft > 0)
                timeleft = timeleft - 1;
            else
            {
                timer1.Stop();
                MessageBox.Show("Alarm Clock Activated");
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            DisplayTime(e.Graphics);
        }
    }
}
