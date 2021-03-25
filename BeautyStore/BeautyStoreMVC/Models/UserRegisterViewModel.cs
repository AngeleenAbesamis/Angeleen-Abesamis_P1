using System.ComponentModel.DataAnnotations;

namespace BeautyStoreMVC.Models
{
    public class UserRegisterViewModel
    {

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }


        [Display(Name = "Home Address")]
        [Required(ErrorMessage = "Home Address is required.")]
        public string HomeAddress { get; set; }

        [Display(Name = "Billing Address")]
        //[Required(ErrorMessage = "Billing Address is required.")]
        public string BillingAddress { get; set; }

        [Display(Name = "Phone Number")]
        //[Required(ErrorMessage = "Billing Address is required.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required.")]
        [Display(Name = "Confirm " +
                        "Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password Confirm Password do not match")]
        public string ConfirmPassword { get; set; }
    }
}
