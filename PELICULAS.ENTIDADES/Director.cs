using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PELICULAS.ENTIDADES
{
    public class Director
    {
        public int Id { get; set; }   //pk sugerencia de tipo INT
        public string Nombres { get; set; }
        public string Nacionalidad { get; set; }
        public string Genero { get; set; }
        public int Edad { get; set; }

        //relaciones
        public List<Pelicula>? Peliculas { get; set; }
    }
}
