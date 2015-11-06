using Modelos.ModelosDominio;
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
    public class CursosController : ApiController
    {
        ICursoClientService _cursos;
        ICursoAdminService _cursosAdmin;
        public CursosController(ICursoClientService _cursos,ICursoAdminService _cursosAdmin)
        {
            this._cursos = _cursos;
            this._cursosAdmin = _cursosAdmin;
        }
        [HttpGet]
        [Authorize]
        [Route("Api/Cursos/Curso/{id}")]
        public CursoViewModel Curso(int id) {
            var curso = _cursos.CargaCurso(id);
            return curso;
        }
        [HttpGet]
        [Route("Api/Cursos/Todos/")]
        public IEnumerable<CursoViewModel> Cursos() {
            var cursos = _cursos.CargaCursos();
            return cursos;
        }
    }
}
