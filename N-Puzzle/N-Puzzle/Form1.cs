using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N_Puzzle
{
    public partial class Form1 : Form
    {
        List<Pole> pole = new List<Pole>();
        Random r = new Random();
        int[,] mat ;
        public int X { get; set; }
        public int Y { get; set; }
        public int N { get; set; }
        public int M { get; set; }
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            //game();
        }

        private void game()
        {
            X = 0;
            Y = 24;
            List<int> list = new List<int>();
            int br = 0, j = 0, k = 0;
            clear();
            for (int i = 0; i < N; i++)
                list.Add(i);

            for (int i = 0; i < N; i++, br++, k++)
            {
                if (M == 4)
                {
                    if (br == 4)
                    {
                        X = 0;
                        Y = 100;
                        k = 0;
                        j++;
                    }
                    if (br == 8)
                    {
                        X = 0;
                        Y = 176;
                        k = 0;
                        j++;
                    }
                    if (br == 12)
                    {
                        X = 0;
                        Y = 252;
                        k = 0;
                        j++;
                    }
                }
                else
                {
                    if (br == 3)
                    {
                        X = 0;
                        Y = 100;
                        k = 0;
                        j++;
                    }
                    if (br == 6)
                    {
                        X = 0;
                        Y = 176;
                        k = 0;
                        j++;
                    }

                }
                StringBuilder s = new StringBuilder(@"C:\Users\Vladimir\Documents\GitHub\N-Puzzle\N-Puzzle\N-Puzzle\Images\#.png");
                StringBuilder s1 = new StringBuilder(@"C:\Users\Vladimir\Documents\GitHub\N-Puzzle\N-Puzzle\N-Puzzle\Images\##.png");
                int n = r.Next(list.Count);
                int m = list[n];
                mat[j, k] = m;
                list.RemoveAt(n);
                if (m > 9)
                {
                    s1[69] = (char)(49);
                    s1[70] = (char)(m % 10 + 48);
                    s = s1;
                }
                else
                    s[69] = (char)(m + 48);
                Image sl = Image.FromFile(s.ToString());
                Pole p = new Pole(m, X, Y, 83, 76, sl);
                pole.Add(p);
                X += 83;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Gray);
            crtaj(e.Graphics);
        }

        private void crtaj(Graphics gr)
        {
            foreach (Pole p in pole)
            {
                gr.DrawImage(p.Slika, p.X, p.Y, p.Width, p.Height);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            int x = e.X, y = e.Y, n = 0, i = 0, j = 0, a = 0, b = 0;
            X = 83;
            Y = 100;
            //MessageBox.Show("" + x +" "+ y);
            for (i = 0; i < M; i++)
            {
                for (j = 0; j < M; j++)
                {
                    if (X - x <= 83 && X - x >= 0 && Y - y <= 76 && Y - Y >= 0)
                    {
                        a = i; b = j;
                        n = mat[i, j];
                        break;
                    }
                    X += 83;
                }
                X = 83;
                Y += 76;
            }
            if (sosedi(a, b) == 1)
            {
                for (i = 0; i < M; i++)
                {
                    for (j = 0; j < M; j++)
                    {
                        if (mat[i, j] == 0)
                        {
                            int tmp = mat[i, j];
                            mat[i, j] = mat[a, b];
                            mat[a, b] = tmp;
                        }
                    }
                }
                int p1 = find(n);
                int p2 = find(0);
                swap(pole[p1], pole[p2]);
            }
            Invalidate();
            if (proveri())
                MessageBox.Show("Честитки");
        }

        private int sosedi(int i, int j)
        {
            if (i - 1 >= 0)
                if (mat[i - 1, j] == 0)
                    return 1;
            if (i + 1 < M)
                if (mat[i + 1, j] == 0)
                    return 1;
            if (j - 1 >= 0)
                if (mat[i, j - 1] == 0)
                    return 1;
            if (j + 1 < M)
                if (mat[i, j + 1] == 0)
                    return 1;
            return -1;
        }

        private int find(int n)
        {
            for (int i = 0; i < pole.Count; i++)
            {
                if (pole[i].Broj == n)
                    return i;
            }
            return -1;
        }

        private void swap(Pole p1, Pole p2)
        {
            int tmp = p1.X;
            p1.X = p2.X;
            p2.X = tmp;
            tmp = p1.Y;
            p1.Y = p2.Y;
            p2.Y = tmp;
        }

        private bool proveri()
        {
            int br = 1;
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < M; j++, br++)
                {
                    if (br == N)
                        break;
                    if (mat[i, j] != br)
                        return false;
                }
            }
            return true;
        }

        private void clear()
        {
            pole = new List<Pole>();
            mat = new int[M, M];
        }

        private void x3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Size = new Size(265, 291);
            x3ToolStripMenuItem.Checked = true;
            x4ToolStripMenuItem.Checked = false;
            N = 9;
            M = 3;
            game();
            Invalidate();
            //MessageBox.Show("" + M + " " + N);
        }

        private void x4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Size = new Size(348, 367);
            x4ToolStripMenuItem.Checked = true;
            x3ToolStripMenuItem.Checked = false;
            N = 16;
            M = 4;
            game();
            Invalidate();
            //MessageBox.Show("" + M + " " + N);
             
        }

        private void излезToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Дали сте сигурни?","Излез",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
            if(DialogResult == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }
    }
}
