using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelos.ModelosDominio
{
    [Table("ContenidoTemas")]
    public class ContenidoTema
    {
        [Key]
        public int idContenido{ get; set; }
        public bool soloInscritos { get; set; }
        public string tituloContenido { get; set; }
        public string contenido { get; set; }
        public int idTema { get; set; }
        [ForeignKey("idTema")]
        public virtual Tema tema { get; set; }
    }
}