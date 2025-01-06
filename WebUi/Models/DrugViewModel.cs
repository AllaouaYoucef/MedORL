using System.ComponentModel.DataAnnotations;

namespace WebUi.Models
{
    public class DrugViewModel
    {

        public int Id { get; set; }
        [MaxLength(50)]
        [Display(Name = "Nom du medicament* ")]
        public required string Name { get; set; }
        
        [MaxLength(200)]
        [Display(Name = "Posologie")]
        public string? Dosage { get; set; }

    }
}
