using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyStore.BeautyStoreModels
{
    /// <summary>
    /// This class contains all the fileds and properties that define a customer order.
    /// </summary>
    public class Order
    {
        private int orderId;
        private int customerId;
        // private byte orderStatus;
        private DateTime orderDate;
        // private DateTime requiredDate;
        // private decimal price;
        // private DateTime shippedDate;
        private int? locationId;
        // private int managerId;
        public Customer Customer { get; set; }
        public Location Location { get; set; }
        public List<Item> Items { get; set; }
        public int OrderId {
            get
            {
                return orderId;
            }
            set
            {
                if (value.Equals(null))
                {
                    throw new Exception();
                }
                orderId = value;
            }
        }

        public int CustomerId {
            get
            {
                return customerId;
            }
            set
            {
                if (value.Equals(null))
                {
                    throw new Exception();
                }
                customerId = value;
            }
        }
        // public byte OrderStatus {
        //     get
        //     {
        //         return orderStatus;
        //     }
        //     set
        //     {
        //         if (value.Equals(null))
        //         {
        //             throw new Exception();
        //         }
        //         orderStatus = value;
        //     }
        // }
        public DateTime OrderDate {
            get
            {
                return orderDate;
            }
            set
            {
                if (value.Equals(null))
                {
                    throw new Exception();
                }
                orderDate = value;
            }
        }
        // public DateTime RequiredDate {
        //     get
        //     {
        //         return requiredDate;
        //     }
        //     set
        //     {
        //         if (value.Equals(null))
        //         {
        //             throw new Exception();
        //         }
        //         requiredDate = value;
        //     }
        // }
        // [NotMapped]
        // public decimal Total
        // {
        //     get
        //     {
        //         if (Items == null) return 0;
        //         decimal x = 0;
        //         foreach (Item oi in Items)
        //         {
        //             x += oi.Total;
        //         }
        //         return x;
        //     }
        // }
        // public DateTime ShippedDate {
        //     get
        //     {
        //         return shippedDate;
        //     }
        //     set
        //     {
        //         if (value.Equals(null))
        //         {
        //             throw new Exception();
        //         }
        //         shippedDate = value;
        //     }
        // }
        public int? LocationId {
            get
            {
                return locationId;
            }
            set
            {
                if (value.Equals(null))
                {
                    throw new Exception();
                }
                locationId = value;
            }
        }
        // public int ManagerId {
        //     get
        //     {
        //         return managerId;
        //     }
        //     set
        //     {
        //         if (value.Equals(null))
        //         {
        //             throw new Exception();
        //         }
        //         managerId = value;
        //     }
        // }
        // public override string ToString()
        // {
        //     return $"Order# {OrderId}\nTotal Amount: {Total}";
        // }

    }
}
