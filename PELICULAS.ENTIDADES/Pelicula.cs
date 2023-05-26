namespace PELICULAS.ENTIDADES
{
    public class Pelicula
    {
        public int Id { get; set; }   //pk sugerencia de tipo INT
        public string Genero { get; set; }
        public String Titulo { get; set; }
        public int Anio { get; set; }

        //relacion
        public int DirectorId { get; set; }
        public Director? Director { get; set; }
    }


}