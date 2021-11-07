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
    public class TeacherController : Controller
    {
        UniModel db = new UniModel();

        [HttpGet]
        [AllowAnonymous]
        public JsonResult Get()
        {
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = Json(from c in db.TEACHER.ToList() select new { c.ID_TEACHER, c.NAME, c.LASTNAME, c.ADDRESS, c.PHONE, c.ID_FACULTY ,c.EMAIL, c.USER_CREATE, c.DATE_CREATE })
            };
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetById(string IdTeacher)
        {
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = Json(from c in db.TEACHER.ToList() where c.ID_TEACHER == IdTeacher select new { c.ID_TEACHER, c.NAME, c.LASTNAME, c.ADDRESS, c.PHONE, c.ID_FACULTY, c.EMAIL, c.USER_CREATE, c.DATE_CREATE })
            };
        }

        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage InsertOrUpdate(TEACHER element)
        {
            TEACHER teacher = db.TEACHER.FirstOrDefault(x => x.ID_TEACHER == element.ID_TEACHER);
            if (teacher == null)
            {
                db.TEACHER.Add(new TEACHER()
                {
                    ID_TEACHER = element.ID_TEACHER,
                    NAME = element.NAME,
                    LASTNAME = element.LASTNAME,
                    ADDRESS = element.ADDRESS,
                    PHONE = element.PHONE,
                    EMAIL = element.EMAIL,
                    ID_FACULTY = element.ID_FACULTY,
                    DATE_CREATE = element.DATE_CREATE = DateTime.Now,
                    USER_CREATE = "admin"
                });
            }
            else
            {
                teacher.NAME = element.NAME;
                teacher.LASTNAME = element.LASTNAME;
                teacher.ADDRESS = element.ADDRESS;
                teacher.PHONE = element.PHONE;

                teacher.DATE_UPDATE = DateTime.Now;
                teacher.USER_UPDATE = "admin";

                db.Entry(teacher).State = EntityState.Modified;
            }

            db.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}