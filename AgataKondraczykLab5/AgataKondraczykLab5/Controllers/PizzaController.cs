using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgataKondraczykLab5.Models;

namespace AgataKondraczykLab5.Controllers
{
    public class PizzaController : Controller
    {
        // GET: Pizza
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            List<Pizza> pizzas;
            using (var ctx = new EFDbContext())
            {
                pizzas = ctx.Pizzas.ToList();
            }
            return View(pizzas);
        }

        public ActionResult Add()
        {
            return View(new Pizza());
        }

        [HttpPost]
        public ActionResult Add(Pizza pizza)
        {
            if (!ModelState.IsValid)
            {
                return View(new Pizza());
            }
            using (var ctx = new EFDbContext())
            {
                ctx.Pizzas.Add(pizza);
                ctx.SaveChanges();
            }
            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            Pizza pizza;
            using (var ctx = new EFDbContext())
            {
                pizza = ctx.Pizzas.FirstOrDefault(p => p.Id == id);

            }
            return View(pizza);
        }

        [HttpPost]
        public ActionResult Edit(Pizza model, int id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit");
            }
            Pizza pizza;
            using (var ctx = new EFDbContext())
            {
                pizza = ctx.Pizzas.FirstOrDefault(p => p.Id == id);
                pizza.Name = model.Name;
                pizza.Ingredients = model.Ingredients;
                ctx.SaveChanges();
            }
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            using (var ctx = new EFDbContext())
            {
                ctx.Pizzas.Remove(ctx.Pizzas.First(x=> x.Id==id));
                ctx.SaveChanges();

            }
            return RedirectToAction("List");
        }

        public ActionResult AddToCart(int[] selectedPizzas)
        {
            var list = new List<Pizza>();
            using (var ctx = new EFDbContext())
            {
                

                foreach (var id in selectedPizzas)
                {
                list.Add(ctx.Pizzas.First(x => x.Id == id));

                }

            }

            return RedirectToAction("AddToShoppingCart","ShoppingCart",list);
        }
    }
}