using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ModelosDominio
{
    [Table("Instructores")]
    public class Instructor : Usuario
    {
        [Key]
        public int idInstructor { get; set; }
        public string experiencia { get; set; }
        public string institucionProcedencia { get; set; }
        public virtual ICollection<Curso> cursos { get; set; }
    }
}
