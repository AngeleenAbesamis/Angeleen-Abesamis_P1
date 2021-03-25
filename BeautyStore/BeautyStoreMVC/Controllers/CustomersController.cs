using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeautyStore.BeautyStoreModels;
using BeautyStoreDL;
using BeautyStoreBL;
using BeautyStoreMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;

namespace BeautyStoreMVC.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        private IMapper _mapper;
        private IBeautyStoreBL _beautyStoreBL;
        private Customer _customer;
        private Location _location;
        private readonly ILogger<HomeController> _logger;
        private readonly BeautyStoreDBContext _context;

        public CustomersController(IBeautyStoreBL bsbl, ILogger<HomeController> logger, BeautyStoreDBContext context)
        {
            _beautyStoreBL = bsbl;
            // _mapper = mapper;
            _logger = logger;
           _context = context;

        }

        // GET: Customers

        public async Task<IActionResult> Index()
        {
            return View(await _context.BeautyProducts.ToListAsync());
        }

        public IActionResult AddtoCart(int? id, int? QUantity)
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int customerId = _context.Customers.Where(x => x.IdentityID == userid).FirstOrDefault().CustomerID;

            Item item = new Item();
            if (QUantity == null)
            {
                QUantity = 1;
            }
            item.Quantity = (int)QUantity;
            item.BeautyProductsProductId = (int)id;
            item.CustomerId = customerId;
            _context.Items.Add(item);
            _context.SaveChanges();

            return RedirectToAction("ViewCart");
        }

        public IActionResult ViewCart()
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int customerId = _context.Customers.Where(x => x.IdentityID == userid).FirstOrDefault().CustomerID;

            var list = _context.Items.Where(x => x.CustomerId == customerId && x.OrderId == null).ToList();

            List<CreateProductViewModel> list2 = new List<CreateProductViewModel>();
            foreach (var item in list)
            {
                CreateProductViewModel obj = new CreateProductViewModel();
                obj.ItemId = item.ItemsId;
                obj.ProductName = GetProductName(item.BeautyProductsProductId);
                obj.ProductPrice = GetProductPrice(item.BeautyProductsProductId) * item.Quantity;
                obj.Quantity = item.Quantity;

                list2.Add(obj);

            }
            return View(list2);
        }

        private string GetProductName(int xProductId)
        {
            var  info = _context.BeautyProducts.First(y=>y.ProductId == xProductId);
            return info.ProductName;
        }

        private decimal GetProductPrice(int xProductId)
        {
            var info = _context.BeautyProducts.First(y => y.ProductId == xProductId);
            return info.Price;
        }

        public IActionResult RemoveFromCart(int? id)
        {

            Item item = _context.Items.First(x => x.ItemsId == id);
            _context.Items.Remove(item);
            _context.SaveChanges();

            return RedirectToAction("ViewCart");
        }

        public IActionResult PlaceOrder()
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int customerId = _context.Customers.Where(x => x.IdentityID == userid).FirstOrDefault().CustomerID;

            Order order = new Order();
            order.CustomerId = customerId;
            order.OrderDate = DateTime.Now;
            _context.Orders.Add(order);
            _context.SaveChanges();

            var list = _context.Items.Where(x => x.CustomerId == customerId && x.OrderId == null).ToList();
            foreach (var item in list)
            {
                item.OrderId = order.OrderId;
                _context.SaveChanges();
            }

            return RedirectToAction("CustomerOrdersHistory");
        }

        public IActionResult CustomerOrdersHistory()
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int customerId = _context.Customers.Where(x => x.IdentityID == userid).FirstOrDefault().CustomerID;

            var list = _context.Orders.Where(x => x.CustomerId == customerId).ToList();            
            List<OrderDetailsModel> OrdersList = new List<OrderDetailsModel>();
            
            foreach (var item in list)
            {
                OrderDetailsModel obj = new OrderDetailsModel();
                obj.OrderDate = item.OrderDate;
                obj.OrderId = item.OrderId;
                obj.price = CalculatePrice(item.OrderId);
                OrdersList.Add(obj);
            }

            return View(OrdersList);
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

        public IActionResult ViewOrderDetails(int? id)
        {
            var list = _context.Items.Where(x => x.OrderId == id).ToList();

            List<CreateProductViewModel> list2 = new List<CreateProductViewModel>();
            foreach (var item in list)
            {
                CreateProductViewModel obj = new CreateProductViewModel();
                obj.ProductId = item.BeautyProductsProductId;
                obj.ItemId = item.ItemsId;
                obj.ProductName = GetProductName(item.BeautyProductsProductId);
                obj.ProductPrice = GetProductPrice(item.BeautyProductsProductId) * item.Quantity;
                obj.Quantity = item.Quantity;

                list2.Add(obj);

            }
            return View(list2);
        }

        public async Task<IActionResult> VIewMoreProductDetails2(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beautyProduct = await _context.BeautyProducts
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (beautyProduct == null)
            {
                return NotFound();
            }

            return View(beautyProduct);
        }



        public async Task<IActionResult> VIewMoreProductDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beautyProduct = await _context.BeautyProducts
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (beautyProduct == null)
            {
                return NotFound();
            }

            return View(beautyProduct);
        }




        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerName,Password,CustomerID,EmailAddress,PhoneNumber,HomeAddress,BillingAddress")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerName,Password,CustomerID,EmailAddress,PhoneNumber,HomeAddress,BillingAddress")] Customer customer)
        {
            if (id != customer.CustomerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerID))
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
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerID == id);
        }
    }
}
