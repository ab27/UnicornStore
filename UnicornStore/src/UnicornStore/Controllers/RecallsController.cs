using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using UnicornStore.AspNet.Models.UnicornStore;

namespace UnicornStore.Controllers
{
    public class RecallsController : Controller
    {
        private UnicornStoreContext db;

        public RecallsController(UnicornStoreContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            // TODO Query for all Recalls
            var recalls = new List<Recall>();

            return View(recalls);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Recall recall)
        {
            if (ModelState.IsValid)
            {
                // TODO Add the new Recall and save


                return RedirectToAction("Index");
            }

            return View(recall);
        }
    }
}
