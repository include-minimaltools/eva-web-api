using eva_web_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eva_web_api.Controllers
{
    public class StudentController : Controller
    {
        UniModel db = new UniModel();

        [HttpGet]
        [AllowAnonymous]
        public JsonResult Get()
        {
            var result = (from s in db.STUDENT
                          select new
                          {
                              s.CARNET,
                              s.NAME,
                              s.LASTNAME,
                              s.ADDRESS,
                              s.PHONE,
                              s.EMAIL,
                              s.ID_CAREER,
                              s.ID_GROUPS,
                              s.USER_CREATE,
                              s.DATE_CREATE,
                              s.USER_UPDATE,
                              s.DATE_UPDATE
                          }).ToList();

            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = Json(result)
            };
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetById(string Carnet)
        {
            var result = (from s in db.STUDENT
                          select new
                          {
                              s.CARNET,
                              s.NAME,
                              s.LASTNAME,
                              s.ADDRESS,
                              s.PHONE,
                              s.EMAIL,
                              s.ID_CAREER,
                              s.ID_GROUPS,
                              s.USER_CREATE,
                              s.DATE_CREATE,
                              s.USER_UPDATE,
                              s.DATE_UPDATE
                          }).FirstOrDefault(x => x.CARNET == Carnet);

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