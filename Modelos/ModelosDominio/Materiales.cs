using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelos.ModelosDominio
{
    public class Materiales
    {
        [Key]
        public int idMaterial { get; set; }
        public string descripcion { get; set; }
        public int idTema { get; set; }
        [ForeignKey("idTema")]
        public virtual Tema tema { get; set; }
    }
}