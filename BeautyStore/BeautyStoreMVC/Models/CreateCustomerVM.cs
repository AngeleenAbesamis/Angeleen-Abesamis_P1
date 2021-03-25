using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BeautyStoreMVC.Models
{
    public class CreateCustomerVM
    {
        [Required]
        public string CustomerName { get; set; }

        [DisplayName("Home Address")]
        [Required]
        public string HomeAddress { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string EmailAddress { get; set; }
    }
}
