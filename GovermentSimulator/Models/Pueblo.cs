using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GovermentSimulator.Models
{
    class Pueblo
    {
        public int id { get; set; }
        public string contiendaCivil { get; set; }

        public Pueblo(int num,  string contiendaCivil)
        {
            this.id = num;
            this.contiendaCivil = contiendaCivil;
        }
    }

    public enum contiendas
    {
        ALTA,
        BAJA
    }
}
