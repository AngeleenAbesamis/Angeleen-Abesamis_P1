using BeautyStore.BeautyStoreModels;
using System;
using System.Collections.Generic;
using BeautyStoreDL;

namespace BeautyStoreBL
{
    public class beautyStoreBL : IBeautyStoreBL
    {
        private IBeautyStoreRepo _repo;

        public beautyStoreBL(IBeautyStoreRepo repo)
        {
            _repo = repo;
        }

        public void AddCustomer(Customer custName)
        {
            _repo.AddCustomer(custName);
        }

        public void AddOrder(Order order)
        {
            _repo.AddOrder(order);
        }

        public Item AddItem(Item newItem)
        {
            return _repo.AddItem(newItem);
        }

        public BeautyProduct GetBeautyProductByID(int idNum)
        {
            return _repo.GetProductByID(idNum);
        }

        public Location GetLocationById(int id)
        {
            throw new NotImplementedException();
        }

        public List<BeautyProduct> GetBeautyProducts()
        {
            return _repo.GetProducts();
        }

        public Customer GetCustomerByName(string name)
        {
            //TODO: CHECK FOR INPUT VALIDATION (NULL/EMPTY)
            return _repo.GetCustomerByName(name);
        }

        public List<Customer> GetCustomers()
        {
            return _repo.GetCustomers();
        }

        //public List<Inventory> GetInventories()
        //{
        //    return _repo.GetInventories();
        //}

        public List<Item> GetItems()
        {
            return _repo.GetItems();
        }

        public List<Location> GetLocations()
        {
            return _repo.GetLocations();
        }

        public List<Order> GetOrders()
        {
            return _repo.GetOrders();
        }

        public List<Manager> GetManagers()
        {
            return _repo.GetManagers();
        }
        public Manager GetManagerByID(int managerId)
        {
            return _repo.GetManagerByID(managerId);
        }

        public Customer DeleteCustomer(Customer customer2BDeleted)
        {
            return _repo.DeleteCustomer(customer2BDeleted);
        }

        public List<Order> GetOrdersByCustomer(string email)
        {
            return _repo.GetOrdersByCustomer(email);
        }

        public List<Order> GetOrdersByLocation(string name)
        {
            return _repo.GetOrdersByLocation(name);
        }

        public List<BeautyProduct> GetProducts()
        {
            return _repo.GetProducts();
        }

        public BeautyProduct GetProductByID(int num)
        {
            return _repo.GetProductByID(num);
        }

        public bool CustomerExists(string email)
        {
            return _repo.CustomerExists(email/*, pass*/);
        }

        public Inventory ReplenishInventory(Inventory inv)
        {
            return _repo.ReplenishInventory(inv);
        }

       

        public Inventory RemoveInventory(Inventory selectedInventory, int quantity)
        {
            return _repo.RemoveInventory(selectedInventory, quantity);
        }

        public Customer GetCustomerByEmail(string email)
        {
            return _repo.GetCustomerByEmail(email);
        }

        public Inventory AddInventory(Inventory newInventory)
        {
            return _repo.AddInventory(newInventory);
        }
    }
}
