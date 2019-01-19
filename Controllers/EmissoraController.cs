using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using EmissorasApp.Data;
using EmissorasApp.Models;

namespace EmissorasApp.Controllers
{
    public class EmissoraController : Controller
    {
        private EmissorasAppContext db = new EmissorasAppContext();

        public object ClientScript { get; private set; }

        // GET: Emissora
        public ActionResult Index()
        {
            return View(db.Emissora.ToList());
        }

        // GET: Emissora/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emissora emissora = db.Emissora.Find(id);
            if (emissora == null)
            {
                return HttpNotFound();
            }
            return View(emissora);
        }

        // GET: Emissora/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Emissora/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome")] Emissora emissora)
        {
            if ((ModelState.IsValid) && (((db.Emissora.ToList().Exists(e => e.Nome.Equals(emissora.Nome))) == false) && Regex.IsMatch(emissora.Nome, (@"[!""#$%&'()*+,-./:;?@[\\\]_`{|}~]")) == false))
            {
                    db.Emissora.Add(emissora);
                    db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // GET: Emissora/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emissora emissora = db.Emissora.Find(id);
            if (emissora == null)
            {
                return HttpNotFound();
            }
            return View(emissora);
        }

        // POST: Emissora/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome")] Emissora emissora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emissora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emissora);
        }

        // GET: Emissora/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emissora emissora = db.Emissora.Find(id);
            if (emissora == null)
            {
                return HttpNotFound();
            }
            return View(emissora);
        }

        // POST: Emissora/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emissora emissora = db.Emissora.Find(id);
            db.Emissora.Remove(emissora);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult RelatorioSomatorio()
        {                                     
            return View(db.Audiencia.ToList());
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
