using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class SubCategory
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string ?UpdatedBy { get; set; }

        //  Navigation properties
        public int CategoryId { get; set; }
        [ValidateNever]
        public Category Category { get; set; }

        public List<Product> Products { get; set; }

    }
}
