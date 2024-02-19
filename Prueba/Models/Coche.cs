using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prueba.Models
{
    [Table ("coches")]

    public class Coche
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Coche_PK { get; set; }
        public string Matricula { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        [DataType(DataType.Date)]
        public DateTime Ano { get; set; }

        public virtual Dueno dueno { get; set; }
    }
}
