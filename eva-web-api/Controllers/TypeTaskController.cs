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
    public class TypeTaskController : Controller
    {
        UniModel db = new UniModel();

        [HttpGet]
        [AllowAnonymous]
        public JsonResult Get()
        {
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = Json(from c in db.TYPE_TASK.ToList() select new { c.ID_TYPE_TASK, c.DESCRIPTION })
            };
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetById(string IdTypeTask)
        {
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = Json(from c in db.TYPE_TASK.ToList() where c.ID_TYPE_TASK == IdTypeTask select new { c.ID_TYPE_TASK, c.DESCRIPTION })
            };
        }

        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage InsertOrUpdate(TYPE_TASK element)
        {
            TYPE_TASK typetask = db.TYPE_TASK.FirstOrDefault(x => x.ID_TYPE_TASK == element.ID_TYPE_TASK);
            if (typetask == null)
            {
                db.TYPE_TASK.Add(new TYPE_TASK()
                {
                    ID_TYPE_TASK = element.ID_TYPE_TASK,
                    DESCRIPTION = element.DESCRIPTION
                });
            }
            else
            {
                typetask.DESCRIPTION = element.DESCRIPTION;

                db.Entry(typetask).State = EntityState.Modified;
            }

            db.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}