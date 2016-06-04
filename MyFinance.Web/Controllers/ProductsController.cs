using MyFinance.Domain.Entities;
using MyFinance.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFinance.Web.Controllers
{
    public class ProductsController : Controller
    {
        IEBuyService service = null;

        //Le Dependency Injection a crée une instance de l'interface IEBuyService juste en passant l'interface en paramétre on a plus besoin d'utiliser l'opérateur new
        //A refaire avec toutes les autres instances dans les différants classes
        public ProductsController(IEBuyService e)
        {
            service = e;
        }
        
        //public ProductsController()
        //{
        //    service = new EBuyService();
        //}

        // GET: Products
        public ActionResult Index()
        {
            var products = service.GetProducts();
            return View(products);
        }

        // POST: Products
        [HttpPost]
        public ActionResult Index(String categoryName)
        //Il suffit d'ajouter l'id du TextBox pour récupérer sa valeur
        {
            try
            {
                var products = service.GetProductsByCategory(categoryName);
                return View(products);
            }
            catch (Exception)
            {
                ViewBag.Message = "The category doesn't exist";
                return View();
            }

        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/CreateBiological
        public ActionResult CreateBiological()
        {
            var categories = service.GetCategories();
            ViewBag.Category = new SelectList(categories, "CategoryId", "Name");
            return View();
        }


        // POST: Products/CreateBiological
        [HttpPost]
        public ActionResult CreateBiological(Biological bio, HttpPostedFileBase file, bool? isNew)
        {
            //ModelState.IsValid => Vérifier à partir de la configuration ainsi des annotations si les données sont valides
            if (!ModelState.IsValid || file.ContentLength == 0 || isNew == null)
            {
                return View(bio);
            }

            bio.ImageName = file.FileName;

            Session["Product"] = bio;
            TempData["isNew"] = isNew;
            TempData["Image"] = file;

            return RedirectToAction("ValidateBiological");
        }

        public ActionResult ValidateBiological(bool? insertion)
        {
            Biological p = Session["Product"] as Biological;
            if (insertion == true)
            {
                HttpPostedFileBase file = TempData["Image"] as HttpPostedFileBase;
                if (file.ContentLength > 0)
                {
                    service.CreateProduct(p);
                    var path = Path.Combine(Server.MapPath("~/Content/Upload"), p.ImageName);
                    file.SaveAs(path);
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(p);
            }
        }


        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
