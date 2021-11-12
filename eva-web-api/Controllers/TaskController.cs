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
    public class TaskController : Controller
    {
        UniModel db = new UniModel();

        [HttpGet]
        [AllowAnonymous]
        public JsonResult Get()
        {
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = Json(from c in db.TASK.ToList() select new { c.ID_TASK, c.NAME, c.DESCRIPTION, c.DELIVERY_DATE, c.ID_COURSE, c.ID_TYPE_TASK })
            };
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetById(string IdTask)
        {
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = Json(from c in db.TASK.ToList() where c.ID_TASK == IdTask select new { c.ID_TASK, c.NAME, c.DESCRIPTION, c.DELIVERY_DATE, c.ID_COURSE, c.ID_TYPE_TASK })
            };
        }

        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage InsertOrUpdate(TASK element)
        {
            TASK task = db.TASK.FirstOrDefault(x => x.ID_TASK == element.ID_TASK);
            if (task == null)
            {
                db.TASK.Add(new TASK()
                {
                    ID_TASK = element.ID_TASK,
                    NAME = element.NAME,
                    DESCRIPTION = element.DESCRIPTION,
                    DELIVERY_DATE = element.DELIVERY_DATE,
                    ID_COURSE = element.ID_COURSE,
                    ID_TYPE_TASK = element.ID_TYPE_TASK
                });
            }
            else
            {
                task.NAME = element.NAME;
                task.DESCRIPTION = element.DESCRIPTION;
                task.DELIVERY_DATE = element.DELIVERY_DATE;

                db.Entry(task).State = EntityState.Modified;
            }

            db.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}