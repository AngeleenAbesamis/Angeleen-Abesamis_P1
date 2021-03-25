using System;
using System.ComponentModel.DataAnnotations;

namespace BeautyStoreMVC.Models
{
    public class ReplenishInventoryViewModel
    {
        public int LocationId { get; set; }
        public int ProductId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "Quantity should be positive!")]
        public int Quantity { get; set; }
    }
}
