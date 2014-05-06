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
        public string str1 = "";
        public string str2 = "";
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            str1 = "Images\\Numbers\\#.png";
            str2 = "Images\\Numbers\\1#.png";
        }
    }
}
