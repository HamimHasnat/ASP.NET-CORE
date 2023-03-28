using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Core2.Controllers
{
    public class Dept_items : Controller
    {
        [Route("myroute")]
        public IActionResult Index()
        {
            return View();
        }
        private Core2Context db;
        private IHostingEnvironment HostEnvironment;//file upload in specific folder
        public Dept_items(Core2Context _db, IHostingEnvironment _HostEnvironment)
        {
            db = _db;
            HostEnvironment = _HostEnvironment;
        }


        public JsonResult GetDept(string id)
        {
            var a = (from d in db.dept2 where d.deptid == id select new { d.deptid, d.deptname, d.location });
            return Json(a);
        }
        public JsonResult GetItems(string id)
        {
            var a = (from d in db.items2 where d.deptid == id select new { d.itemcode, d.itemname, d.cost, d.rate, d.date, d.picture });
            return Json(a);
        }

        public JsonResult InsertDept(dept2 stu_Guard)
        {
            dept2 a = new dept2() { deptid = stu_Guard.deptid, deptname = stu_Guard.deptname, location = stu_Guard.location };
            db.dept2.Add(a);
            db.SaveChanges();
            return Json(a);
        }
        public JsonResult InsertItems(items2 stu_Guard)
        {
            items2 a1 = new items2() { itemcode = stu_Guard.itemcode, itemname = stu_Guard.itemname, deptid = stu_Guard.deptid, date = DateTime.Parse(stu_Guard.date.ToShortDateString()), picture = stu_Guard.picture, cost = stu_Guard.cost, rate = stu_Guard.rate };
            db.items2.Add(a1);
            db.SaveChanges();
            return Json(a1);
        }
        public JsonResult DeleteAll(string id)
        {

            List<items2> st5 = db.items2.Where(xx => xx.deptid == id).ToList();
            db.items2.RemoveRange(st5);

            dept2 st6 = db.dept2.Find(id);
            if (st6 != null)
            {
                db.dept2.Remove(st6);
            }
            db.SaveChanges();
            return Json("OK");
        }
        [HttpPost]
        public ActionResult UploadFiles()
        {
            if (Request.Form.Files.Count > 0)
            {
                try
                {
                    var files = Request.Form.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        IFormFile file = files[i];
                        string fname;

                        fname = file.FileName;
                        string webRootPath = HostEnvironment.WebRootPath;
                        string fname1 = Path.Combine(webRootPath, "Uploads/" + fname);
                        file.CopyTo(new FileStream(fname1, FileMode.Create));
                    }
                    return Json("File Uploaded Successfully!");
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }
    }

}

