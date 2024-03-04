using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Models
{
    public class CommitmentForm
    {
        [Key]
        public int CommitmentId { get; set; }

        [Required]
        public string? OrganizationName { get; set; }

        [Required]
        public string? AdvicerName { get; set; }

        [Required]
        public string? HomeAddress { get; set; }

        [Required]
        public string? ContactNo { get; set; }

        public int CollegeId { get; set; }
        [ForeignKey("CollegeId")]
        [ValidateNever]
        public College College { get; set; }

        public int AcademicRankId { get; set; }
        [ForeignKey("AcademicRankId")]
        [ValidateNever]
        public AcademicRank AcademicRank { get; set; }
    }
}
