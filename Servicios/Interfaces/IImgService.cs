using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Servicios.Interfaces
{
    public interface IImgService
    {
        string GuardaImagen(HttpPostedFileBase imagen,string rutaRecurso,string carpetaRecurso);
        void EliminaImagen(string rutaImagen);
        void GeneraCarpetas(string rutaCarpeta);

    }
}
