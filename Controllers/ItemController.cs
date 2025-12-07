using learn_entity_framework.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using learn_entity_framework.Models;
using learn_entity_framework.ViewModels;
using learn_entity_framework.Mapper;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace learn_entity_framework.Controllers
{
    public class ItemController : Controller
    {
        private MyAppContext context;
        public ItemController(MyAppContext context)
        {
            this.context = context;
        }

        // This is a simple select query, using EF => SELECT * FROM Items
        [Route("index")]
        // Ici on a travailler avec une fonction asynchrone, car cette requete peut prendre du temps si il ya 
        // plusieurs ligne dans la table, si on ne fait pas asynchrone function ici, il va bloquer touts les autres 
        // requets jusqu'a que ceci termine, et ca c'est mauvais pour la performance et le user experience 
        // N.B : Une fonction async return un Task<type>, et Task veut dire un Promise() dans js => je te promis
        // de returner un resultat plus tard 
        // On utilise le mot async pour definir que cette methode est async
        public async Task<IActionResult> Index()
        {
            // 1) Ici on mait le mot await pour cette ligne ca veut dire que n'execute pas la requete jusqu'a que cette 
            // ligne et terminer de la recuperation, dans un autre sense, il veut dire attendre moi
            // 2) Pour recuperer les donner on utilise la method ToList(), on ajouton Async dans ce cas
            List<Item> data = await context.Items.Include(s => s.SerialNumber)
                                                 .Include(s => s.Category).ToListAsync();

            // Ici on peut utiliser plusieurs methodes pour communiquer avec le View, la bonne c'est passer 
            // l'objet dans le view, et le recuperer avec @model List<type d'objet> et travailler avec le var Model
            //ViewBag.items = data;

            return View(data);
            // N.B : Generalement on utilise les mehtodes async quand il ya une requete qui va prendre du temps ex : 
            // consommation api, recuperation donnes dans une base de donne 
            // N.B : Utilise await quand la methode qui fait le traitement peut terminer avec Async, ex : ToListAsync
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            // To display all categories, there is 2 methods : 
            // 1) 
            //List<Category> category = await context.Category.ToListAsync();
            //ViewBag.category = category;

            // 2) Doesnt need to made foreach in razor 
            ViewData["category"] = new SelectList(context.Category, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Store(ItemVM itemvm)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Create));
            }

            Item item = ItemMP.AffectItemVMToItem(itemvm);
            context.Items.Add(item);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        //[ValidateAntiForgeryToken]
        [HttpGet]
        [Route("edit")]
        public IActionResult Edit(int id)
        {
            Item item = context.Items.Find(id);
            if (item == null)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewData["category"] = new SelectList(context.Category, "Id", "Name", item.CategoryId);
            ViewBag.item = item;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, ItemVM itemvm)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Edit));
            }

            // 1) Using Update to update the data, but pay att if the item in the mappage doesent affect the id to the
            // item
            Item item = ItemMP.AffectItemVMToItem(itemvm, id);
            context.Items.Update(item);

            // 2) Or find the ligne who contain the similar id, and change every attribut
            //Item itemdb = context.Items.Find(id);
            //itemdb.Nom = item.Nom;
            //itemdb.Price = item.Price;

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Item item = context.Items.Find(id);
            if (item == null)
            {
                return RedirectToAction(nameof(Index));
            }
            context.Items.Remove(item);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
