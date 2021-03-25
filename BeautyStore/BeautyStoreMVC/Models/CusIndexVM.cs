using BeautyStore.BeautyStoreModels;
using System.Collections.Generic;

namespace BeautyStoreMVC.Models
{
    public class CusIndexVM
    {
        public string CustomerName { get; set; }
        public string HomeAddress { get; set; }
        public int CustomerId { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public List<Order> orderHistory { get; set; }
    }
}
