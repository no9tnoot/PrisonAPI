
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prisoners.Data.Models
{
    [Table("Prisoners")]
    public class Prisoner
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Surname { get; set; }
        [Required]
        public string? Crime { get; set; }
        [Required]
        public int Cellnumber { get; set; }
        //public ICollection<Inventory>? PrisonerInventories { get; set; }
    }
}
