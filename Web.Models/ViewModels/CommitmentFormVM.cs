using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Models.ViewModels
{
    public class CommitmentFormVM
    {
        public CommitmentForm CommitmentForm { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> CollegeList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> AcademicRankList { get; set; }
    }
}
