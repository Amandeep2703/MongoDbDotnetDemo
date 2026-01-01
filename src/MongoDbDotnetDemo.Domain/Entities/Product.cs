using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbDotnetDemo.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; } = string.Empty;
        public decimal? Price
        {
            get; set;
        }
        public string? CategoryId { get; set; } = string.Empty;
    }
}
