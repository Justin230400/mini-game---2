using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Init();
            Init1();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            GameReStart();//重玩
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int x0 = 20;
            int y0 = 20;
            for (int i = 0; i < N + 1; i++)
            {
                g.DrawLine(pen1, x0, y0 + i * WW, x0 + N * WW, y0 + i * WW);
            }

            for (int i = 0; i < N + 1; i++)
            {
                g.DrawLine(pen1, x0 + i * WW, y0, x0 + i * WW, y0 + N * WW);
            }

            int stringX = 70;
            int stringY = 20;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Font font = font1;
                    int temp = data[i * N + j];
                    if (temp <= 8)
                    {
                        stringX = 70;
                        stringY = 20;
                        font = font1;
                    }
                    else if (temp <= 64)
                    {
                        stringX = 70;
                        stringY = 25;
                        font = font2;
                    }
                    else if (temp <= 512)
                    {
                        stringX = 70;
                        stringY = 40;
                        font = font3;
                    }
                    else
                    {
                        stringX = 70;
                        stringY = 50;
                        font = font4;
                    }
                    g.DrawString("" + data[i * N + j], font, brush2, stringX + j * WW, stringY + i * WW, stringFormat);
                }
            }
        }

        bool Check(char c)
        {
            bool b_Check = true;
            int temp = 0;

            int startI = 0;
            int startJ = 0;
            int endI = N;
            int endJ = N - 1;

            if(c == 'L')
            {

            }
            else if (c == 'R')
            {
                startI = 0;
                startJ = 0;
                endI = N;
                endJ = N - 1;
            }
            else if(c == 'U')
            {
                
            }
            else if(c == 'D')
            {

            }

            for (int i = startI; i < endI; i++) //y
            {
                for (int j = startJ; j < endJ; j++) //x
                {
                    if (data[i * N + j] == 0)
                    {
                        continue;
                    }

                    if (data[i * N + j] != temp)
                    {
                        temp = data[i * N + j];
                    }
                }
            }

            return b_Check;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                DoLeft();
            }
            else if (e.KeyCode == Keys.Right)
            {
                DoRight();
            }
            else if (e.KeyCode == Keys.Up)
            {
                DoUp();
            }
            else if (e.KeyCode == Keys.Down)
            {
                DoDown();
            }
        }
    }
}
