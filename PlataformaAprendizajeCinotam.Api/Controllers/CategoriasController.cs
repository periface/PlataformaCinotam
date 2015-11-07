using Modelos.ModelosVista;
using Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlataformaAprendizajeCinotam.Api.Controllers
{
    public class CategoriasController : ApiController
    {
        private readonly ICategoriaClientService _categorias;
        public CategoriasController(ICategoriaClientService _categorias)
        {
            this._categorias = _categorias;
        }
        [HttpGet]
        [Route("Api/Categorias/Todos/")]
        public IEnumerable<CategoriaViewModel> Categorias()
        {
            var categorias = _categorias.CargaCategorias();
            return categorias;
        }
    }
}
