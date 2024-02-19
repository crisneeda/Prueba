using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prueba.Models
{
    [Table("duenos")]
    public class Dueno
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_duenos_PK { get; set; }
        public string Nombre { get; set; }
        [DataType(DataType.Date)]
        public DateTime Fecha_nac { get; set; }
        public string Direccion { get; set; }
        public string Curp { get; set; }

    }
}