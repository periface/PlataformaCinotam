using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Modelos.ModelosVista
{
    public class CursoViewModel
    {
        public int idCurso { get; set; }
        public string titulo { get; set; }
        public string sese { get; set; }
        public DateTime fecha { get; set; }
        public DateTime fechaFinalizacion { get; set; }
        public string telefonoContacto { get; set; }
        public string nombreFacilitador { get; set; }
        public decimal? precio { get; set; }
        public string urlSlug { get; set; }
        public string imagen { get; set; }
        [AllowHtml]
        public string contenido { get; set; }
    }
}
