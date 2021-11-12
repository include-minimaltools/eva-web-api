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
    public class Role_PermissionController : Controller
    {
        UniModel db = new UniModel();

        [HttpGet]
        [AllowAnonymous]
        public JsonResult Get()
        {
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = Json(from c in db.ROLE_PERMISSION.ToList() select new { c.ID_ROLE, c.ID_ROLE_PERMISSION, c.ID_PERMISSION})
            };
        }


        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetById(string IdRole, string IdPermission)
        {
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = Json(from c in db.ROLE_PERMISSION.ToList() where ( c.ID_ROLE == IdRole && c.ID_PERMISSION== IdPermission) select new { c.ID_ROLE_PERMISSION, c.ID_ROLE, c.ID_PERMISSION}), 

            };
        }

        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage InsertOrUpdate(ROLE_PERMISSION element)
        {
            ROLE_PERMISSION Role_Permission = db.ROLE_PERMISSION.FirstOrDefault(x => x.ID_ROLE_PERMISSION == element.ID_ROLE_PERMISSION);
            if (Role_Permission == null)
            {
                db.ROLE_PERMISSION.Add(new ROLE_PERMISSION()
                {
                    ID_ROLE_PERMISSION = element.ID_ROLE_PERMISSION,
                    DATE_CREATE = element.DATE_CREATE = DateTime.Now,
                    USER_CREATE = "admin"
                });
            }
            else
            {
                Role_Permission.ID_ROLE_PERMISSION= element.ID_ROLE_PERMISSION;
                Role_Permission.DATE_UPDATE = DateTime.Now;
                Role_Permission.USER_UPDATE = "admin";
                db.Entry(Role_Permission).State = EntityState.Modified;
            }

            db.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}