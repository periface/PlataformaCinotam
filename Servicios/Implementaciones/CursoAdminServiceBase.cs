using Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.ModelosDominio;

namespace Servicios.Implementaciones
{
    public class CursoAdminServiceBase : ICursoAdminService
    {
        private readonly CapaDatos.UnidadDeTrabajo.UnidadDeTrabajo _unidadTrabajo;
        private readonly IImgService _img;
        public CursoAdminServiceBase(CapaDatos.UnidadDeTrabajo.UnidadDeTrabajo _unidadTrabajo,IImgService _img)
        {
            this._unidadTrabajo = _unidadTrabajo;
            this._img = _img;
        }
        public Curso CargaCurso(int id)
        {
            return new Curso();
        }

        public IEnumerable<Curso> Cursos()
        {
            throw new NotImplementedException();
        }

        public void EditarCurso(Curso model)
        {
            throw new NotImplementedException();
        }

        public void EliminarCurso(int id)
        {
            throw new NotImplementedException();
        }

        public void EliminarCurso(Curso model)
        {
            throw new NotImplementedException();
        }

        public void GuardaCurso(Curso model)
        {
            _img.EliminaImagen("");
        }
    }
}
