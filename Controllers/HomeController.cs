using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NZ2.Models;
using NZ2.Factory;

namespace NZ2.Controllers
{
    public class HomeController : Controller
    {
        DBContext context = new DBContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products()
        {
            List<Category> allCategories = context.CategoryFactory.GetAll();
            return View(allCategories);
        }

        // ID = CategoryID
        public ActionResult ProductList(int id = 0)
        {

            List<Product> productsByCategoryID = context.ProductFactory.GetAllBy("CategoryID", id);
            return View(productsByCategoryID);
        }

        // ID = ProductID
        public ActionResult ShowProduct(int id = 0)
        {
            Product productbyID = context.ProductFactory.Get(id);

            ProductVM pvm = new ProductVM();
            pvm.Product = productbyID;
            pvm.Category = context.CategoryFactory.Get(productbyID.CategoryID);


            return View(pvm);
        }
        
    }
}