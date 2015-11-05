using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelos.ModelosDominio
{
    [Table("TemasCurso")]
    public class Tema
    {
        [Key]
        public int idTema { get; set; }
        public string nombreTema { get; set; }
        public virtual ICollection<ContenidoTema> contenidos { get; set; }
        public virtual ICollection<Materiales> materiales{ get; set; }
        public int? idCurso { get; set; }
        [ForeignKey("idCurso")]
        public virtual Curso curso { get; set; }
    }
}