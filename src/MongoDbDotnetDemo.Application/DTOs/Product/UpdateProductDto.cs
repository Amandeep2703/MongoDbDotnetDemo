using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbDotnetDemo.Application.DTOs.Product
{
    public class UpdateProductDto
    {
        [Required]
        public string? Name { get; set; }

        [Range(1, double.MaxValue)]
        public decimal? Price
        {
            get; set;
        }

        public bool? IsActive
        {
            get; set;
        }
    }
}
