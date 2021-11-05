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
    public class TeacherCourseController : Controller
    {
        UniModel db = new UniModel();

        [HttpGet]
        [AllowAnonymous]
        public JsonResult Get()
        {
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = Json(from c in db.TEACHER_COURSE.ToList() select new { c.ID_TEACHER, c.ID_COURSE ,c.USER_CREATE, c.DATE_CREATE })
            };
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetById(string IdTeacher, int IdCourse)
        {
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = Json(from c in db.TEACHER_COURSE.ToList() where (c.ID_TEACHER == IdTeacher && c.ID_COURSE == IdCourse)  select new { c.ID_TEACHER, c.ID_COURSE, c.USER_CREATE, c.DATE_CREATE })
            };
        }

        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage InsertOrUpdate(TEACHER_COURSE element)
        {
            TEACHER_COURSE teachercourse = db.TEACHER_COURSE.FirstOrDefault(x => (x.ID_TEACHER == element.ID_TEACHER && x.ID_COURSE == element.ID_COURSE));
            if (teachercourse == null)
            {
                db.TEACHER_COURSE.Add(new TEACHER_COURSE()
                {
                    ID_TEACHER = element.ID_TEACHER,
                    ID_COURSE = element.ID_COURSE,
                    DATE_CREATE = element.DATE_CREATE = DateTime.Now,
                    USER_CREATE = "admin"
                });
            }
            else
            {
                teachercourse.DATE_UPDATE = DateTime.Now;
                teachercourse.USER_UPDATE = "admin";

                db.Entry(teachercourse).State = EntityState.Modified;
            }

            db.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}