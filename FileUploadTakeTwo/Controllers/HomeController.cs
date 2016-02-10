using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileUploadTakeTwo.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public void Post(HttpPostedFileBase foo)
        {
            Guid g = Guid.NewGuid();
            
            foo.SaveAs(Server.MapPath("~/Uploads/" + g + ".jpg"));
            Response.Write("<h2> Saved file: " + Server.MapPath("~/Uploads/" + g.ToString() + ".jpg") + "</h2>");
        }

        public ActionResult Images()
        {

            //string[] files = Directory.GetFiles(Server.MapPath("~/Uploads"), "*.jpg");
            //List<string> fileNames = new List<string>();
            //foreach (string file in files)
            //{
            //    fileNames.Add(Path.GetFileName(file));
            //}

            var images = Directory.GetFiles(Server.MapPath("~/Uploads"), "*.jpg").Select(Path.GetFileName);
            return View(images);
        }

    }
}
