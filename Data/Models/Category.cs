using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Category
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } 

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string? CreatedBy { get; set; } = "user";

        public DateTime? UpdatedDate { get; set; }

        public string? UpdatedBy { get; set; }
        [ValidateNever]
        //navigation properties
        public List<SubCategory> subCategories { get; set; }

    }
}
