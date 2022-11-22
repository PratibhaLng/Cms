using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.ViewModels
{
    public class SubCategoryVm
    {

        public SubCategory SubCategory { get; set; }
       public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
