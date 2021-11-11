using eva_web_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eva_web_api.Controllers
{
    public class StudentCourseController : Controller
    {
        UniModel db = new UniModel();

        [HttpGet]
        [AllowAnonymous]
        public JsonResult Get()
        {
            var result = (from sc in db.STUDENT_COURSE
                            select new
                            {
                                sc.ID_COURSE,
                                sc.ID_STUDENT,
                                sc.USER_CREATE,
                                sc.DATE_CREATE,
                                sc.USER_UPDATE,
                                sc.DATE_UPDATE
                            }).ToList();

            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = Json(result)
            };
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetById(string ID_STUDENT, int ID_COURSE)
        {
            var result = (from sc in db.STUDENT_COURSE
                          select new
                          {
                              sc.ID_COURSE,
                              sc.ID_STUDENT,
                              sc.USER_CREATE,
                              sc.DATE_CREATE,
                              sc.USER_UPDATE,
                              sc.DATE_UPDATE
                          }).FirstOrDefault(x => x.ID_STUDENT == ID_STUDENT && x.ID_COURSE == ID_COURSE);

            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = Json(result)
            };
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult InsertOrUpdate(STUDENT_COURSE entity)
        {
            return null;
        }
    }
}