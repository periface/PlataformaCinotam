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
        private readonly IOtrosService _otrosServicios;
        private readonly CapaDatos.UnidadDeTrabajo.UnidadDeTrabajo _unidadTrabajo;
        public CursoAdminServiceBase(IOtrosService _otrosServicios, CapaDatos.UnidadDeTrabajo.UnidadDeTrabajo _unidadTrabajo)
        {
            this._otrosServicios = _otrosServicios;
            this._unidadTrabajo = _unidadTrabajo;
        }
        public Curso CargaCurso(int id)
        {
            _otrosServicios.eliminaImg("");
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
            throw new NotImplementedException();
        }
    }
}
