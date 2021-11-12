using eva_web_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eva_web_api.Controllers
{
    public class FacultyController : Controller
    {
        UniModel db = new UniModel();

        [HttpGet]
        [AllowAnonymous]
        public JsonResult Get()
        {
            var result = (from f in db.FACULTY
                          select new
                          {
                              f.ID_FACULTY,
                              f.DESCRIPTION,
                              f.USER_CREATE,
                              f.DATE_CREATE,
                              f.USER_UPDATE,
                              f.DATE_UPDATE
                          }).ToList();

            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = Json(result)
            };
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetById(string ID_FACULTY)
        {
            var result = (from f in db.FACULTY
                          select new
                          {
                              f.ID_FACULTY,
                              f.DESCRIPTION,
                              f.USER_CREATE,
                              f.DATE_CREATE,
                              f.USER_UPDATE,
                              f.DATE_UPDATE
                          }).FirstOrDefault(x => x.ID_FACULTY == ID_FACULTY);

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