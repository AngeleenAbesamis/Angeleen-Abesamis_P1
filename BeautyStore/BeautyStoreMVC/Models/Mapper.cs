using BeautyStore.BeautyStoreModels;

namespace BeautyStoreMVC.Models
{
    public class Mapper : IMapper
    {
        public CusIndexVM parseCustomerToVM(Customer customer2BCasted)
        {
            return new CusIndexVM
            {
                CustomerName = customer2BCasted.CustomerName,
                HomeAddress = customer2BCasted.HomeAddress,
                CustomerId = customer2BCasted.CustomerID,
                PhoneNumber = customer2BCasted.PhoneNumber,
                EmailAddress = customer2BCasted.EmailAddress
            };
        }

        public CreateCustomerVM parseToCCVM(Customer customer2BCasted)
        {
            return new CreateCustomerVM()
            {
                CustomerName = customer2BCasted.CustomerName,
                HomeAddress = customer2BCasted.HomeAddress,
                PhoneNumber = customer2BCasted.PhoneNumber,
                EmailAddress = customer2BCasted.EmailAddress
            };
        }

        public Customer parseToCust(CreateCustomerVM customer2BCasted)
        {
            return new Customer
            {
                CustomerName = customer2BCasted.CustomerName,
                HomeAddress = customer2BCasted.HomeAddress,
                PhoneNumber = customer2BCasted.PhoneNumber,
                EmailAddress = customer2BCasted.EmailAddress
            };
        }
    }
}
