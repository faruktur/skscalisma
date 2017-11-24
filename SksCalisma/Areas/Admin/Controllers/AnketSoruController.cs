using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SksCalisma.Models;

namespace SksCalisma.Areas.Admin.Controllers
{
    public class AnketSoruController : BaseController
    {
        // GET: Admin/Anket
        public ActionResult Index()
        {
            ViewBag.Sorular = db.AnketSoru.OrderBy(x => x.anketSoruNo).ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "anketSoruIcerik")] AnketSoru soru)
        {
            if (ModelState.IsValid)
            {
                soru.anketSoruNo = Convert.ToByte(GetMaxOrder());
                db.AnketSoru.Add(soru);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", soru);
        }

        private int GetMaxOrder()
        {
            if (db.AnketSoru.Any())
                return db.AnketSoru.Max(x => x.anketSoruNo) + 1;
            return 1;
        }
        [HttpPost]
        public bool UpdateOrder(int _anketSoruID, bool isDown)
        {
            var soru = db.AnketSoru.Find(_anketSoruID);
            if (isDown)
            {
                var isThere = db.AnketSoru.Any(x => x.anketSoruNo < soru.anketSoruNo);
                if (!isThere) return false;
                var items = db.AnketSoru.Where(x => x.anketSoruNo < soru.anketSoruNo);
                var itemOrder = items.Max(x => x.anketSoruNo);
                var item = items.FirstOrDefault(x => x.anketSoruNo == itemOrder);
                if (soru != null)
                {
                    var order = soru.anketSoruNo;
                    if (item != null)
                    {
                        soru.anketSoruNo = item.anketSoruNo;
                        item.anketSoruNo = order;
                    }
                }
                db.SaveChanges();
                return true;
            }
            else
            {
                var isThere = db.AnketSoru.Any(x => x.anketSoruNo > soru.anketSoruNo);
                if (!isThere) return false;
                var items = db.AnketSoru.Where(x => x.anketSoruNo > soru.anketSoruNo);
                var itemOrder = items.Min(x => x.anketSoruNo);
                var item = items.FirstOrDefault(x => x.anketSoruNo == itemOrder);
                if (soru != null)
                {
                    var order = soru.anketSoruNo;
                    if (item != null)
                    {
                        soru.anketSoruNo = item.anketSoruNo;
                        item.anketSoruNo = order;
                    }
                }
                db.SaveChanges();
                return true;
            }
        }

        [HttpPost]
        public ActionResult GetEditForm(int id)
        {
            return PartialView("_Edit", db.AnketSoru.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AnketSoru soru)
        {
            if (ModelState.IsValid)
            {
                db.Entry(soru).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", soru);
        }

        [HttpPost]
        public ActionResult GetDeleteForm(int id)
        {
            return PartialView("_Delete", db.AnketSoru.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var soru = db.AnketSoru.Find(id);
            var secenekler = db.AnketSecenek.Where(x => x.anketSoruID == id).ToList();
            secenekler.ForEach(x => db.AnketSecenek.Remove(x));
            db.AnketSoru.Remove(soru);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}