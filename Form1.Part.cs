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
    public partial class Form1
    {
        int WW = 80;
        int WW2 = 50;  // WW / 2;
        int N = 4;
        int N2 = 16; //N2=N*N
        int score = 0;
        int[] data;
        Pen pen1;
        Brush brush1, brush2;
        Font font1, font2, font3, font4;
        StringFormat stringFormat;
        bool flag = false;

        void Init()
        {
            pen1 = new Pen(Color.Black, 3);
            N = 4;
            N2 = N * N;
            WW = 100;
            WW2 = WW/2;
            data = new int[N * N];
            font1 = new Font("Arial", 70);
            font2 = new Font("Arial", 60);
            font3 = new Font("Arial", 40);
            font4 = new Font("Arial", 30);
            brush2 = new SolidBrush(Color.LightGreen);
            stringFormat = new System.Drawing.StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            //補你的程式碼....
        }
        void Init1()
        {
            SetData();
            score = 0;
            this.label1.Text = "分數:" + score;
            flag = false;
            //補你的程式碼....

        }
        void GameReStart()
        {
            Init1();
            this.Invalidate();
            //補你的程式碼....例如分數清零..資料清零..
        }
        void GameOver()
        {
            flag = true;
            MessageBox.Show("Game Over!");
            //補你的程式碼....跳出訊息視窗 說明遊戲結束..
        }
        void SetData()
        {
            //設定data初始值為0. 使用for迴圈
            for (int i = 0; i < N2; i++)
            {
                data[i] = 0;
            }
            //在data中  0的位置,  放一個2. 
            Generate2(data); //傳入一維陣列.. 
            Generate2(data);

        }
        Random random = new Random();
        void Generate2(int[] data1)
        {
            int k = 0;
            int cc = 0;  //cc : 記錄data1有幾個0 
            int[] arr1 = new int[N2]; //放data1值為0的index 位置.

            for (int i = 0; i < data1.Length; i++)
            {
                if (data1[i] != 0) continue;
                arr1[k] = i;
                k++;
            }
            //若k為0..則遊戲結束. 呼叫GameOver() 
            if (k == 0)
            {
                GameOver();
                return;
            }

            int k1 = random.Next(k); //從k個中 亂數挑一個
            int index = arr1[k1];
            data1[index] = 2;
            //int j = random.Next(2); //0,1
            //if (j == 0)
            //    data1[index] = 2;
           // else
             //   data1[index] = 4; 
        }
        void DoLeft()//靠左
        {
            int i, j, k, val;
            for (i = 0; i < N; i++)
            {  // 
               //當i=0時, 處理第0列資料
                k = 0;  //存有幾個非零數,  初始值設為0.
                for (j = 0; j < N; j++)
                {
                    if (data[i * N + j] == 0) continue;  //若為零. 則重頭開始. 
                    val = data[i * N + j];
                    data[i * N + j] = 0;
                    data[i * N + k] = val;  //0位置先放.
                    if (k > 0 && data[i * N + k - 1] == val)
                    {
                        data[i * N + k - 1] *= 2;
                        data[i * N + k] = 0;
                        score += val;
                        this.label1.Text = "分數:" + score;
                    }
                    else k++;
                }
            }
            Generate2(data);
            this.Invalidate();
        }
        void DoRight()//靠右
        {
            int i, j, k, val;
            for (i = 0; i < N; i++)
            {  // 
               //當i=0時, 處理第0列資料
                k = 0;  //存有幾個非零數,  初始值設為0.
                for (j = N - 1; j >= 0; j--)
                {
                    if (data[i * N + j] == 0) continue;  //若為零. 則重頭開始. 
                    val = data[i * N + j]; data[i * N + j] = 0;
                    data[i * N + N - 1 - k] = val;  //3位置 先放
                    if (k > 0 && data[i * N + N - k] == val)
                    {
                        data[i * N + N - k] *= 2;
                        data[i * N + N - 1 - k] = 0;
                        score += val;
                        this.label1.Text = "分數:" + score;
                    }
                    else k++;
                }
            }
            Generate2(data);
            this.Invalidate();
        }
        void DoUp()//往上
        {
            int i, j, k, val;
            for (j = 0; j < N; j++)
            {  // 
               //當j=0時, 處理第0行資料
                k = 0;  //存有幾個非零數,  初始值設為0.
                for (i = 0; i < N; i++)
                {
                    if (data[i * N + j] == 0) continue;  //若為零. 則重頭開始. 
                    val = data[i * N + j]; data[i * N + j] = 0;
                    data[k * N + j] = val; //0位置先放
                    if (k > 0 && data[(k - 1) * N + j] == val)
                    {
                        data[(k - 1) * N + j] *= 2;
                        data[k * N + j] = 0;
                        score += val;
                        this.label1.Text = "分數:" + score;
                    }
                    else k++;
                }
            }
            Generate2(data);
            this.Invalidate();
        }
        void DoDown()//往下
        {
            int i, j, k, val;

            for (j = 0; j < N; j++)
            {
                //當j=0時, 處理第0行資料
                k = 0;  //存有幾個非零數,  初始值設為0.
                for (i = N - 1; i >= 0; i--)
                {
                    if (data[i * N + j] == 0) continue;  //若為零. 則重頭開始. 
                    val = data[i * N + j]; data[i * N + j] = 0;
                    data[(N - 1 - k) * N + j] = val; //3位置先放 
                    if (k > 0 && data[(N - k) * N + j] == val)
                    {
                        data[(N - k) * N + j] *= 2;
                        data[(N - 1 - k) * N + j] = 0;
                        score += val;
                        this.label1.Text = "分數:" + score;
                    }
                    else k++;
                }
            }
            Generate2(data);
            this.Invalidate();
        }
    }

}
