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
    public class CampusController : Controller
    {
        UniModel db = new UniModel();

        [HttpGet]
        [AllowAnonymous]
        public JsonResult Get()
        {
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = Json(from c in db.CAMPUS.ToList() select new { c.ID_CAMPUS, c.DESCRIPTION, c.ADDRESS })
            };
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetById(string IdCampus)
        {
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = Json(from c in db.CAMPUS.ToList() where c.ID_CAMPUS == IdCampus select new { c.ID_CAMPUS, c.DESCRIPTION, c.ADDRESS })
            };
        }

        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage InsertOrUpdate(CAMPUS element)
        {
            CAMPUS campus = db.CAMPUS.FirstOrDefault(x => x.ID_CAMPUS == element.ID_CAMPUS);
            if (campus == null)
            {
                db.CAMPUS.Add(new CAMPUS()
                {
                    ID_CAMPUS = element.ID_CAMPUS,
                    DESCRIPTION = element.DESCRIPTION,
                    ADDRESS = element.ADDRESS,
                    DATE_CREATE = element.DATE_CREATE = DateTime.Now,
                    USER_CREATE = "admin"
                });
            }
            else
            {
                campus.ADDRESS = element.ADDRESS;
                campus.DESCRIPTION = element.DESCRIPTION;

                campus.DATE_UPDATE = DateTime.Now;
                campus.USER_UPDATE = "admin";
                db.Entry(campus).State = EntityState.Modified;
            }

            db.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}