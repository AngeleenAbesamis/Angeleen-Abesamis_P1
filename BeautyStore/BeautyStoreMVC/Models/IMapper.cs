using BeautyStore.BeautyStoreModels;

namespace BeautyStoreMVC.Models
{
    public interface IMapper
    {
        CusIndexVM parseCustomerToVM(Customer customer2BCasted);
        Customer parseToCust(CreateCustomerVM customer2BCasted);
        CreateCustomerVM parseToCCVM(Customer customer2BCasted);
    }
}
