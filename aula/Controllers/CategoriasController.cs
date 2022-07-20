using aula.App_Start.Models;
using aula.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace aula.Controllers
{
    public class CategoriasController : Controller
    {
        private EFContext context = new EFContext();

        // GET: Categorias
        public ActionResult Index()
        {
            return View(
                //categorias
                context.Categorias.OrderBy(c => c.Nome)
                );
        }

        // GET: Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            //categoria.CategoriaId = categorias.Select(m => m.CategoriaId).Max() + 1;
            context.Categorias.Add(categoria);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Categorias/Edit/5
        [HttpGet]
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Categoria categoria = categorias.Where(m => m.CategoriaId == id).First();

            Categoria categoria = context.Categorias.Find(id);

            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                context.Entry(categoria).State = EntityState.Modified;
                context.SaveChanges();
                //categorias.Remove(
                //categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First());
                //categorias.Add(categoria);
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        // GET: Categorias/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = context.Categorias.Find(id);
            //Categoria categoria = categorias.Where(m => m.CategoriaId == id).First();
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = context.Categorias.Find(id);
            //Categoria categoria = categorias.Where(m => m.CategoriaId == id).First();
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Categoria categoria = context.Categorias.Find(id);
            //Categoria categoria = categorias.Where(m => m.CategoriaId == id).First();
            context.Categorias.Remove(categoria);
            //categorias.Remove(categoria);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
