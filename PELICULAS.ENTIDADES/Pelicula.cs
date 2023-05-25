namespace PELICULAS.ENTIDADES
{
    public class Pelicula
    {
        public int Id { get; set; }   //pk sugerencia de tipo INT
        public string Genero { get; set; }
        public String Titulo { get; set; }
        public String Autor { get; set; }
        public int Anio { get; set; }

        //relacion
        public Director Director { get; set; }
    }


}