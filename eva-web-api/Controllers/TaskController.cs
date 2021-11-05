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
                Data = Json(from c in db.TASK.ToList() select new { c.NAME, c.DESCRIPTION, c.DELIVERY_DATE, c.FK_ID_COURSE })
            };
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetById(string IdTask)
        {
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = Json(from c in db.TASK.ToList() where c.ID_TASK == IdTask select new { c.NAME, c.DESCRIPTION, c.DELIVERY_DATE, c.FK_ID_COURSE })
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
                    FK_ID_COURSE = element.FK_ID_COURSE
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