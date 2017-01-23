using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class SchoolsController : Controller
    {
        private meijiaEntities db = new meijiaEntities();

        // GET: Schools
        public ActionResult Index()
        {
            return View(db.School.ToList());
        }

        // GET: Schools/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            School school = db.School.Find(id);
            if (school == null)
            {
                return HttpNotFound();
            }
            return View(school);
        }

        // GET: Schools/Create
        public ActionResult Create()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "渝中区", Value = "渝中区", Selected = true });
            items.Add(new SelectListItem { Text = "大渡口区", Value = "大渡口区" });
            items.Add(new SelectListItem { Text = "江北区  ", Value = "江北区  " });
            items.Add(new SelectListItem { Text = "沙坪坝区", Value = "沙坪坝区" });
            items.Add(new SelectListItem { Text = "九龙坡区 ", Value = "九龙坡区 " });
            items.Add(new SelectListItem { Text = "南岸区", Value = "南岸区" });
            items.Add(new SelectListItem { Text = "北碚区", Value = "北碚区" });
            items.Add(new SelectListItem { Text = "綦江区", Value = "綦江区" });
            items.Add(new SelectListItem { Text = "双桥区", Value = "双桥区" });
            items.Add(new SelectListItem { Text = "渝北区", Value = "渝北区" });
            items.Add(new SelectListItem { Text = "巴南区", Value = "巴南区" });
            items.Add(new SelectListItem { Text = "万州区", Value = "万州区" });
            items.Add(new SelectListItem { Text = "涪陵区", Value = "涪陵区" });
            items.Add(new SelectListItem { Text = "黔江区", Value = "黔江区" });
            items.Add(new SelectListItem { Text = "长寿区", Value = "长寿区" });
            items.Add(new SelectListItem { Text = "江津区", Value = "江津区" });
            items.Add(new SelectListItem { Text = "合川区", Value = "合川区" });
            items.Add(new SelectListItem { Text = "永川区", Value = "永川区" });
            items.Add(new SelectListItem { Text = "南川区", Value = "南川区" });
            items.Add(new SelectListItem { Text = "綦江县", Value = "綦江县" });
            items.Add(new SelectListItem { Text = "潼南县", Value = "潼南县" });

            items.Add(new SelectListItem { Text = "铜梁县", Value = "铜梁县" });
            items.Add(new SelectListItem { Text = "大足县", Value = "大足县" });
            items.Add(new SelectListItem { Text = "荣昌县", Value = "荣昌县" });
            items.Add(new SelectListItem { Text = "璧山县", Value = "璧山县" });
            items.Add(new SelectListItem { Text = "梁平县", Value = "梁平县" });
            items.Add(new SelectListItem { Text = "城口县", Value = "城口县" });
            items.Add(new SelectListItem { Text = "丰都县", Value = "丰都县" });
            this.ViewData["county"] = items;
            return View();
        }

        // POST: Schools/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SchoolID,SchoolName,Province,City,county")] School school)
        {
            if (ModelState.IsValid)
            {
                db.School.Add(school);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(school);
        }

        // GET: Schools/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            School school = db.School.Find(id);
            if (school == null)
            {
                return HttpNotFound();
            }
            return View(school);
        }

        // POST: Schools/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SchoolID,SchoolName,Province,City,county")] School school)
        {
            if (ModelState.IsValid)
            {
                db.Entry(school).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(school);
        }

        // GET: Schools/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            School school = db.School.Find(id);
            if (school == null)
            {
                return HttpNotFound();
            }
            return View(school);
        }

        // POST: Schools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            School school = db.School.Find(id);
            db.School.Remove(school);
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
