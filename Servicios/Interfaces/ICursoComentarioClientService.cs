using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Interfaces
{
    public interface ICursoComentarioClientService
    {
        void AgregarComentario(string comentario,int idCurso,object idCliente);
        void ReponderComentario(string comentario,string idCurso,int idComentarioPadre,object idCliente);
    }
}
