using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace MouseClickerforReal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        [DllImport("user32")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtrainfo);
        private const int mouseeventf_leftdown = 0x02;
        private const int mouseeventf_leftup = 0x04;
        



        private void Form1_Load(object sender, EventArgs e)
        { 
        }
        int keeptime = 0;
        int clickTime = 0;
        private void btn_start_Click(object sender, EventArgs e)
        {
            
                timer1.Start();
               // timer3.Start(); 
           

        }
        bool intro = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            keeptime++;
            
            
            if (keeptime % 600 == 0)
            {
                timer3.Start();
                intro = true;
            }
            if (intro == true)
            {
                clickTime++;

            }

            label1.Text = keeptime.ToString();
           
        }
        
        public void PerformClick(int x, int y)
        {
            
            
            Application.DoEvents();
            mouse_event(mouseeventf_leftdown, x, y, 0, 0);
            mouse_event(mouseeventf_leftup, x, y, 0, 0);


        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
            keeptime = 0;
            clickTime = 0;
           
        }
        
        private void timer2_Tick(object sender, EventArgs e)
        {  

           
        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }
        
        private void timer3_Tick(object sender, EventArgs e)
        {
            
            PerformClick(MousePosition.X, MousePosition.Y);
            if(clickTime %100 == 0)
            {
                timer3.Stop();
                keeptime = 0;
                clickTime = 0;
            }

        }

        private bool OnKeyPress(Keys escape)
        {
            throw new NotImplementedException();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
        }
    }
}
