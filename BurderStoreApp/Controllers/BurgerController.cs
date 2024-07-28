using BurgerApp;
using BurgerApp.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BurgerStoreApp.Controllers
{
    public class BurgerController : Controller
    {
        public IActionResult BurgerMenu()
        {
            List<Burger> burgers = StaticDb.Burgers;
            return View(burgers);
        }
        public IActionResult DeleteBurgerById([FromRoute] int? id)
        {
            if (id == null)
                return View("AnErrorOccurred");

            Burger burgerToDelete = StaticDb.Burgers.FirstOrDefault(x => x.Id == id);

            if (burgerToDelete == null)
                return View("AnErrorOccurred");

            StaticDb.Burgers.Remove(burgerToDelete);

            return RedirectToAction("BurgerMenu");

        }
        public IActionResult EditBurger([FromRoute] int? id)
        {
            if (id == null)
                return View("AnErrorOccurred");

            Burger burgerToEdit = StaticDb.Burgers.FirstOrDefault(x => x.Id == id);

            if (burgerToEdit == null)
                return View("AnErrorOccurred");

            return View(burgerToEdit);
        }
        [HttpPost]
        public IActionResult EditBurger([FromForm] Burger burger)
        {
            if (!ModelState.IsValid)
                return View(burger);
            Burger existingBurger = StaticDb.Burgers.FirstOrDefault(x => x.Id == burger.Id);
            if (existingBurger == null)
                return RedirectToAction("BurgerMenu");

            existingBurger.Name = burger.Name;
            existingBurger.Price = burger.Price;
            existingBurger.IsVegetarian = burger.IsVegetarian;
            existingBurger.IsVegan = burger.IsVegan;
            existingBurger.HasFries = burger.HasFries;

            return RedirectToAction("BurgerMenu");

        }
        public IActionResult CreateBurger()
        {
            return View(new Burger { });
        }
        [HttpPost]
        public IActionResult CreateBurger([FromForm] Burger burger)
        {
            if (!ModelState.IsValid)
                return View(burger);

            burger.Id = (StaticDb.Burgers.LastOrDefault()?.Id ?? 0)+ 1;
            StaticDb.Burgers.Add(burger);

            return RedirectToAction("BurgerMenu");
        }
    }
}
