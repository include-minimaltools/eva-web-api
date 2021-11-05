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
    public class TaskCommentController : Controller
    {
        UniModel db = new UniModel();

        [HttpGet]
        [AllowAnonymous]
        public JsonResult Get()
        {
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = Json(from c in db.TASK_COMMENT.ToList() select new { c.ID_STUDENT_TASK ,c.EMAIL_USER, c.TYPE_TASK, c.DESCRIPTON, c.USER_CREATE, c.DATE_CREATE })
            };
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetById(string IdTaskComment)
        {
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = Json(from c in db.TASK_COMMENT.ToList() where c.ID_TASK_COMMENT == IdTaskComment select new { c.ID_STUDENT_TASK, c.EMAIL_USER, c.TYPE_TASK, c.DESCRIPTON, c.USER_CREATE, c.DATE_CREATE })
            };
        }

        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage InsertOrUpdate(TASK_COMMENT element)
        {
            TASK_COMMENT taskcomment = db.TASK_COMMENT.FirstOrDefault(x => x.ID_TASK_COMMENT == element.ID_TASK_COMMENT);
            if (taskcomment == null)
            {
                db.TASK_COMMENT.Add(new TASK_COMMENT()
                {
                    ID_TASK_COMMENT = element.ID_TASK_COMMENT,
                    ID_STUDENT_TASK = element.ID_STUDENT_TASK,
                    EMAIL_USER = element.EMAIL_USER,
                    TYPE_TASK = element.TYPE_TASK,
                    DESCRIPTON = element.DESCRIPTON,
                    DATE_CREATE = element.DATE_CREATE = DateTime.Now,
                    USER_CREATE = "admin"
                });
            }
            else
            {
                taskcomment.DESCRIPTON = element.DESCRIPTON;

                taskcomment.DATE_UPDATE = DateTime.Now;
                taskcomment.USER_UPDATE = "admin";
                db.Entry(taskcomment).State = EntityState.Modified;
            }

            db.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}