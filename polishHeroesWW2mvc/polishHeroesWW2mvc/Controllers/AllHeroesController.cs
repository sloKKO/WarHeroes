//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using polishHeroesWW2mvc.Models;

//namespace polishHeroesWW2mvc.Controllers
//{
//    public class AllHeroesController : Controller
//    {
//        private PeopleDBEntities3 db = new PeopleDBEntities3();

//        // GET: AllHeroes
//        public ActionResult Index(string heroesService, string searchString)
//        {
//            var ServiceList = new List<string>();
//            var ServiceQry = from h in db.AllHeroes
//                             orderby h.Service
//                             select h.Service;

//            ServiceList.AddRange(ServiceQry.Distinct());
//            ViewBag.allHeroesService = new SelectList(ServiceList);

//            var people = from p in db.AllHeroes
//                         select p;

//            if (!String.IsNullOrEmpty(searchString))
//            {
//                people = people.Where(s => s.FirstName.Contains(searchString));
//            }

//            if (!string.IsNullOrEmpty(heroesService))
//            {
//                people = people.Where(x => x.Service == heroesService);
//            }
//            //return View(db.AllHeroes.ToList());
//            return View(people);
//        }


//        // GET: AllHeroes/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            AllHero allHero = db.AllHeroes.Find(id);
//            if (allHero == null)
//            {
//                return HttpNotFound();
//            }
//            return View(allHero);
//        }

//        // GET: AllHeroes/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: AllHeroes/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Service,Description,Picture")] AllHero allHero)
//        {
//            try
//            {
//                if (ModelState.IsValid)
//                {
//                    db.AllHeroes.Add(allHero);
//                    db.SaveChanges();
//                    return RedirectToAction("Index");
//                }
//            }
//            catch (DataException)
//            {
//                ModelState.AddModelError("", "Unable to save changes. Try again.");
//            }

//            return View(allHero);
//        }

//        // GET: AllHeroes/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            AllHero allHero = db.AllHeroes.Find(id);
//            if (allHero == null)
//            {
//                return HttpNotFound();
//            }
//            return View(allHero);
//        }

//        // POST: AllHeroes/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Service,Description,Picture")] AllHero allHero)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(allHero).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(allHero);
//        }

//        // GET: AllHeroes/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            AllHero allHero = db.AllHeroes.Find(id);
//            if (allHero == null)
//            {
//                return HttpNotFound();
//            }
//            return View(allHero);
//        }

//        // POST: AllHeroes/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            AllHero allHero = db.AllHeroes.Find(id);
//            db.AllHeroes.Remove(allHero);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        //public ActionResult
//    }
//}
