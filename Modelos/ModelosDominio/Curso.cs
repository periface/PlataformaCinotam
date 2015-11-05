using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Modelos.ModelosDominio
{
    [Table("Cursos")]
    public class Curso
    {
        [Key]
        public int idCurso { get; set; }
        public string titulo { get; set; }
        public string sede { get; set; }
        public DateTime fecha{ get; set; }
        public DateTime fechaFinalizacion { get; set; }
        public string telefonoContacto { get; set; }
        public string nombreFacilitador { get; set; }
        public bool mostrarPrecio { get; set; }
        public string urlSlug { get; set; }
        public string imagen { get; set; }
        public virtual ICollection<Tema> temas { get; set; }
        public virtual ICollection<Alumno> alumnos { get; set; }
        public virtual ICollection<Instructor> instructores { get; set; }
        [AllowHtml]
        public string contenido { get; set; }
        public int idCategoria { get; set; }
        [ForeignKey("idCategoria")]
        public virtual Categoria categoria { get; set; }
    }
}