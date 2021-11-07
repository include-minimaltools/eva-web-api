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
    public class GroupsController : Controller
    {
        UniModel db = new UniModel();

        [HttpGet]
        [AllowAnonymous]
        public JsonResult Get()
        {
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = Json(from c in db.GROUPS.ToList() select new { c.ID_GROUPS, c.NAME })
            };
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetById(string IdGroups)
        {
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = Json(from c in db.GROUPS.ToList() where c.ID_GROUPS == IdGroups select new { c.ID_GROUPS, c.NAME})
            };
        }

        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage InsertOrUpdate(GROUPS element)
        {
            GROUPS groups = db.GROUPS.FirstOrDefault(x => x.ID_GROUPS == element.ID_GROUPS);
            if (groups == null)
            {
                db.GROUPS.Add(new GROUPS()
                {
                    ID_GROUPS = element.ID_GROUPS,
                    NAME = element.NAME
                });
            }
            else
            {
                groups.NAME = element.NAME;

                db.Entry(groups).State = EntityState.Modified;
            }

            db.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}