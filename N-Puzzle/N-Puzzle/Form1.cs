using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N_Puzzle
{
    public partial class Form1 : Form
    {
        List<Pole> pole = new List<Pole>(); // Листа во која се чуваат полињата
        List<Score> score = new List<Score>();

        Random r = new Random();
        Form2 f2 = new Form2();

        int[,] mat; // Матрица која го содржи распоредот на полињата
        int count = 0; // Бројач за време
        int potezi = 0; // Бројач за потези

        public int X { get; set; } // Координата X
        public int Y { get; set; } // Координата Y
        public int N { get; set; } // Број на полиња
        public int M { get; set; } // Број на полиња во еден ред

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
            this.MouseDown += MouseKlik;
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
                StringBuilder s = new StringBuilder(@f2.str1);
                StringBuilder s1 = new StringBuilder(@f2.str2);
                int n = r.Next(list.Count);
                int m = list[n];
                mat[j, k] = m;
                list.RemoveAt(n);
                if (m > 9)
                {
                    s1[20] = (char)(m % 10 + 48);
                    s = s1;
                }
                else
                    s[19] = (char)(m + 48);
                if (M == 4)
                {
                    s[15] = '4';
                    s[17] = '4';
                }
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
        private void MouseKlik(object sender, MouseEventArgs e)
        {
            // x,y координати на кликот, a,b помошни индекси, n вредноста на кликнатото поле
            int x = e.X, y = e.Y, n = 0, a = 0, b = 0;
            X = 83;
            Y = 100;
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < M; j++)
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
                for (int i = 0; i < M; i++)
                {
                    for (int j = 0; j < M; j++)
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
                this.MouseDown -= MouseKlik;
                t.Stop();
                Form4 f4 = new Form4();
                f4.ShowDialog();
                MessageBox.Show("Честитки освоивте: " + (10000 / count) * (1000 / potezi) + " поени");
                score.Add(new Score(f4.s, (10000 / count) * (1000 / potezi), TimeSpan.FromSeconds(count).ToString(), potezi, M));
                score = score.OrderByDescending(z => z.Poeni).ToList();
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
            this.MouseDown -= MouseKlik;
            f2.tri = true;
            f2.ShowDialog();
            count = 0;
            potezi = 0;
            label2.Text = "Потези: " + potezi;
            t.Start();
            this.Size = new Size(265, 304);
            label1.Location = new Point(0,252);
            label1.Visible = true;
            label2.Location = new Point(166,252);
            label2.Visible = true;
            N = 9;
            M = 3;
            game();
            Invalidate();
        }

        private void x4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MouseDown -= MouseKlik;
            f2.tri = false;
            f2.ShowDialog();
            count = 0;
            potezi = 0;
            label2.Text = "Потези: " + potezi;
            t.Start();
            this.Size = new Size(348, 380);
            label1.Location = new Point(0, 328);
            label1.Visible = true;
            label2.Location = new Point(166, 328);
            label2.Visible = true;
            N = 16;
            M = 4;
            game();
            Invalidate();
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

        private void паузаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (паузаToolStripMenuItem.Checked == true)
            {
                t.Start();
                this.MouseDown += MouseKlik;
                паузаToolStripMenuItem.Checked = false;
                return;
            }
            if (паузаToolStripMenuItem.Checked == false)
            {
                t.Stop();
                this.MouseDown -= MouseKlik;
                паузаToolStripMenuItem.Checked = true;
                return;
            }
            
        }

        private void highScoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(score);
            f3.ShowDialog();
        }
    }
}
