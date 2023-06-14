using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.Web.Models;
using System.IO;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.BusinessLogic;
using eUseControl.Domain.Entities.Admin;
using eUseControl.Web.App_Start;

namespace eUseControl.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _product;
        public ProductController()
        {
            var bl = new MyBusinessLogic();
            _product = bl.getProductBL();
        }
        // GET: Product
        [AdminMod]
        public ActionResult Index()
        {
            MProducts prod = new MProducts();
            prod.Products = _product.Get();
            return View("Product-list", prod);
        }
        [AdminMod]
        public ActionResult Add()
        {
            return View("Product-add");
        }
        [AdminMod]
        [HttpPost]
        public ActionResult Add(MProduct prod)
        {
            string fileName = Path.GetFileNameWithoutExtension(prod.Image.FileName);
            string extension = Path.GetExtension(prod.Image.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            prod.ImagePath = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            prod.Image.SaveAs(fileName);
            Product product = new Product()
            {
                Name = prod.Name,
                Price = prod.Price,
                Category = prod.Category,
                ImagePath = prod.ImagePath
            };

            _product.Insert(product);

            return RedirectToAction("Index");
        }
        public ActionResult Products()
        {
            MProducts prod = new MProducts();
            prod.Products = _product.Get();
            return View(prod);
        }
    }
}