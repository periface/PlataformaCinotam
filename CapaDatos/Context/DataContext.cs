using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.ModelosDominio;
namespace CapaDatos.Context
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Alumno> alumnos { get; set; }
        public DbSet<Instructor> instructores { get; set; }
        public DbSet<Curso> cursos { get; set; }
        public DbSet<ContenidoTema> contenidoTema { get; set; }
        public DbSet<Tema> temas { get; set; }
        public DbSet<Materiales> materiales { get; set; }
    }
}
