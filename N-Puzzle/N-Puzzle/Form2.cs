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
    public partial class Form2 : Form
    {
        public string str1 = "Images\\Numbers\\3x3\\#.png";
        public string str2 = "Images\\Numbers\\4x4\\1#.png";
        public bool tri = true;
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            str1 = "Images\\Numbers\\3x3\\#.png";
            str2 = "Images\\Numbers\\4x4\\1#.png";
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            str1 = "Images\\Smileyy\\3x3\\#.png";
            str2 = "Images\\Smileyy\\4x4\\1#.png";
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            str1 = "Images\\Monkeyy\\3x3\\#.png";
            str2 = "Images\\Monkeyy\\4x4\\1#.png";
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            str1 = "Images\\Fnklogo\\3x3\\#.png";
            str2 = "Images\\Fnklogo\\4x4\\1#.png";
            this.Close();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            if (tri)
                pictureBox1.Image = Image.FromFile(@"Images\Menu\Numbers 3x3.png");
            else
                pictureBox1.Image = Image.FromFile(@"Images\Menu\Numbers 4x4.png");
        }
    }
}
