using BurgerApp.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BurgerStoreApp.Controllers
{
    public class BurgerController : Controller
    {
        private readonly BurgerDbContext _dbContext;

        public BurgerController(BurgerDbContext context)
        {
            _dbContext = context;
        }

        public async Task<IActionResult> BurgerMenu()
        {
            List<Burger> burgers = await _dbContext.Burgers.ToListAsync();
            return View(burgers);
        }

        public async Task<IActionResult> DeleteBurgerById([FromRoute] int? id)
        {
            if (id == null)
                return View("AnErrorOccurred");

            Burger burgerToDelete = await _dbContext.Burgers.FindAsync(id);

            if (burgerToDelete == null)
                return View("AnErrorOccurred");

            _dbContext.Burgers.Remove(burgerToDelete);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("BurgerMenu");
        }

        public async Task<IActionResult> EditBurger([FromRoute] int? id)
        {
            if (id == null)
                return View("AnErrorOccurred");

            Burger burgerToEdit = await _dbContext.Burgers.FindAsync(id);

            if (burgerToEdit == null)
                return View("AnErrorOccurred");

            return View(burgerToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> EditBurger([FromForm] Burger burger)
        {
            if (!ModelState.IsValid)
                return View(burger);

            var existingBurger = await _dbContext.Burgers.FindAsync(burger.Id);
            if (existingBurger == null)
                return RedirectToAction("BurgerMenu");

            existingBurger.Name = burger.Name;
            existingBurger.Price = burger.Price;
            existingBurger.IsVegetarian = burger.IsVegetarian;
            existingBurger.IsVegan = burger.IsVegan;
            existingBurger.HasFries = burger.HasFries;

            _dbContext.Burgers.Update(existingBurger);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("BurgerMenu");
        }

        public IActionResult CreateBurger()
        {
            return View(new Burger { });
        }

        [HttpPost]
        public async Task<IActionResult> CreateBurger([FromForm] Burger burger)
        {
            if (!ModelState.IsValid)
                return View(burger);

            _dbContext.Burgers.Add(burger);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("BurgerMenu");
        }
    }
}
