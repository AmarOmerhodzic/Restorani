using System.ComponentModel.DataAnnotations;

namespace Restorani.Models
{
    public class Restoran
    {
        [Key]
        public int Id { get; set; }

        public string Naziv { get; set; }

        public string Adresa { get; set; }

        public string Telefon { get; set; }

    }
}
