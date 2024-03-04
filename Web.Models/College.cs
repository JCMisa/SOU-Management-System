using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class College
    {
        [Key]
        public int CollegeId { get; set; }

        [Required]
        public string? CollegeName { get; set; }
    }
}
