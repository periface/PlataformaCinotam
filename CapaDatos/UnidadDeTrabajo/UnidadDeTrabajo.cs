using CapaDatos.Context;
using Modelos.ModelosDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.UnidadDeTrabajo
{
    /// <summary>
    /// Esta clase se encargara de completar las transacciones a la base de datos.
    /// </summary>
    public class UnidadDeTrabajo : IDisposable
    {
        private DataContext context = new DataContext();
        private RepositorioGenerico.RepositorioGenerico<Curso> repositorioPublicacion;
        public RepositorioGenerico.RepositorioGenerico<Curso> RepositorioPublicacion
        {
            get
            {
                if (repositorioPublicacion == null)
                    repositorioPublicacion = new RepositorioGenerico.RepositorioGenerico<Curso>(context);
                return repositorioPublicacion;
            }
        }
        public void Guardar() {
            context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing) {
            if (!disposed) {
                if (disposing) {
                    context.Dispose();
                }
            }
            disposed = false;
        }
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
