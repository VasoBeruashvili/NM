using NM.Models;
using NM.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NM.Controllers
{    
    public class HomeController : Controller
    {
        NMContext context = new NMContext();

        public ActionResult Index()
        {
            return NMContext.IsLicenseValid() ? View() : null;
        }

        public ActionResult Services()
        {
            return NMContext.IsLicenseValid() ? View() : null;
        }

        public ActionResult Trainings()
        {
            return NMContext.IsLicenseValid() ? View() : null;
        }

        public ActionResult AllServices()
        {
            return NMContext.IsLicenseValid() ? View() : null;
        }



        [Authorize]
        public ActionResult AddProducts()
        {
            return NMContext.IsLicenseValid() ? View() : null;
        }

        public JsonResult GetProducts(int currentPage, int itemsPerPage, string searchFragment)
        {
            if (NMContext.IsLicenseValid())
            {
                var productsCount = string.IsNullOrEmpty(searchFragment) ? context.Products.Count() : context.Products.Where(p => p.Description.Contains(searchFragment)).Count();

                return Json(new { products = string.IsNullOrEmpty(searchFragment) ? context.Products.ToList().Skip((currentPage - 1) * itemsPerPage).Take(itemsPerPage).OrderByDescending(p => p.Id).ToList() : context.Products.Where(p => p.Description.Contains(searchFragment)).ToList().Skip((currentPage - 1) * itemsPerPage).Take(itemsPerPage).OrderByDescending(p => p.Id).ToList(), totalItems = productsCount }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return null;
            }
        }

        [Authorize]
        public JsonResult SaveProduct(Product product)
        {
            if (NMContext.IsLicenseValid())
            {
                if (product.Id == 0)
                {
                    context.Products.Add(product);
                }
                else
                {
                    if (product.Deleted)
                    {
                        context.Entry(product).State = EntityState.Deleted;
                    }
                    else
                    {
                        context.Entry(product).State = EntityState.Modified;
                    }
                }

                return Json(new { saveResult = context.SaveChanges() >= 0 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return null;
            }
        }        
    }
}
