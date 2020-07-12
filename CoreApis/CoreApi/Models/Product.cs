using System;
using System.Collections.Generic;

namespace CoreApi.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string ProdName { get; set; }
        public string ProdDesc { get; set; }
        public int? ProdPrice { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
