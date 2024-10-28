using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TermProject.Models
{
    public class Workouts
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [RegularExpression("[a-zA-Z ]", ErrorMessage = "Only alphabetic letters are allowed.")]
        [StringLength(30, ErrorMessage ="Please enter a workout using 30 characters or less.")]
        public string? Name { get; set; }

        [Display(Name="Type")]
        public int? BodyGroupId { get; set; }
        
        public BodyGroup? BodyGroup { get; set; }

        public int? Sets { get; set; }

        public int? Reps { get; set; }

        [Display(Name = "Weight(Ibs)")]
        [Range(5, 1000)]
        public int? Weight { get; set; }
    }
}
