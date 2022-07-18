using aula.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aula.Controllers
{
    public class CategoriasController : Controller
    {
        private EFContext context = new EFContext();

        private static IList<Categoria> categorias = new List<Categoria>()
        {
        new Categoria() { CategoriaId = 1, Nome = "Notebooks"},
        new Categoria() { CategoriaId = 2, Nome = "Monitores"},
        new Categoria() { CategoriaId = 3, Nome = "Impressoras"},
        new Categoria() { CategoriaId = 4, Nome = "Mouses"},
        new Categoria() { CategoriaId = 5, Nome = "Desktops"}
        };


        // GET: Categorias
        public ActionResult Index()
        {
            return View(
               context.Fabricantes.OrderBy(c => c.Nome)
               );
        }

        // GET: Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            categorias.Add(categoria);
            //categoria.CategoriaId = categorias.Select(m => m.CategoriaId).Max() + 1;
            context.Categorias.Add(categoria);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //return View(categorias.Where(m => m.CategoriaId == id).First());
            
            Categoria categoria = context.Categorias.Find(id);

            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

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


        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = context.Categorias.Find(id);
            //return View(categorias.Where(m => m.CategoriaId == id).First());
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);  
        }



        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = context.Categorias.Find(id);
            //return View(categorias.Where(m => m.CategoriaId == id).First());
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Categoria categoria = context.Categorias.Find(id);
            context.Categorias.Remove(categoria);
            //categorias.Remove(
            //categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First());
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}