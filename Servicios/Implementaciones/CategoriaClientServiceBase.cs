using Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.ModelosVista;
using CapaDatos.UnidadDeTrabajo;
using Modelos.ModelosDominio;
using Servicios.ServicioMapeo;

namespace Servicios.Implementaciones
{
    public class CategoriaClientServiceBase : ICategoriaClientService
    {
        private readonly UnidadDeTrabajo _unidadDeTrabajo;
        private AutoMapperService<Categoria, CategoriaViewModel> AutoMapperService = new AutoMapperService<Categoria, CategoriaViewModel>();
        public CategoriaClientServiceBase(UnidadDeTrabajo _unidadDeTrabajo)
        {
            this._unidadDeTrabajo = _unidadDeTrabajo;
            //Mapper.CreateMap<CategoriaViewModel, Categoria>();
            //Mapper.CreateMap<Categoria, CategoriaViewModel>();
        }
        public IEnumerable<CategoriaViewModel> CargaCategorias()
        {
            var categorias = _unidadDeTrabajo.RepositorioCategoria.Cargar();
            var listaCategorias = new List<CategoriaViewModel>();
            foreach (var item in categorias)
            {
                var conversion = AutoMapperService.GenerarModelo(item);
                listaCategorias.Add(conversion);
            }
            return listaCategorias;
        }

        public CategoriaViewModel Categoria(int idCategoria)
        {
            var categoria = _unidadDeTrabajo.RepositorioCategoria.CargaPorId(idCategoria);
            CategoriaViewModel modelo = new CategoriaViewModel() {
                nombreCategoria = "Categoria no encontrada",
                descripcionCategoria = "Categoria no encontrada",
            };
            if (categoria != null) {
                modelo = AutoMapperService.GenerarModelo(categoria);
            }
            return modelo;
        }

        public CategoriaViewModel Categoria(int idCategoria, string slug)
        {
            var categoria = _unidadDeTrabajo.RepositorioCategoria.Carga(a=>a.idCategoria==idCategoria);
            CategoriaViewModel modelo = new CategoriaViewModel()
            {
                nombreCategoria = "Categoria no encontrada",
                descripcionCategoria = "Categoria no encontrada",
            };
            if (categoria != null)
            {
                modelo = AutoMapperService.GenerarModelo(categoria);
            }
            return modelo;
        }
    }
}
