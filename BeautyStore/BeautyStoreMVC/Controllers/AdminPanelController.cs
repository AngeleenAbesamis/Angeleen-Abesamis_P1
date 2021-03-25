using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyStoreDL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace BeautyStoreMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminPanelController : Controller
    {
        private readonly BeautyStoreDBContext _context;
        public AdminPanelController(BeautyStoreDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> SearchCustomers()
        {
            return View(await _context.Customers.ToListAsync());
        }

        public async Task<IActionResult> LocationHistory()
        {
            return View("Index");

            //   return View(await _context..ToListAsync());
        }

    }
}
