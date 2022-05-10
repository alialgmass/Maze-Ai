using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{

    public partial class Form1 : Form
    {
        public static int[,] mat = {{ 2, 0, 1, 1, 1, 0, 1, 1, 1, 1 },
                { 1, 0, 1, 0, 1, 0, 1, 0, 0, 1 },
                { 1, 1, 1, 0, 1, 0, 1, 0, 1, 1 },
                { 0, 0, 0, 0, 1, 0, 0, 0, 1, 1 },
                { 1, 1, 1, 0, 1, 1, 1, 1, 1, 1 },
                { 1, 0, 1, 1, 1, 1, 0, 1, 0, 0 },
                { 1, 0, 0, 0, 0, 1, 0, 0, 0, 1 },
                { 0, 1, 1, 1, 0, 1, 1, 1, 0, 1 },
                { 3, 1, 0, 1, 1, 1, 0, 1, 1, 1 } };
        public int x = 0;
        public int y = 0;
        public static Button[,] btn;
        public int howeverLongYouWantTheLoopToLast;
        unformed_search unf;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateMaze();
            colorMaze();
        }

        private void CreateMaze()
        {
            IEnumerable<Button> c = flowLayoutPanel1.Controls.OfType<Button>();
            Button[] b = c.ToArray();

            btn = new Button[9, 10];
            int num = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    btn[i, j] = b[num];
                    num++;
                  
                }
            }

        }
        private void colorMaze()
        {

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 10; j++)
                {

                    if (mat[i, j] == 0)
                    {
                        btn[i, j].BackColor = Color.Black;
                    }
                    else if (mat[i, j] == 1)
                    {
                        btn[i, j].BackColor = Color.White;
                    }
                    else if (mat[i, j] == 2)
                    {
                        btn[i, j].BackColor = Color.HotPink;
                    }
                    else if (mat[i, j] == 3)
                    {
                        btn[i, j].BackColor = Color.Pink;
                    }
                }
            }
        }
        void sucecc(int x)
        {
            if (x == 3)
            {
                MessageBox.Show("Good Jop");
                Application.Restart();
            }
        }
        private void button91_Click(object sender, EventArgs e)
        {//up
            if (y > 0 && mat[y - 1, x] != 0)
            {
                sucecc(mat[y - 1, x]);
                mat[y, x] = 1;
                y--;
                mat[y, x] = 2;
                colorMaze();
                
            }
        }

        private void button92_Click(object sender, EventArgs e)
        {//right
            if (x < 9 && mat[y, x + 1] != 0)
            {
                sucecc(mat[y, x + 1]);
                mat[y, x] = 1;
                x++;
                mat[y, x] = 2;
                colorMaze();
               
            }
        }

        private void button93_Click(object sender, EventArgs e)
        {
            //left
            if (x > 0 && mat[y, x - 1] != 0)
            {
                sucecc(mat[y, x - 1]);
                mat[y, x] = 1;
                x--;
                mat[y, x] = 2;
                colorMaze();
               
            }
        }

        private void button94_Click(object sender, EventArgs e)
        {
            //down
            if (y < 8 && mat[y + 1, x] != 0)
            {
                sucecc(mat[y + 1, x]);
                mat[y, x] = 1;
                y++;
                mat[y, x] = 2;
                colorMaze();
               
            }
        }

        private void button95_Click(object sender, EventArgs e)
        {

           unf  = new unformed_search();
            timer1.Start();
            howeverLongYouWantTheLoopToLast = unf.nods.Count();

            

        }
        int count = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (count < howeverLongYouWantTheLoopToLast)
            {
                Point p = unf.nods.Pop();
              btn[p.x,p.y].BackColor = Color.Red;
                count++;
                
            }
            else
            {
                timer1.Stop();
                sucecc(3);
                
            }
        }
    }
    }

    

    

    
