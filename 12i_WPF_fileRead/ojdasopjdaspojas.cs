using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12i_WPF_fileRead
{
    class epito______anyag
    {
        public double suly { get; set; }
        public string nev { get; set; }
        public int ar { get; set; }//ar mint viz
    }
    class tegla:epito______anyag
    {
        public string tipus { get; set; }
        public string szin { get; set; }
    }

    class fa : epito______anyag
    {
        public string faAnyag { get; set; }
        public float kemenyseg { get; set; }
    }
    class vas : epito______anyag
    {
        public string femtipus { get; set; }
        public float suruseg { get; set; }
    }
}
