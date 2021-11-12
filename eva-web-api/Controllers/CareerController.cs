using eva_web_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eva_web_api.Controllers
{
    public class CareerController : Controller
    {
        UniModel db = new UniModel();

        [HttpGet]
        [AllowAnonymous]
        public JsonResult Get()
        {
            var result = (from c in db.CAREER
                          select new
                          {
                              c.ID_CAREER,
                              c.DESCRIPTION,
                              c.FACULTY,
                              c.CAMPUS,
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
        public JsonResult GetById(string ID_CARRER)
        {
            var result = (from c in db.CAREER
                          select new
                          {
                              c.ID_CAREER,
                              c.DESCRIPTION,
                              c.FACULTY,
                              c.CAMPUS,
                              c.USER_CREATE,
                              c.DATE_CREATE,
                              c.USER_UPDATE,
                              c.DATE_UPDATE
                          }).FirstOrDefault(x => x.ID_CAREER == ID_CARRER);

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