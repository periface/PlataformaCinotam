using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Interfaces
{
    public interface ICursoUsuarioAdminService
    {
        void InscribirAlumno(object idAlumno, int idCurso);
        /// <summary>
        /// Para demos o periodos de prueba
        /// </summary>
        /// <param name="idAlumno"></param>
        /// <param name="idCurso"></param>
        /// <param name="fechaExp"></param>
        void InscribirAlumno(object idAlumno, int idCurso, DateTime fechaExp);
        void ValidarInstructor(object idInstructor);
        void AgregarInstructorACurso(int idInstructor, int idCurso);
        void EliminarInstructorDeCurso(int idInstructor, int idCurso);
    }
}
