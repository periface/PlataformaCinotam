using Modelos.ModelosDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Interfaces
{
    public interface ICursoAdminService
    {
        Curso CargaCurso(int id);
        void GuardaCurso(Curso model);
        void EditarCurso(Curso model);
    }
}
