using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PELICULAS.ENTIDADES;

    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<PELICULAS.ENTIDADES.Director> Directores { get; set; } = default!;

        public DbSet<PELICULAS.ENTIDADES.Pelicula>? Peliculas { get; set; }
    }
