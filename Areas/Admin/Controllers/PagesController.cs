using CMSShoppingCard.Models.Data;
using CMSShoppingCard.Models.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMSShoppingCard.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PagesController : Controller
    {
        // GET: Admin/Pages
        public ActionResult Index()
        {
            //Declare list of PageVM
            List<PageVM> pagesList;
            //Init the list
            using (Db db = new Db())
            {
                //Init the lust
                pagesList = db.Pages.ToArray().OrderBy(x => x.Sorting).Select(x => new PageVM(x)).ToList();
            }
                //Return view
                return View(pagesList);
        }

        // GET: Admin/Pages/AddPages
        [HttpGet]
        public ActionResult AddPage()
        {
            return View();
        }

        // POST: Admin/Pages/AddPages
        [HttpPost]
        public ActionResult AddPage(PageVM model)
        {
            //check model state
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (Db db = new Db())
            {
                //declare the slug 
                string slug;
                //init pageDTO
                PageDTO dto = new PageDTO();
                //DTO title
                dto.Title = model.Title;
                //check for and set slug if need be
                if (string.IsNullOrWhiteSpace(model.Slug))
                {
                    slug = model.Title.Replace(" ", "-").ToLower();
                }
                else
                {
                    slug = model.Slug.Replace(" ", "-").ToLower();
                }

                //Make sure title and slug are unique
                if (db.Pages.Any(x => x.Title == model.Title) || db.Pages.Any(x => x.Slug == slug) )
                {
                    ModelState.AddModelError("", "That title or slug alredy exsist.");
                    return View(model);
                }


                //DTO the rest
                dto.Slug = slug;
                dto.Body = model.Body;
                dto.HasSlidebar = model.HasSlidebar;
                dto.Sorting = 100;


                //Save DTO
                db.Pages.Add(dto);
                db.SaveChanges();
            }

            //Set TempData message
            TempData["SM"] = "You have added a new page!";

            //Redirect
            return RedirectToAction("AddPage");
            
        }

        // GET: Admin/Pages/EditPage/id
        [HttpGet]
        public ActionResult EditPage(int id)
        {
            
            PageVM model;

            using (Db db = new Db())
            {
                PageDTO dto = db.Pages.Find(id);
                if(dto == null)
                {
                    return Content("The page does not exsist.");
                }
                model = new PageVM(dto);

            }

                return View(model);
        }


        // POST: Admin/Pages/EditPage
        [HttpPost]
        public ActionResult EditPage(PageVM model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            using (Db db = new Db())
            {
                int id = model.Id;
                string slug = "home";

                PageDTO dto = db.Pages.Find(id);

                dto.Title = model.Title;

                if (model.Slug != "home")
                {
                    if (string.IsNullOrWhiteSpace(model.Slug))
                    {
                        slug = model.Title.Replace(" ", "-").ToLower();
                    }
                    else
                    {
                        slug = model.Slug.Replace(" ", "-").ToLower();
                    }
                }

                if (db.Pages.Where(x => x.Id != id).Any(x => x.Title == model.Title) ||
                    db.Pages.Where(x => x.Id != id).Any(x => x.Slug == slug))
                {

                    ModelState.AddModelError("", "The title or slug alredy exsists. ");
                    return View(model);

                }
                dto.Slug = slug;
                dto.Body = model.Body;
                dto.HasSlidebar = model.HasSlidebar;


                db.SaveChanges();
                
                }

            TempData["SM"] = "You have edited the page!";
            return RedirectToAction("EditPage");

            }

        // GET: Admin/Pages/DeletePage/id
        public ActionResult PageDetails(int id)
        {
            PageVM model;

            using (Db db = new Db())
            {
                PageDTO dto = db.Pages.Find(id);

                if(dto == null)
                {
                    return Content("The page does not exists.");
                }
                model = new PageVM(dto);
            }
                return View(model);
        }

        public ActionResult DeletePage(int id)
        {
            using (Db db = new Db())
            {
                PageDTO dto = db.Pages.Find(id);

                db.Pages.Remove(dto);

                db.SaveChanges();
            }
                
                return RedirectToAction("Index");
        }

        //POST: Admin/Pages/ReorderPages
        [HttpPost]
        public void ReorderPages(int[] id)
        {
            using (Db db = new Db())
            {
                int count = 1;
                PageDTO dto;

                foreach (var pageId in id)
                {
                    dto = db.Pages.Find(pageId);
                    dto.Sorting = count;
                    db.SaveChanges();
                    count++;
                }
            }
        }


        //GET: Admin/Pages/EditSlidebar
        public ActionResult EditSlidebar()
        {
            SlidebarVM model;

            using (Db db = new Db())
            {
                SlidebarDTO dto = db.Slidebar.Find(1);

                model = new SlidebarVM(dto);
            }

                return View(model);
        }

        //POST: Admin/Pages/EditSlidebar
        [HttpPost]
        public ActionResult EditSlidebar(SlidebarVM model)
        {
            using (Db db = new Db())
            {
                SlidebarDTO dto = db.Slidebar.Find(1);

                dto.Body = model.Body;

                db.SaveChanges();
            }
            TempData["SM"] = "You have edited the slidebar";
                return RedirectToAction("EditSlidebar");
        }
            
        }
    }

