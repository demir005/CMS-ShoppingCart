using CMSShoppingCard.Models.Data;
using CMSShoppingCard.Models.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMSShoppingCard.Controllers 
{
    public class PagesController : Controller
    {
        // GET: Index/(page)
        public ActionResult Index(string page = "")
        {
            if (page == "")
                page = "home";

            PageVM model;
            PageDTO dto;

            using (Db db = new Db())
            {
                if (!db.Pages.Any(x => x.Slug.Equals(page)))
                {
                    return RedirectToAction("Index", new { page = "" });
                }
            }

            using (Db db = new Db())
            {
                dto = db.Pages.Where(x => x.Slug == page).FirstOrDefault();
            }

            ViewBag.PageTitle = dto.Title;

            if(dto.HasSlidebar == true)
            {
                ViewBag.Slidebar = "Yes";
            }
            else
            {
                ViewBag.Slidebar = "No";
            }

            model = new PageVM(dto);


                return View(model);
        }

        public ActionResult PagesMenuPartial()
        {
            List<PageVM> pageVMList;

            using (Db db = new Db())
            {
                pageVMList = db.Pages.ToArray().OrderBy(x => x.Sorting).Where(x => x.Slug != "home")
                    .Select(x => new PageVM(x)).ToList();
            }
                return PartialView(pageVMList);
        }

        public ActionResult SlidebarPartial()
        {
            SlidebarVM model;

            using (Db db = new Db())
            {
                SlidebarDTO dto = db.Slidebar.Find(1);

                model = new SlidebarVM(dto);
            }


            return PartialView(model);
        }
    }
}