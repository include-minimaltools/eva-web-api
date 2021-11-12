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
    public class SemesterController : Controller
    {
        UniModel db = new UniModel();

        [HttpGet]
        [AllowAnonymous]
        public JsonResult Get()
        {
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = Json(from c in db.SEMESTER.ToList() select new { c.ID_SEMESTER, c.N_SEMESTER, c.ID_CAREER, c.ID_COURSE})
            };
        }


        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetById(string IdCarrer, int IdCourse)
        {
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = Json(from c in db.SEMESTER.ToList() where (c.ID_CAREER == IdCarrer && c.ID_COURSE == IdCourse) select new { c.ID_SEMESTER, c.N_SEMESTER, c.ID_CAREER, c.ID_COURSE}),

            };
        }

        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage InsertOrUpdate(SEMESTER element)
        {
            SEMESTER Semester = db.SEMESTER.FirstOrDefault(x => x.ID_SEMESTER == element.ID_SEMESTER);
            if (Semester == null)
            {
                db.SEMESTER.Add(new SEMESTER()
                {
                    ID_SEMESTER = element.ID_SEMESTER,
                    N_SEMESTER =element.N_SEMESTER
                });
            }
            else
            {
                Semester.ID_SEMESTER = element.ID_SEMESTER;
                Semester.N_SEMESTER = element.N_SEMESTER;
                db.Entry(Semester).State = EntityState.Modified;
            }

            db.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}