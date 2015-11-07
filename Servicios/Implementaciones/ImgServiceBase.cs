using Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;
namespace Servicios.Implementaciones
{
    public class ImgServiceBase : IImgService
    {
        private readonly HttpServerUtility Server;
        public ImgServiceBase()
        {
            Server = HttpContext.Current.Server;
        }
        public void EliminaImagen(string rutaImagen)
        {
            try
            {

                File.Delete(rutaImagen);
            }
            catch (Exception)
            {
                return;
            }
        }

        public void GeneraCarpetas(string rutaCarpeta)
        {
            var serverRt = Server.MapPath(rutaCarpeta);
            if (!Directory.Exists(serverRt))
                Directory.CreateDirectory(rutaCarpeta);

        }
        public string GuardaImagen(HttpPostedFileBase imagen, string rutaRecurso, string carpetaRecurso)
        {
            var sqlRt = carpetaRecurso + rutaRecurso;
            var serverRt = Server.MapPath(sqlRt);
            GeneraCarpetas(serverRt);
            imagen.SaveAs(serverRt);
            return sqlRt;
        }
    }
}
