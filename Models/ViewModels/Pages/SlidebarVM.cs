using CMSShoppingCard.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMSShoppingCard.Models.ViewModels.Pages
{
    public class SlidebarVM
    {
        public SlidebarVM()
        {

        }

        public SlidebarVM(SlidebarDTO row)
        {
            Id = row.Id;
            Body = row.Body; 
        }
        public int Id { get; set; }

        [AllowHtml]
        public string Body { get; set; }
    }
}