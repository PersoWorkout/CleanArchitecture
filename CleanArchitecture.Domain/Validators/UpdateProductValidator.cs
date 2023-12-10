using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Validators
{
    public class UpdateProductValidator
    {
        public string name { get; set; }
        public string description { get; set; }
        public decimal? price { get; set; }
        public int? idCategory { get; set; }
    }
}
