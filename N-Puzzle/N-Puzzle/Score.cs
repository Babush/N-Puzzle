using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Puzzle
{
    public class Score
    {
        public string Ime { get; set; }
        public int Poeni { get; set; }
        public int Vreme { get; set; }
        public int Potezi { get; set; }
        public int Tip { get; set; }
        public Score(string ime,int poeni,int vreme,int potezi,int tip)
        {
            Ime = ime;
            Poeni = poeni;
            Vreme = vreme;
            Potezi = potezi;
            Tip = tip;
        }
        public override string ToString()
        {
            if(Tip == 3)
                return "\t"+Ime+"\t\t"+Vreme+"\t\t"+Potezi+"\t\t"+Poeni+"\t\t3x3";
            return "\t" + Ime + "\t\t" + Vreme + "\t\t" + Potezi + "\t\t" + Poeni + "\t\t4x4";
        }
    }
}
