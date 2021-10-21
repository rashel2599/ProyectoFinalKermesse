using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Reporting.WebForms;
using ProyectoFinalKermesse.Models;

namespace ProyectoFinalKermesse.Controllers
{
    public class CategoriaGastoesController : Controller
    {
        private BDKermesseEntities db = new BDKermesseEntities();

        // GET: CategoriaGastoes
        public ActionResult Index(string valorBusq = "")
        {
            var categoriaGasto = from ca in db.CategoriaGasto select ca;

            categoriaGasto = categoriaGasto.Where(ca => ca.estado.Equals(2) || ca.estado.Equals(1));

            if (!string.IsNullOrEmpty(valorBusq))
            {
                categoriaGasto = categoriaGasto.Where(ca => ca.nombreCategoria.Contains(valorBusq));
            }


            return View(categoriaGasto.ToList());
        }

        //Get: VerReportes

        public ActionResult VerReporteCatGasto(string tipo)
        {

            LocalReport rpt = new LocalReport();
            string mt, enc, f;
            string[] s;
            Warning[] w;

            string ruta = Path.Combine(Server.MapPath("~/Reportes"), "RptCatGastos.rdlc");

            rpt.ReportPath = ruta;

            BDKermesseEntities modelo = new BDKermesseEntities();

            List<CategoriaGasto> listaCatGasto = new List<CategoriaGasto>();
            listaCatGasto = modelo.CategoriaGasto.ToList();

            ReportDataSource rds = new ReportDataSource("DsCategoriaGastos", listaCatGasto);
            rpt.DataSources.Add(rds);

            byte[] b = rpt.Render(tipo, null, out mt, out enc, out f, out s, out w);

            return File(b, mt);


        }
        // GET: CategoriaGastoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaGasto categoriaGasto = db.CategoriaGasto.Find(id);
            if (categoriaGasto == null)
            {
                return HttpNotFound();
            }
            return View(categoriaGasto);
        }

        // GET: CategoriaGastoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaGastoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriaGasto categoriaGasto)
        {
            if (ModelState.IsValid)
            {
                var ca = new CategoriaGasto();
                ca.nombreCategoria = categoriaGasto.nombreCategoria;
                ca.descripcion = categoriaGasto.descripcion;
                ca.estado = 1;

                db.CategoriaGasto.Add(ca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoriaGasto);
        }

        // GET: CategoriaGastoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaGasto categoriaGasto = db.CategoriaGasto.Find(id);
            if (categoriaGasto == null)
            {
                return HttpNotFound();
            }
            return View(categoriaGasto);
        }

        // POST: CategoriaGastoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoriaGasto categoriaGasto)
        {
            if (ModelState.IsValid)
            {
                var ca = new CategoriaGasto();
                ca.idCatGasto = categoriaGasto.idCatGasto;
                ca.nombreCategoria = categoriaGasto.nombreCategoria;
                ca.descripcion = categoriaGasto.descripcion;
                ca.estado = 2;

                db.Entry(ca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriaGasto);
        }

        // GET: CategoriaGastoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaGasto categoriaGasto = db.CategoriaGasto.Find(id);
            if (categoriaGasto == null)
            {
                return HttpNotFound();
            }
            return View(categoriaGasto);
        }

        // POST: CategoriaGastoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriaGasto categoriaGasto = db.CategoriaGasto.Find(id);
            categoriaGasto.estado = 3;

            db.Entry(categoriaGasto).State = EntityState.Modified;
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
