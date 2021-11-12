using eva_web_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eva_web_api.Controllers
{
    public class CourseController : Controller
    {
        UniModel db = new UniModel();

        [HttpGet]
        [AllowAnonymous]
        public JsonResult Get()
        {
            var result = (from c in db.COURSE
                          select new
                          {
                              c.ID_COURSE,
                              c.NAME,
                              c.DESCRIPTION,
                              c.OBJECTS,
                              c.CREDITS,
                              c.FRECUENCY,
                              c.HOURS,
                              c.ID_CAREER,
                              c.USER_CREATE,
                              c.DATE_CREATE,
                              c.USER_UPDATE,
                              c.DATE_UPDATE
                          }).ToList();

            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = Json(result)
            };
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetById(int ID_COURSE)
        {
            var result = (from c in db.COURSE
                          select new
                          {
                              c.ID_COURSE,
                              c.NAME,
                              c.DESCRIPTION,
                              c.OBJECTS,
                              c.CREDITS,
                              c.FRECUENCY,
                              c.HOURS,
                              c.ID_CAREER,
                              c.USER_CREATE,
                              c.DATE_CREATE,
                              c.USER_UPDATE,
                              c.DATE_UPDATE
                          }).FirstOrDefault(x => x.ID_COURSE == ID_COURSE);

            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = Json(result)
            };
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult InsertOrUpdate()
        {
            return null;
        }
    }
}