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

        Form2 f = new Form2();

        int[,] mat;
        int count = 0;
        int potezi = 0;

        public int X { get; set; }
        public int Y { get; set; }
        public int N { get; set; }
        public int M { get; set; }

        Timer t = new Timer();
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            t.Interval = 1000;
            t.Tick += new EventHandler(onTick);
            label1.Visible = false;
            label1.Text = "Изминато времe: 00:00:00";
            label2.Visible = false;
        }

        // Креирање на објекти(полиња)
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
                StringBuilder s = new StringBuilder(@f.str1);
                StringBuilder s1 = new StringBuilder(@f.str2);
                MessageBox.Show(f.str1 + "  " + f.str2);
                int n = r.Next(list.Count);
                int m = list[n];
                mat[j, k] = m;
                list.RemoveAt(n);
                if (m > 9)
                {
                    s1[16] = (char)(m % 10 + 48);
                    s = s1;
                }
                else
                    s[15] = (char)(m + 48);
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


        // Ги исцртува полињата на формата
        private void crtaj(Graphics gr)
        {
            foreach (Pole p in pole)
            {
                gr.DrawImage(p.Slika, p.X, p.Y, p.Width, p.Height);
            }
        }

        // Наоѓаме кое поле е кликнато и правиме замена ако има валиден потег
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
                potezi++;
            }
            Invalidate();
            label2.Text = "Потези: " + potezi;
            if (proveri())
            {
                t.Stop();
                MessageBox.Show("Честитки освоивте: " + (100000 / count) * (100 / potezi) + " поени");
            }
        }

        // Проверка дали кликнатото поле е сосед со празното поле, 1 -> Да, -1 -> Не
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

        // Пребарување елемент во листа, доколку е пронајден го враќа индексот, ако не -1
        private int find(int n)
        {
            for (int i = 0; i < pole.Count; i++)
            {
                if (pole[i].Broj == n)
                    return i;
            }
            return -1;
        }

        // Смена на 2 полиња
        private void swap(Pole p1, Pole p2)
        {
            int tmp = p1.X;
            p1.X = p2.X;
            p2.X = tmp;
            tmp = p1.Y;
            p1.Y = p2.Y;
            p2.Y = tmp;
        }

        // Проверка дали играта е завршена, true -> завршена
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

        // Ресетирање/креирање(празни) листа и матрица
        private void clear()
        {
            pole = new List<Pole>();
            mat = new int[M, M];
        }

        private void x3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
            count = 0;
            potezi = 0;
            label2.Text = "Потези: " + potezi;
            t.Start();
            this.Size = new Size(265, 304);
            label1.Location = new Point(0,252);
            label1.Visible = true;
            label2.Location = new Point(166,252);
            label2.Visible = true;
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
            count = 0;
            potezi = 0;
            label2.Text = "Потези: " + potezi;
            t.Start();
            this.Size = new Size(348, 380);
            label1.Location = new Point(0, 328);
            label1.Visible = true;
            label2.Location = new Point(166, 328);
            label2.Visible = true;
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

        private void onTick(object sender, EventArgs e)
        {
            count++;
            label1.Text = "Изминато времe: "+TimeSpan.FromSeconds(count).ToString();
        }
    }
}
