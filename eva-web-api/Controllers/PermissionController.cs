using eva_web_api.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace eva_web_api.Controllers
{
    public class PermissionController : Controller
    {
        
        UniModel db = new UniModel();

        [HttpGet]
        [AllowAnonymous]
        public JsonResult Get()
        {
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = Json(from c in db.PERMISSION.ToList() select new { c.DESCRIPTION, c.PAGE, c.ACTION })
            };
        }


        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetById(string IdPermisson)
        {
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = Json(from c in db.PERMISSION.ToList() where c.ID_PERMISSION == IdPermisson select new { c.DESCRIPTION, c.PAGE, c.ACTION })
            };
        }

        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage InsertOrUpdate(PERMISSION element)
        {
            PERMISSION permission = db.PERMISSION.FirstOrDefault(x => x.ID_PERMISSION == element.ID_PERMISSION);
            if (permission == null)
            {
                db.CAMPUS.Add(new CAMPUS()
                {
                    ID_CAMPUS = element.ID_PERMISSION,
                    DESCRIPTION = element.DESCRIPTION,
                    ADDRESS = element.PAGE,
                    DATE_CREATE = element.DATE_CREATE = DateTime.Now,
                    USER_CREATE = "admin"
                });
            }
            else
            {
                permission.PAGE = element.PAGE;
                permission.DESCRIPTION = element.DESCRIPTION;

                permission.DATE_UPDATE = DateTime.Now;
                permission.USER_UPDATE = "admin";
                db.Entry(permission).State = EntityState.Modified;
            }

            db.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}