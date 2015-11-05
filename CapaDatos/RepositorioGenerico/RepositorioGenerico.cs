using CapaDatos.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.RepositorioGenerico
{
    public class RepositorioGenerico<T> where T : class
    {
        internal DataContext context;
        internal DbSet<T> dbSet;
        public RepositorioGenerico(DataContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }
        public T CargaPorId(object id)
        {
            return dbSet.Find(id);
        }
        public void Insertar(T model)
        {
            dbSet.Add(model);
        }
        public IQueryable<T> CargaMuchosQuery(Func<T, bool> where)
        {
            return dbSet.Where(where).AsQueryable();
        }
        public IQueryable<T> Cargar()
        {
            return dbSet;
        }
        public T Carga(Func<T, bool> where)
        {
            return dbSet.Where(where).SingleOrDefault();
        }
        public IQueryable<T> CargaEIncluye(Expression<Func<T, bool>> predicado, params string[] incluye)
        {
            IQueryable<T> query = dbSet;
            query = incluye.Aggregate(query, (actual, incl) => actual.Include(incl));
            return query.Where(predicado);
        }
    }
}
