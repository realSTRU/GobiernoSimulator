using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovermentSimulator.Models
{
    class Gobierno
    {
        public int id { get; set; }
        public  string nombre { get; set; }
        public string partido { get; set; }
        public string politica { get; set; }

        public Gobierno(int id, string nombre, string partido, string politica) {
            
            this.id = id;
            this.nombre = nombre;
            this.partido = partido;
            this.politica = politica;

        }
       
    }

    public enum partidos
    {
        CONSERVADOR,
        LIBERAL

    }

    public enum politicas
    {
        PERMISIVA,
        COERCITIVA
    }
}
