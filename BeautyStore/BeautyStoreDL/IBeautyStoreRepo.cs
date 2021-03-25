using System.Collections.Generic;
using BeautyStore.BeautyStoreModels;

namespace BeautyStoreDL
{
    public interface IBeautyStoreRepo
    {
        List<Customer> GetCustomers();
        Customer AddCustomer(Customer customerName);
        Customer GetCustomerByName(string name);
        Customer DeleteCustomer(Customer customer2BDeleted);
        Order AddOrder(Order order);
        List<Order> GetOrders();
        List<Item> GetItems();
        Item AddItem(Item newItem);
        List<Location> GetLocations();
        List<BeautyProduct> GetProducts();
        BeautyProduct GetProductByID(int? idNum);
     //   List<Inventory> GetInventories();
        Inventory ReplenishInventory(Inventory inventory);
        List<Manager> GetManagers();
        Manager GetManagerByID(int managerId);
        Customer GetCustomerByEmail(string email);
        bool CustomerExists(string email/*, string pass*/);
        List<Order> GetOrdersByCustomer(string email);
        List<Order> GetOrdersByLocation(string name);
        Inventory RemoveInventory(Inventory selectedInventory, int quantity);
        Inventory AddInventory(Inventory newInventory);
    }
}
