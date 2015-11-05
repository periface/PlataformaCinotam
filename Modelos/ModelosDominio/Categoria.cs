using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ModelosDominio
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int idCategoria { get; set; }
        public string nombreCategoria { get; set; }
        public string descripcionCategoria { get; set; }
        public virtual ICollection<Curso> cursos { get; set; }
    }
}
