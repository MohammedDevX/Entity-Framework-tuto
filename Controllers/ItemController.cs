using learn_entity_framework.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using learn_entity_framework.Models;

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
        // N.B : Une fonction async return un Task<type>
        // On utilise le mot async pour definir que cette methode est async
        public async Task<IActionResult> Index()
        {
            // 1) Ici on mait le mot await pour cette ligne ca veut dire que n'execute pas la requete jusqu'a que cette 
            // ligne et terminer de la recuperation, dans un autre sense, il veut dire attendre moi
            // 2) Pour recuperer les donner on utilise la method ToList(), on ajouton Async dans ce cas
            var data = await context.Items.ToListAsync();

            // Ici on peut utiliser plusieurs methodes pour communiquer avec le View, la bonne c'est passer 
            // l'objet dans le view, et le recuperer avec @model List<type d'objet> et travailler avec le var Model
            //ViewBag.items = data;

            return View(data);
            // N.B : Generalement on utilise les mehtodes async quand il ya une requete qui va prendre du temps ex : 
            // consommation api, recuperation donnes dans une base de donne 
        }

        [ValidateAntiForgeryToken]
        [Route("edit")]
        public IActionResult Edit(int id)
        {
            ViewBag.id = id;
            return View();
        }
    }
}
