using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyStoreMVC.Models
{
    public class OrderDetailsModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }

        public decimal? price { get; set; }
    }
}
