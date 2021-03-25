using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeautyStore.BeautyStoreModels;
using BeautyStoreDL;
using Microsoft.AspNetCore.Authorization;
using BeautyStoreMVC.Models;

namespace BeautyStoreMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LocationsController : Controller
    {
        private readonly BeautyStoreDBContext _context;

        public LocationsController(BeautyStoreDBContext context)
        {
            _context = context;
        }

        // GET: Locations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Locations.ToListAsync());
        }

        public IActionResult OrdersHistory(int? id)
        {
            List<Item> OrdersList = new List<Item>();

            var ListofInventories = _context.Inventories.Where(x => x.LocationId == id).Select(x => x.InventoriesId).ToArray();

            foreach (var InventoryId in ListofInventories)
            {
                var ListofProducts = _context.BeautyProducts.Where(x => x.InventoriesId == InventoryId).Select(x => x.ProductId).ToArray();

                foreach (var ProductId in ListofProducts)
                {
                    List<Item> ListofOrders = _context.Items.Where(x => x.BeautyProductsProductId == ProductId).ToList();

                    foreach (var OrderItem in ListofOrders)
                    {
                        if(!OrdersList.Where(x=>x.OrderId == OrderItem.OrderId).Any())
                        {
                            OrdersList.Add(OrderItem);
                        }
                    }
                }
            }

            List<LocationHistoriesModel> historyList = new List<LocationHistoriesModel>();

            foreach (var item in OrdersList)
            {
                LocationHistoriesModel obj = new LocationHistoriesModel();
                obj.OrderId = item.OrderId;
                obj.CustomerName = _context.Customers.Where(x => x.CustomerID == item.CustomerId).First().CustomerName;
                obj.OrderDate = _context.Orders.Where(x => x.OrderId == item.OrderId).First().OrderDate;
                obj.OrderPrice = CalculatePrice(item.OrderId);
                historyList.Add(obj);
            }

            return View(historyList);
        }

        private decimal? CalculatePrice(int? orderId)
        {
            decimal? tOTALqUANTITY = 0;
            var ListofItems = _context.Items.Where(x => x.OrderId == orderId).ToList();
            
            foreach (var item in ListofItems)
            {
                int? Quantity = item.Quantity;
                var price = _context.BeautyProducts.Where(x => x.ProductId == item.BeautyProductsProductId).FirstOrDefault().Price;

                tOTALqUANTITY = tOTALqUANTITY + (Quantity * price);
            }

            return tOTALqUANTITY;
        }

        // GET: Locations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Locations
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // GET: Locations/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationId,Address,LocationName")] Location location)
        {
            if (ModelState.IsValid)
            {
                _context.Add(location);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(location);
        }

        // GET: Locations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }
            return View(location);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocationId,Address,LocationName")] Location location)
        {
            if (id != location.LocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(location);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationExists(location.LocationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(location);
        }

        // GET: Locations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Locations
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationExists(int id)
        {
            return _context.Locations.Any(e => e.LocationId == id);
        }
    }
}
