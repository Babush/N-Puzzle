﻿using System;
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
        public string str = "Images\\Numbers\\3x3\\#.png";
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            str = "Images\\Numbers\\3x3\\#.png";
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            str = "Images\\Smileyy\\3x3\\#.png";
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            str = "Images\\Monkeyy\\3x3\\#.png";
            this.Close();
        }

    }
}
