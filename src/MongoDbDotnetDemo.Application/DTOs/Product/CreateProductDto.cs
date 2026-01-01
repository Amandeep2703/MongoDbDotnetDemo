using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbDotnetDemo.Application.DTOs.Product
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Range(1, double.MaxValue)]
        public decimal Price
        {
            get; set;
        }

        [Required]
        public string CategoryId { get; set; } = string.Empty;
    }
}
