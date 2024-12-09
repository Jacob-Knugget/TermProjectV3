using System.ComponentModel.DataAnnotations;

namespace TermProject.Models
{
    public class BodyGroup
    {
        [Key]
        public int BodyGroupId { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only alphabetic letters are allowed.")]
        [DataType(DataType.Text)]
        [Display(Name = "Body Group")]
        public string? BodyGroupName { get; set; }
    }
}
