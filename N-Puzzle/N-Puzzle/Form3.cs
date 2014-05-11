using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N_Puzzle
{

    public partial class Form3 : Form
    {
        List<Score> skor = new List<Score>();
        public Form3()
        {
            InitializeComponent();
        }

        public Form3(List<Score> lista)
        {
            skor = lista;
            InitializeComponent();
            listBox1.Items.Clear();
            for (int i = 0; i < skor.Count; i++)
            {
                listBox1.Items.Add((i + 1) + "." + skor[i]);
            }
        }
    }
}
