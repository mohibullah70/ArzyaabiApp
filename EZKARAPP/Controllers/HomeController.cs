using EZKARAPP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EZKARAPP.Controllers
{
    public class HomeController : AppController
    {
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _ListPeople()
        {
            var result = from p in db.taskhils
                         select p;
            //if (!string.IsNullOrEmpty(searchTerm) && !string.IsNullOrEmpty(searchValue))
            //{
            //    searchTerm = searchTerm.ToLower().Trim();
            //    searchValue = searchValue.ToLower().Trim();
            //    DateTime searchValueDate = DateTime.MinValue;
            //    DateTime.TryParse(searchValue, out searchValueDate);
            //    int searchValueInt;
            //    int.TryParse(searchValue, out searchValueInt);
            //    bool searchValueFlag = true;
            //    bool.TryParse(searchValue, out searchValueFlag);

            //    switch (searchTerm)
            //    {

            //        case "fullname":
            //            result = result.Where(a => a.FirstName.ToLower().Contains(searchValue) ||
            //                                        a.LastName.ToLower().Contains(searchValue) ||
            //                                        a.FirstNameLocal.ToLower().Contains(searchValue) ||
            //                                        a.LastNameLocal.ToLower().Contains(searchValue));
            //            break;
            //        case "fathername":
            //            result = result.Where(a => a.FatherName.ToLower().Contains(searchValue) ||
            //                                        a.FatherNameLocal.ToLower().Contains(searchValue));
            //            break;
            //        case "nic":
            //            result = result.Where(a => a.NICNumber.ToLower().Contains(searchValue));
            //            break;
            //        case "flag":
            //            result = result.Where(a => a.Flag == searchValueFlag);
            //            break;
            //        default:
            //            result = result.Where(a => a.FirstName.ToLower().Contains(searchValue) ||
            //                                        a.LastName.ToLower().Contains(searchValue) ||
            //                                        a.FirstNameLocal.ToLower().Contains(searchValue) ||
            //                                        a.LastNameLocal.ToLower().Contains(searchValue) ||
            //                                        a.FatherName.ToLower().Contains(searchValue) ||
            //                                        a.FatherNameLocal.ToLower().Contains(searchValue) ||
            //                                        a.NICNumber.Contains(searchValue) ||
            //                                        a.Flag == searchValueFlag
            //                                    );
            //            break;
            //    }

            //}

            return PartialView("_ListPeople", result.OrderBy(a => a.id).ToList());
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
            var taskhil = db.taskhils.Find(id);
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



        // GET: taskhils/Edit/5
        public ActionResult Arzyaabi(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var taskhil = db.taskhils.Find(id);
            if (taskhil == null)
            {
                return HttpNotFound();
            }
            var arzyaabi = new arzyaabi();
            arzyaabi.taskhkilid = taskhil.id;
            arzyaabi.createddate = DateTime.Now;

            arzyaabi.taskhil = taskhil;
            return View(arzyaabi);
        }

        // POST: taskhils/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Arzyaabi(arzyaabi arzyaabi)
        {
            if (ModelState.IsValid)
            {
                db.arzyaabis.Add(arzyaabi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            arzyaabi.taskhil = db.taskhils.Find(arzyaabi.taskhkilid);
            return View(arzyaabi);
        }

    }
}