using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Models
{
    public class AcademicRank
    {
        [Key]
        public int AcademicRankId { get; set; }

        [Required]
        public string? RankName { get; set; }
    }
}
