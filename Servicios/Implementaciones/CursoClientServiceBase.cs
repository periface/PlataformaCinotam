using Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.ModelosDominio;
using CapaDatos.UnidadDeTrabajo;
using Modelos.ModelosVista;
using AutoMapper;
namespace Servicios.Implementaciones
{
    public class CursoClientServiceBase : ICursoClientService
    {
        private readonly UnidadDeTrabajo _unidadDeTrabajo;
        public CursoClientServiceBase(UnidadDeTrabajo _unidadDeTrabajo)
        {
            this._unidadDeTrabajo = _unidadDeTrabajo;
            Mapper.CreateMap<CursoViewModel, Curso>();
            Mapper.CreateMap<Curso, CursoViewModel>();
        }
        public virtual CursoViewModel CargaCurso(int idCurso)
        {
            var curso = _unidadDeTrabajo.RepositorioPublicacion.CargaPorId(idCurso);
            var cursoViewModel = new CursoViewModel()
            {
                titulo = "Curso no encontrado",
            };
            if (curso != null)
            {
                //Mapeado principal
                cursoViewModel = Mapper.Map<Curso, CursoViewModel>(curso);
                //if (curso.mostrarPrecio)
                //{
                //    //Aqui se cargaria el precio
                //    cursoViewModel.precio = 100;
                //}
            }
            return cursoViewModel;
        }
        public virtual CursoViewModel CargaCurso(int idCurso, string urlSlug)
        {
            var curso = _unidadDeTrabajo.RepositorioPublicacion.Carga(a => a.urlSlug.ToUpper() == urlSlug.ToUpper() && a.idCurso == idCurso);
            var cursoViewModel = new CursoViewModel()
            {
                titulo = "Curso no encontrado",
            };
            if (curso != null)
            {
                //Mapeado principal
                cursoViewModel = Mapper.Map<Curso, CursoViewModel>(curso);
                //if (curso.mostrarPrecio)
                //{
                //    //Aqui se cargaria el precio
                //    cursoViewModel.precio = 100;
                //}
            }
            return cursoViewModel;
        }

        public IEnumerable<CursoViewModel> CargaCursos()
        {
            List<CursoViewModel> model = new List<CursoViewModel>();
            var cursos = _unidadDeTrabajo.RepositorioPublicacion.Cargar();
            foreach (var item in cursos)
            {
                var cursoViewModel = Mapper.Map<Curso, CursoViewModel>(item);
                //if (item.mostrarPrecio) {
                //    cursoViewModel.precio = 100;
                //}
                model.Add(cursoViewModel);
            }
            return model;
        }

        public IEnumerable<CursoViewModel> CargaCursos(string busqueda, string orden, int pagina = 1)
        {
            throw new NotImplementedException();
        }
    }
}

