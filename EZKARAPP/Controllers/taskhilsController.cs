using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EZKARAPP.Models;

namespace EZKARAPP.Controllers
{
    public class taskhilsController : Controller
    {
        private DBEntities db = new DBEntities();

        // GET: taskhils
        public ActionResult Index()
        {
            return View(db.taskhils.ToList());
        }

        // GET: taskhils/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            taskhil taskhil = db.taskhils.Find(id);
            if (taskhil == null)
            {
                return HttpNotFound();
            }
            return View(taskhil);
        }

        // GET: taskhils/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: taskhils/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,fname,gfname,bast,qadamasli,qadampeli,taqaroribtidayi,rooz,maah,saal,inwaanbast,reyasatmarboot,mooyinat,markaziwalayati,mamoorkaarkon,jinsiyat,darajatahseel,reshtatahseel,maash,roobamoqarari,saalmoqarari,poorkhaali,saaltawalood,roobarzyaabi,arzyaabiimtehaani,roobarzyaabiimtehaani,tarikharzyaabi,shoomratamaas,nawimaash,meeqdarmaash,tarikhakhzmaash,maahakhzmaash,molahezat")] taskhil taskhil)
        {
            if (ModelState.IsValid)
            {
                db.taskhils.Add(taskhil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(taskhil);
        }

        // GET: taskhils/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            taskhil taskhil = db.taskhils.Find(id);
            if (taskhil == null)
            {
                return HttpNotFound();
            }
            return View(taskhil);
        }

        // POST: taskhils/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,fname,gfname,bast,qadamasli,qadampeli,taqaroribtidayi,rooz,maah,saal,inwaanbast,reyasatmarboot,mooyinat,markaziwalayati,mamoorkaarkon,jinsiyat,darajatahseel,reshtatahseel,maash,roobamoqarari,saalmoqarari,poorkhaali,saaltawalood,roobarzyaabi,arzyaabiimtehaani,roobarzyaabiimtehaani,tarikharzyaabi,shoomratamaas,nawimaash,meeqdarmaash,tarikhakhzmaash,maahakhzmaash,molahezat")] taskhil taskhil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taskhil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taskhil);
        }

        // GET: taskhils/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            taskhil taskhil = db.taskhils.Find(id);
            if (taskhil == null)
            {
                return HttpNotFound();
            }
            return View(taskhil);
        }

        // POST: taskhils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            taskhil taskhil = db.taskhils.Find(id);
            db.taskhils.Remove(taskhil);
            db.SaveChanges();
            return RedirectToAction("Index");
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
