using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmissorasApp.Data;
using EmissorasApp.Models;

namespace EmissorasApp.Controllers
{
    public class AudienciaController : Controller
    {
        private EmissorasAppContext db = new EmissorasAppContext();

        // Método para retorno de nome de emissora, em referência ao contexto de audiência
        public string retornaNomeEmissora(int? id)
        {
            Emissora emissora = db.Emissora.Find(id);

            return emissora.Nome;
        }

        // GET: Audiencia
        public ActionResult Index()
        {
            return View(db.Audiencia.ToList());
        }

        // GET: Audiencia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Audiencia audiencia = db.Audiencia.Find(id);
            if (audiencia == null)
            {
                return HttpNotFound();
            }

            ViewBag.emissora = retornaNomeEmissora(audiencia.emissoraAudiencia);

            return View(audiencia);
        }

        // GET: Audiencia/Create
        public ActionResult Create()
        {
            List<Emissora> emissoras = db.Emissora.ToList();
            ViewBag.emissoras = emissoras;

            return View();
        }

        // POST: Audiencia/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,pontosAudiencia,dataHoraAudiencia,emissoraAudiencia")] Audiencia audiencia)
        {
            if ((ModelState.IsValid) && (db.Audiencia.ToList().Exists(a => a.dataHoraAudiencia.Equals(audiencia.dataHoraAudiencia) && a.emissoraAudiencia.Equals(audiencia.emissoraAudiencia))) == false)
            {
                db.Audiencia.Add(audiencia);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // GET: Audiencia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Audiencia audiencia = db.Audiencia.Find(id);
            if (audiencia == null)
            {
                return HttpNotFound();
            }
            return View(audiencia);
        }

        // POST: Audiencia/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,pontosAudiencia,dataHoraAudiencia,emissoraAudiencia")] Audiencia audiencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(audiencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(audiencia);
        }

        // GET: Audiencia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Audiencia audiencia = db.Audiencia.Find(id);
            if (audiencia == null)
            {
                return HttpNotFound();
            }

            ViewBag.emissora = retornaNomeEmissora(audiencia.emissoraAudiencia);

            return View(audiencia);
        }

        // POST: Audiencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Audiencia audiencia = db.Audiencia.Find(id);
            db.Audiencia.Remove(audiencia);
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
