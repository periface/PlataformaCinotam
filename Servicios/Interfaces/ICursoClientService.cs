using Modelos.ModelosDominio;
using Modelos.ModelosVista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Interfaces
{
    public interface ICursoClientService
    {
        CursoViewModel CargaCurso(int idCurso,string urlSlug);
        CursoViewModel CargaCurso(int idCurso);
    }
}
