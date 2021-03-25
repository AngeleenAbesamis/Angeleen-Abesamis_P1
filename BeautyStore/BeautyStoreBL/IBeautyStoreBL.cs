using System.Collections.Generic;
using BeautyStore.BeautyStoreModels;

namespace BeautyStoreBL
{
    public interface IBeautyStoreBL
    {
        List<Customer> GetCustomers();
        void AddCustomer(Customer custName);
        Customer GetCustomerByName(string name);
        Customer DeleteCustomer(Customer customer2BDeleted);
        void AddOrder(Order order);
        List<Order> GetOrders();
        List<Location> GetLocations();
        List<BeautyProduct> GetBeautyProducts();
        BeautyProduct GetBeautyProductByID(int idNum);
        List<Item> GetItems();
        Item AddItem(Item newItem);
       // List<Inventory> GetInventories();
        List<Manager> GetManagers();
        Manager GetManagerByID(int managerId);
        List<Order> GetOrdersByCustomer(string email);
        List<Order> GetOrdersByLocation(string name);
        List<BeautyProduct> GetProducts();
        BeautyProduct GetProductByID(int num);
        bool CustomerExists(string email/*, string pass*/);
       // Inventory ReplenishInventory(Inventory inv);
       // Inventory AddToCart(Inventory selectedInventory, Customer cust, string quantity);
        Inventory RemoveInventory(Inventory selectedInventory, int quantity);
        Customer GetCustomerByEmail(string email);
        Inventory AddInventory(Inventory newInventory);
    }
}
