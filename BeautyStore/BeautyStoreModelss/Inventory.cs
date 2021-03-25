using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeautyStore.BeautyStoreModels
{
    public class Inventory
    {

        [Key]
        public int InventoriesId { get; set; }

        public string InventoryTitle { get; set; }
        public int? Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public int? LocationId { get; set; }
        public ICollection<BeautyProduct> BeautyProduct { get; set; }
        public Location Location { get; set; }

        private int? quantity;
    }
}
