using polishHeroesWW2mvc.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Text.RegularExpressions;

namespace polishHeroesWW2mvc.Controllers
{
    public class HomeController : Controller
    {
        //database connection
        private WarHeroesEntities db = new WarHeroesEntities();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Intelligence()
        {
            var heroes = from h in db.Tbheroes
                         where h.Service == "Intelligence"
                         select h;
                      
            return View(heroes);
        }
        public ActionResult Technology()
        {
            var heroes = from h in db.Tbheroes
                         where h.Service == "Technology"
                         select h;

            return View(heroes);
        }
        public ActionResult Navy()
        {
            var heroes = from h in db.Tbheroes
                         where h.Service == "Navy"
                         select h;

            return View(heroes);
        }
        public ActionResult AirForce()
        {
            var heroes = from h in db.Tbheroes
                         where h.Service == "Air_Force"
                         select h;

            return View();
        }
        public ActionResult Army()
        {
            var heroes = from h in db.Tbheroes
                         where h.Service == "Army"
                         select h;
            return View();
        }

        public ActionResult ListAll(string service, string searchString/*, string currentFilter, int? page*/)
        {
            var serviceList = new List<string>();

            var serviceQuery = from d in db.Tbheroes
                           orderby d.Service
                           select d.Service;

            serviceList.AddRange(serviceQuery.Distinct());
            ViewBag.serviceGenre = new SelectList(serviceList);

            var heroesList = from m in db.Tbheroes
                         select m;

            if (!string.IsNullOrEmpty(service))
            {
                heroesList = heroesList.Where(x => x.Service == service);
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                heroesList = heroesList.Where(s => s.FirstName.Contains(searchString));
            }

            return View(heroesList);
        }
        
        //Get: AllHeroes/Create
        public ActionResult Create()
        {
            return View();
        }

        //Post: AllHeroes/Create
        //To protect from ovrposting attacks, bind the properties
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Service,Description,Picture")] Tbhero heroes)
        {
            if (heroes.Picture == null)
            {
                heroes.Picture = "http://www.flags.net/images/largeflags/POLA0001.GIF";
            }
            try
            {
                if (ModelState.IsValid)
                {
                    db.Tbheroes.Add(heroes);
                    db.SaveChanges();
                    return RedirectToAction("ListAll");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again.");
            }
            return View(heroes);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

      
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           Tbhero heroes = db.Tbheroes.Find(id);
            if (heroes == null)
            {
                return HttpNotFound();
            }
            return View(heroes);
        }

        // POST: AllHeroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Service,Description,Picture")] Tbhero heroes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(heroes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListAll");
            }
            return View(heroes);
        }

        //GET:Tbheroes/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Tbhero heroes = db.Tbheroes.Find(id);
            if(heroes == null)
            {
                return HttpNotFound();
            }
            return View(heroes);
        }

        // GET: AllHeroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbhero heroes = db.Tbheroes.Find(id);
            if (heroes == null)
            {
                return HttpNotFound();
            }
            return View(heroes);
        }

        // POST: AllHeroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbhero heroes = db.Tbheroes.Find(id);
            db.Tbheroes.Remove(heroes);
            db.SaveChanges();
            return RedirectToAction("ListAll");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }

}