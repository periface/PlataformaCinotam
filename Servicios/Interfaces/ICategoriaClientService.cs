using Modelos.ModelosVista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Interfaces
{
    public interface ICategoriaClientService
    {
        IEnumerable<CategoriaViewModel> CargaCategorias();
        CategoriaViewModel Categoria(int idCategoria);
        CategoriaViewModel Categoria(int idCategoria,string slug);

    }
}
