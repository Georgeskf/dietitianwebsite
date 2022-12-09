using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dietitianwebsite.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dietitianwebsite.Data;
using Dietitianwebsite.Models;
using Microsoft.AspNetCore.Identity;

namespace nuttrionApp.Controllers
{
    public class FoodsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserManager<IdentityUser> UserManager { get; set; }

        public FoodsController(UserManager<IdentityUser> userManager,ApplicationDbContext context)
        {
            UserManager = userManager;

            _context = context;
        }

        // GET: Foods
        public async Task<IActionResult> Index()
        {
            var userid=UserManager.GetUserId(HttpContext.User);
            var data = await _context.Food.Where(q => q.userid == userid).ToListAsync();
            return View(data);
        }
        public async Task<IActionResult> editFood()
        {
            var userid = UserManager.GetUserId(HttpContext.User);
            var data = await _context.Food.Where(q => q.userid == userid).ToListAsync();
            return View(data);
        }
        // GET: Foods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Food == null)
            {
                return NotFound();
            }

            var food = await _context.Food
                .FirstOrDefaultAsync(m => m.Id == id);
            if (food == null)
            {
                return NotFound();
            }

            return View(food);
        }

        // GET: Foods/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var userid = UserManager.GetUserId(HttpContext.User);
            var data = await _context.Food.Where(q => q.userid == userid).ToListAsync();
            return View(data);
        }
        public IActionResult LogFood()
        {
            return View();
        }
        // POST: Foods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Kcal,Protein,Carbs,Fat"),] Food food)
        {
            System.Diagnostics.Debug.WriteLine(food.Name);
            Food f1=new Food();
            f1.userid = UserManager.GetUserId(HttpContext.User);
            f1.Id = food.Id;
            f1.Name = food.Name;
            f1.Kcal = food.Kcal;
            f1.Protein = food.Protein;
            f1.Carbs = food.Carbs;
            f1.Fat = food.Fat;


            {
                _context.Add(f1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Profile));
            }
            return View(food);
        }

        // GET: Foods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Food == null)
            {
                return NotFound();
            }

            var food = await _context.Food.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }
            return View(food);
        }

        // POST: Foods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Kcal,Protein,Carbs,Fat")] Food food)
        {
            if (id != food.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(food);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodExists(food.Id))
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
            return View(food);
        }

        // GET: Foods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Food == null)
            {
                return NotFound();
            }

            var food = await _context.Food
                .FirstOrDefaultAsync(m => m.Id == id);
            if (food == null)
            {
                return NotFound();
            }

            return View(food);
        }

        // POST: Foods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Food == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Food'  is null.");
            }
            var food = await _context.Food.FindAsync(id);
            if (food != null)
            {
                _context.Food.Remove(food);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodExists(int id)
        {
            return _context.Food.Any(e => e.Id == id);
        }
    }
}