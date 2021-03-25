using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeautyStore.BeautyStoreModels;
using BeautyStoreDL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BeautyStoreMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BeautyProductsController : Controller
    {
        private readonly BeautyStoreDBContext _context;

        public BeautyProductsController(BeautyStoreDBContext context)
        {
            _context = context;
        }

        // GET: BeautyProducts
        public async Task<IActionResult> Index()
        {
            return View(await _context.BeautyProducts.ToListAsync());
        }

        // GET: BeautyProducts/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: BeautyProducts/Create
        public IActionResult Create()
        {
            ViewData["InventoriesId"] = new SelectList(_context.Inventories, "InventoriesId", "InventoryTitle");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,Price,Brands,Sizes,Description,InventoriesId")] BeautyProduct beautyProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(beautyProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(beautyProduct);
        }

        // GET: BeautyProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var beautyProduct = await _context.BeautyProducts.FindAsync(id);
            if (beautyProduct == null)
            {
                return NotFound();
            }
            ViewData["InventoriesId"] = new SelectList(_context.Inventories, "InventoriesId", "InventoryTitle", beautyProduct.InventoriesId);
            return View(beautyProduct);
        }

        // POST: BeautyProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Photo,ProductId,ProductName,Price,Brands,Sizes,Description,InventoriesId")] BeautyProduct beautyProduct)
        {
            if (id != beautyProduct.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beautyProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeautyProductExists(beautyProduct.ProductId))
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
            return View(beautyProduct);
        }

        // GET: BeautyProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: BeautyProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var beautyProduct = await _context.BeautyProducts.FindAsync(id);
            _context.BeautyProducts.Remove(beautyProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BeautyProductExists(int id)
        {
            return _context.BeautyProducts.Any(e => e.ProductId == id);
        }
    }
}
