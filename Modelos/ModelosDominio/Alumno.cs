using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ModelosDominio
{
    [Table("Alumno")]
    public class Alumno : Usuario
    {
        [Key]
        public int idAlumno { get; set; }
        public string razonSocial { get; set; }
        public string direccionFac { get; set; }
        public string rfc { get; set; }
        public virtual ICollection<Curso> cursos { get; set; }
    }
}
