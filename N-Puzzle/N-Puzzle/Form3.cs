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
    public partial class Form3 : Form
    {
        public string str = "";
        public Form3()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            str = "Images\\Numbers\\4x4\\1#.png";
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            str = "Images\\Smileyy\\4x4\\1#.png";
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            str = "Images\\Monkeyy\\4x4\\1#.png";
            this.Close();
        }
    }
}
