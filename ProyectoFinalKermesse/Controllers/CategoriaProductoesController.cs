﻿using System;
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
    public class CategoriaProductoesController : Controller
    {
        private BDKermesseEntities db = new BDKermesseEntities();

        // GET: CategoriaProductoes
        public ActionResult Index()
        {
            return View(db.CategoriaProducto.ToList());
        }

        //Get: VerReportes

        public ActionResult VerReporteCatProd(string tipo)
        {

            LocalReport rpt = new LocalReport();
            string mt, enc, f;
            string[] s;
            Warning[] w;

            string ruta = Path.Combine(Server.MapPath("~/Reportes"), "RptCatProd.rdlc");

            rpt.ReportPath = ruta;

            BDKermesseEntities modelo = new BDKermesseEntities();

            List<CategoriaProducto> listaCatProd = new List<CategoriaProducto>();
            listaCatProd = modelo.CategoriaProducto.ToList();

            ReportDataSource rds = new ReportDataSource("DsCatProd", listaCatProd);
            rpt.DataSources.Add(rds);

            byte[] b = rpt.Render(tipo, null, out mt, out enc, out f, out s, out w);

            return File(b, mt);

        }



            // GET: CategoriaProductoes/Details/5
            public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaProducto categoriaProducto = db.CategoriaProducto.Find(id);
            if (categoriaProducto == null)
            {
                return HttpNotFound();
            }
            return View(categoriaProducto);
        }

        // GET: CategoriaProductoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaProductoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCatProd,nombre,descripcion,estado")] CategoriaProducto categoriaProducto)
        {
            if (ModelState.IsValid)
            {
                db.CategoriaProducto.Add(categoriaProducto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoriaProducto);
        }

        // GET: CategoriaProductoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaProducto categoriaProducto = db.CategoriaProducto.Find(id);
            if (categoriaProducto == null)
            {
                return HttpNotFound();
            }
            return View(categoriaProducto);
        }

        // POST: CategoriaProductoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCatProd,nombre,descripcion,estado")] CategoriaProducto categoriaProducto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoriaProducto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriaProducto);
        }

        // GET: CategoriaProductoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaProducto categoriaProducto = db.CategoriaProducto.Find(id);
            if (categoriaProducto == null)
            {
                return HttpNotFound();
            }
            return View(categoriaProducto);
        }

        // POST: CategoriaProductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriaProducto categoriaProducto = db.CategoriaProducto.Find(id);
            db.CategoriaProducto.Remove(categoriaProducto);
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
