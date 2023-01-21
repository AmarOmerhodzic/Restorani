using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restorani.Models
{
    public class Jelo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }

        [Required]
        [Column(TypeName = "smallmoney")]
        public decimal Cijena { get; set; }

        [Required]
        [ForeignKey("Restorani")]
        public  int RestoranId { get; set; }
        public virtual Restoran Restorani { get; set; }

    }
}
