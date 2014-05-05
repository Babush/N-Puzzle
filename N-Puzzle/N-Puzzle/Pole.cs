using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Puzzle
{
    class Pole
    {
        public int Broj { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Image Slika { get; set; }

        public Pole(int broj, int x, int y, int width, int height, Image slika)
        {
            Broj = broj;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Slika = slika;
        }
        /*public void swap(Pole p1, Pole p2)
        {
            int tmp = p1.X;
            p1.X = p2.X;
            p2.X = tmp;
            tmp = p1.Y;
            p1.Y = p2.Y;
            p2.Y = tmp;
        }*/
    }
}
