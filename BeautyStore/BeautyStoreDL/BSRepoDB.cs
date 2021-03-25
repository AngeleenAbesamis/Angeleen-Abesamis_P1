using BeautyStore.BeautyStoreModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeautyStoreDL
{
    public class BSRepoDB : IBeautyStoreRepo
    {
        private readonly BeautyStoreDBContext _context;
        public BSRepoDB(BeautyStoreDBContext context)
        {
            _context = context;
        }


        public Customer AddCustomer(Customer customerName)
        {
            _context.Customers.Add(customerName);
            _context.SaveChanges();
            return customerName;
        }

        public Customer DeleteCustomer(Customer customer2BDeleted)
        {
            _context.Customers.Remove(customer2BDeleted);
            _context.SaveChanges();
            return customer2BDeleted;
        }

        public Item AddItem(Item newItem)
        {
            _context.Items.Add(newItem);
            _context.SaveChanges();
            return newItem;
        }

        public Order AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        public Customer GetCustomerByName(string name)
        {
            return _context.Customers
                .AsNoTracking()
                .FirstOrDefault(cust => cust.CustomerName.ToLower().Equals(name.ToLower()));
        }

        public List<Customer> GetCustomers()
        {
            return _context.Customers
                .AsNoTracking()
                .Select(cust => cust)
                .ToList();
        }

        //public List<Inventory> GetInventories()
        //{
        //    List<Inventory> invs = _context.Inventories
        //        .AsNoTracking()
        //        .Select(inv => inv)
        //        .ToList();
        //    foreach (Inventory i in invs)
        //    {
        //        i.BeautyProduct = GetProductByID(i.ProductId);
        //    }

        //    return invs;
        //}

        public Customer GetCustomerByEmail(string email)
        {
            return _context.Customers
                .AsNoTracking()
                .FirstOrDefault(cust => cust.EmailAddress.ToLower().Equals(email.ToLower()));
        }

        public List<Item> GetItems()
        {
            return _context.Items
                .AsNoTracking()
                .Select(itm => itm)
                .ToList();
        }

        public List<Location> GetLocations()
        {
            return _context.Locations
                .AsNoTracking()
                .Select(location => location)
                .ToList();
        }

        public Manager GetManagerByID(int managerId)
        {
            return _context.Managers
                .AsNoTracking()
                .FirstOrDefault(Manager => Manager.ManagerID == managerId);
        }

        public List<Manager> GetManagers()
        {
            return _context.Managers
                .AsNoTracking()
                .Select(admin => admin)
                .ToList();
        }

        public List<Order> GetOrders()
        {
            return _context.Orders
                .AsNoTracking()
                .Select(o => o)
                .ToList();
        }

        public BeautyProduct GetProductByID(int? idNum)
        {
            return _context.BeautyProducts
                .AsNoTracking()
                .FirstOrDefault(p => p.ProductId == idNum);
        }

        public List<BeautyProduct> GetProducts()
        {
            return _context.BeautyProducts
                .AsNoTracking()
                .Select(p => p)
                .ToList();
        }


        public Inventory RemoveInventory(Inventory selectedInventory, int quantity)
        {
            Inventory newInv = selectedInventory;

            newInv.Quantity -= quantity;
            ReplenishInventory(newInv);

            return selectedInventory;
        }

        public List<Order> GetOrdersByLocation(string name)
        {
            Location l = _context.Locations
                .AsNoTracking()
                .FirstOrDefault(l => l.LocationName.ToLower().Equals(name.ToLower()));

            return _context.Orders
                .AsNoTracking()
                .Where(o => o.LocationId == l.LocationId)
                .ToList();
        }

        public List<Order> GetOrdersByCustomer(string email)
        {
            Customer c = _context.Customers
                .AsNoTracking()
                .FirstOrDefault(c => c.EmailAddress.ToLower().Equals(email.ToLower()));

            return _context.Orders
                .AsNoTracking()
                .Where(o => o.CustomerId == c.CustomerID)
                .ToList();
        }

        public bool CustomerExists(string email/*, string pass*/)
        {
            try
            {
                return _context.Customers.AsNoTracking().FirstOrDefault(cust => cust.EmailAddress.ToLower().Equals(email.ToLower())) != null;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public Inventory AddInventory(Inventory newInventory)
        {
            _context.Inventories.Add(newInventory);
            _context.SaveChanges();
            return newInventory;
        }

        public Inventory ReplenishInventory(Inventory inv)
        {
            try
            {
                Inventory oldInv = _context.Inventories
                    .FirstOrDefault(i => i.InventoriesId == inv.InventoriesId);

                _context.Entry(oldInv).CurrentValues.SetValues(inv);

                _context.SaveChanges();
                _context.ChangeTracker.Clear();

                return inv;
            }
            catch (Exception)
            {
                //Log.Error("That product is not in stock at the selected location!");
                AddInventory(inv);
                return inv;
            }
        }
    }
}
