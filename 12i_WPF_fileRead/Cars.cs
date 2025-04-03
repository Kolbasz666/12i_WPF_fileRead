using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12i_WPF_fileRead
{
    public class Cars
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Power { get; set; }
        public int Weight { get; set; }
        public double PowerToWeight
        {
            get
            {
                return (double)Power / Weight;
            }
        }
        public Cars(string line)
        {
            string[] temp = line.Split(';');
            Manufacturer = temp[0];
            Model = temp[1];
            Power = int.Parse(temp[2]);
            Weight = int.Parse(temp[3]);
        }
        public Cars(string Man, string Mod, int Pow, int Wei)
        {
            Manufacturer = Man;
            Model = Mod;
            Power = Pow;
            Weight = Wei;
        }
    }
}
