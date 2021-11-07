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
    public class Student_TaskController : Controller
    {
        UniModel db = new UniModel();

        [HttpGet]
        [AllowAnonymous]
        public JsonResult Get()
        {
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = Json(from c in db.STUDENT_TASK.ToList() select new { c.ID_STUDENT,c.ID_TASK, c.QUALIFICATION, c.SEND_DATE, c.TASK_FILE})
            };
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetById(string IdStudent, string IdTask)
        {
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = Json(from c in db.STUDENT_TASK.ToList() where c.ID_STUDENT == IdStudent && c.ID_TASK == IdTask select new { c.ID_STUDENT, c.ID_TASK, c.QUALIFICATION, c.SEND_DATE, c.TASK_FILE })
            };
        }

        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage InsertOrUpdate(STUDENT_TASK element)
        {
            STUDENT_TASK Student_Task= db.STUDENT_TASK.FirstOrDefault(x => x.ID_STUDENT_TASK== element.ID_STUDENT);
            if (Student_Task== null)
            {
                db.STUDENT_TASK.Add(new STUDENT_TASK()
                {
                    ID_STUDENT_TASK = element.ID_TASK,
                    QUALIFICATION = element.QUALIFICATION,
                    SEND_DATE= element.SEND_DATE,
                    DATE_CREATE = element.DATE_CREATE = DateTime.Now,
                    USER_CREATE = "admin"
                });
            }
            else
            {
                Student_Task.ID_STUDENT_TASK = element.ID_TASK;
                Student_Task.QUALIFICATION = element.QUALIFICATION;
                Student_Task.SEND_DATE = element.SEND_DATE = DateTime.Now;
                Student_Task.DATE_CREATE = element.DATE_CREATE = DateTime.Now;
                Student_Task.USER_CREATE = "admin";
                db.Entry(Student_Task).State = EntityState.Modified;
            }

            db.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }
}