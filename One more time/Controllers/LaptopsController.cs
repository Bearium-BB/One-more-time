using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using One_more_time.Data;
using One_more_time.Models.Table;
using One_more_time.Models.Form;

namespace One_more_time.Controllers
{
    public class LaptopsController : Controller
    {
        private readonly LaptopShopContext _context;

        public LaptopsController(LaptopShopContext context)
        {
            _context = context;
        }

        // GET: Laptops
        public async Task<IActionResult> Index()
        {
            var laptopShopContext = _context.Laptops.Include(l => l.Brand);
            return View(await laptopShopContext.ToListAsync());
        }

        public async Task<IActionResult> ViewAllBrandsAndLaptops()
        {
            var laptopShopContext = _context.Laptops.Include(l => l.Brand);
            return View(await laptopShopContext.OrderBy(b => b.Brand.Name).ToListAsync());
        }

        // GET: Laptops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Laptops == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptops
                .Include(l => l.Brand)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (laptop == null)
            {
                return NotFound();
            }

            return View(laptop);
        }

        // GET: Laptops/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Bands, "Id", "Id");
            return View();
        }

        // POST: Laptops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Model,Id,BrandId,Price,Year,Img")] Laptop laptop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(laptop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Bands, "Id", "Id", laptop.BrandId);
            return View(laptop);
        }

        // GET: Laptops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Laptops == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptops.FindAsync(id);
            if (laptop == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Bands, "Id", "Id", laptop.BrandId);
            return View(laptop);
        }

        // POST: Laptops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Model,Id,BrandId,Price,Year,Img")] Laptop laptop)
        {
            if (id != laptop.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(laptop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaptopExists(laptop.Id))
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
            ViewData["BrandId"] = new SelectList(_context.Bands, "Id", "Id", laptop.BrandId);
            return View(laptop);
        }

        // GET: Laptops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Laptops == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptops
                .Include(l => l.Brand)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (laptop == null)
            {
                return NotFound();
            }

            return View(laptop);
        }

        // POST: Laptops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Laptops == null)
            {
                return Problem("Entity set 'LaptopShopContext.Laptops'  is null.");
            }
            var laptop = await _context.Laptops.FindAsync(id);
            if (laptop != null)
            {
                _context.Laptops.Remove(laptop);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaptopExists(int id)
        {
          return _context.Laptops.Any(e => e.Id == id);
        }

        public IActionResult LaptopsInBudget()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LaptopsInBudget(LaptopsInBudgetForm query)
        {
            ViewBag.data = _context.Laptops.Include(l => l.Brand).Where(x => x.Price <= query.Number).ToList();
            return View();
        }


        public IActionResult MostExpensiveLaptops()
        {
            return View(_context.Laptops.OrderByDescending(x => x.Price).Include(l => l.Brand).Take(2).ToList());
        }
        public IActionResult CheapestLaptops()
        {
            return View(_context.Laptops.OrderBy(x => x.Price).Include(l => l.Brand).Take(3).ToList());
        }

        public IActionResult CompareTwoLaptops()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            for (int i = 0; i < _context.Laptops.Count(); i++)
            {
                items.Add(new SelectListItem { Text = $"{_context.Laptops.ToList()[i].Model}", Value = $"{_context.Laptops.ToList()[i].Id}" });
            }
            ViewBag.items = new SelectList(items, "Value", "Text");
            return View();
        }

        [HttpPost]
        public IActionResult CompareTwoLaptops(CompareTwoLaptopsForm query)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            for (int i = 0; i < _context.Laptops.Count(); i++)
            {
                items.Add(new SelectListItem { Text = $"{_context.Laptops.ToList()[i].Model}", Value = $"{_context.Laptops.ToList()[i].Id}" });
            }
            ViewBag.items = new SelectList(items, "Value", "Text");

            ViewBag.Value1 = _context.Laptops.OrderBy(l => l.Id).Include(l => l.Brand).First(l => l.Id == query.SelectedValue1);
            ViewBag.Value2 = _context.Laptops.OrderBy(l => l.Id).Include(l => l.Brand).First(l => l.Id == query.SelectedValue2);

            return View();
        }

        public IActionResult ViewLaptopsByBrand()
        {
            List<SelectListItem> Branditems = new List<SelectListItem>();
            for (int i = 0; i < _context.Bands.Count(); i++)
            {
                Branditems.Add(new SelectListItem { Text = $"{_context.Bands.ToList()[i].Name}", Value = $"{_context.Bands.ToList()[i].Id}" });
            }
            ViewBag.BrandItems = new SelectList(Branditems, "Value", "Text");

            var OrderingItems = new[]
            {
                new SelectListItem{Text = "Order By Higest Price", Value = "0"},
                new SelectListItem{Text = "Order By Lowest Price", Value = "1"},
                new SelectListItem{Text = "Order By Newest", Value = "2"},
                new SelectListItem{Text = "Order By Oldest", Value = "3"},


            };
            ViewBag.OrderingItems = new SelectList(OrderingItems, "Value", "Text");

            return View();
        }

        [HttpPost]
        public IActionResult ViewLaptopsByBrand(ViewLaptopsByBrandForm query)
        {
            if (ModelState.IsValid)
            {
                if (query.NumberMin == null)
                {
                    query.NumberMin = 0;
                }

                if (query.NumberMax == null)
                {
                    query.NumberMax = 100000;
                }

                if (query.YearMin == null)
                {
                    query.YearMin = 0;
                }

                if (query.YearMax == null)
                {
                    query.YearMax = 2050;
                }
                List<SelectListItem> Branditems = new List<SelectListItem>();
                for (int i = 0; i < _context.Bands.Count(); i++)
                {
                    Branditems.Add(new SelectListItem { Text = $"{_context.Bands.ToList()[i].Name}", Value = $"{_context.Bands.ToList()[i].Id}" });
                }
                ViewBag.BrandItems = new SelectList(Branditems, "Value", "Text");

                List<Laptop> temp = _context.Bands.Include(b => b.Laptops).Where(b => b.Id == query.Brand).First().Laptops.ToList();


                switch (query.Ordering)
                {
                    case "0":
                        temp = temp.OrderByDescending(x => x.Price).ToList();
                        break;
                    case "1":
                        temp = temp.OrderBy(x => x.Price).ToList();
                        break;
                    case "2":
                        temp = temp.OrderByDescending(x => x.Year).ToList();
                        break;
                    case "3":
                        temp = temp.OrderBy(x => x.Year).ToList();
                        break;
                    default:
                        break;
                }
                temp = temp.Where(x => x.Price <= query.NumberMax).ToList();
                temp = temp.Where(x => x.Price >= query.NumberMin).ToList();
                temp = temp.Where(x => x.Year <= query.YearMax).ToList();
                temp = temp.Where(x => x.Year >= query.YearMin).ToList();
                ViewBag.data = temp;
            }

            var OrderingItems = new[]
{
                new SelectListItem{Text = "Order By Higest Price", Value = "0"},
                new SelectListItem{Text = "Order By Lowest Price", Value = "1"},
                new SelectListItem{Text = "Order By Newest", Value = "2"},
                new SelectListItem{Text = "Order By Oldest", Value = "3"},
            };

            ViewBag.OrderingItems = new SelectList(OrderingItems, "Value", "Text");
            return View();
        }
    }
}
