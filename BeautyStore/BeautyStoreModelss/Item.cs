using System;
using Serilog;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyStore.BeautyStoreModels
{
    /// <summary>
    /// This data structure models a product and its quantity. The quantity was separated from the product as it could vary from orders and location.
    /// </summary>
    public class Item
    {
        private int customerId;
        private int itemsId;
        public int BeautyProductsProductId { get; set; }
        private int? orderId;
        private int? quantity;
        public virtual BeautyProduct BeautyProducts { get; set; }

        [Key]
        public int ItemsId {
            get
            {
                return itemsId;
            }
            set
            {
                if (value.Equals(null))
                {
                    ThrowNullException();
                }
                itemsId = value;
            }
        }


        public int CustomerId
        {
            get
            {
                return customerId;
            }
            set
            {
                if (value.Equals(null))
                {
                    ThrowNullException();
                }
                customerId = value;
            }
        }

        public int? OrderId
        {
            get
            {
                return orderId;
            }
            set
            {
                if (value.Equals(null))
                {
                    ThrowNullException();
                }
                orderId = value;
            }
        }
        public int? Quantity
        {
            get { return quantity; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Cannot set OrderItem.Quantity to <= zero. (Tried to set to {value})");
                }
                quantity = value;
            }
        }

        private void ThrowNullException()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("../Logs/UILogs.json").CreateLogger();
            Log.Error("Cannot accept null value");

            throw new Exception("Null value cannot be accepted!");
        }
    }
}
