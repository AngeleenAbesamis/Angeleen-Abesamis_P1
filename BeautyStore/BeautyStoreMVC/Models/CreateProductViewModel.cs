using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BeautyStore.BeautyStoreModels;

namespace BeautyStoreMVC.Models
{
    public class CreateProductViewModel
    {
        public int ProductId { get; set; }

        [DisplayName("Product Name")]
        [Required]
        public string ProductName { get; set; }

        [DisplayName("Price")]
        [Required]
        public decimal? ProductPrice { get; set; }

        public int ItemId { get; set; }

        public int? Quantity { get; set;}
    }
}
