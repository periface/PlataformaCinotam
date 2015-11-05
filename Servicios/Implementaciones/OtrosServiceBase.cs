using Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Servicios.Implementaciones
{
    public class OtrosServiceBase : IOtrosService
    {
        public void eliminaImg(string url)
        {
            throw new NotImplementedException();
        }

        public string imgr(HttpPostedFileBase imagen)
        {
            throw new NotImplementedException();
        }

        public string slugger(string aSlug)
        {
            throw new NotImplementedException();
        }
    }
}
