using System;
using System.Collections.Generic;
using Serilog;
using System.ComponentModel.DataAnnotations;

namespace BeautyStore.BeautyStoreModels
{
    public class BeautyProduct
    {
        
        private int productId;
        private string productName;
        private decimal price;
        private string brands;
        private string sizes;
        private string description;
        public string Photo { get; set; }
        public List<Item> Items { get; set; }

        public int? InventoriesId { get; set; }

        public virtual Inventory Inventory { get; set; }

        [Key]
        public int ProductId
        {
            get
            {
                return productId;
            }
            set
            {
                if (value.Equals(null))
                {
                    ThrowNullException();
                }
                productId = value;
            }
        }
        private void ThrowNullException()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("../Logs/UILogs.json").CreateLogger();
            Log.Error("Cannot accept null value.");
            throw new Exception("Null value not valid!");
        }

        public override string ToString()
        {
            return $"Product Name: {this.ProductName}\n\t Price: {this.Price}\n\t Description: {this.Description}";
        }

        public string ToStringSet()
        {
            return $"Product Name: {this.ProductName}\n\t Price: {this.Price}\n\t Description: {this.Description}";
        }
        public string ProductName
        {
            get { return productName; }
            set
            {
                if (value == null || value.Equals(""))
                {
                    throw new ArgumentNullException("Cannot set ProductName to null or empty.");
                }
                productName = value;
            }
        }
        public decimal Price {
            get
            {
                return price;
            }
            set
            {
                if (value.Equals(null))
                {
                    ThrowNullException();
                }
                price= value;
            }
        }
        public string Brands {
            get
            {
                return brands;
            }
            set
            {
                if (value.Equals(null))
                {
                    ThrowNullException();
                }
                brands = value;
            }
        }
        public string Sizes {
            get
            {
                return sizes;
            }
            set
            {
                if (value.Equals(null))
                {
                    ThrowNullException();
                }
                sizes = value;
            }
        }
        public string Description {
            get
            {
                return description;
            }
            set
            {
                if (value.Equals(null))
                {
                    ThrowNullException();
                }
                description = value;
            }
        }
    }
}
