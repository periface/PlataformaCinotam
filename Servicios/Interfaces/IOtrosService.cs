using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace Servicios.Interfaces
{
    public interface IOtrosService
    {
        string slugger(string aSlug);
        string imgr(HttpPostedFileBase imagen);
        void eliminaImg(string url);

    }
}
