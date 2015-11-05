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
        public CursosController(ICursoClientService _cursos)
        {
            this._cursos = _cursos;
        }
        [HttpGet]
        public CursoViewModel Curso(int id) {
            var curso = _cursos.CargaCurso(id);
            return curso;
        }
    }
}
