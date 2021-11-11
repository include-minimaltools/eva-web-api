using eva_web_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eva_web_api.Controllers
{
    public class RoleController : Controller
    {
        UniModel db = new UniModel();

        [HttpGet]
        [AllowAnonymous]
        public JsonResult Get()
        {
            var result = (from r in db.ROLE
                          select new
                          {
                              r.ID_ROLE,
                              r.DESCRIPTION,
                              r.USER_CREATE,
                              r.DATE_CREATE,
                              r.USER_UPDATE,
                              r.DATE_UPDATE
                          }).ToList();

            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = Json(result)
            };
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetById(string role)
        {
            var result = (from r in db.ROLE
                          select new
                          {
                              r.ID_ROLE,
                              r.DESCRIPTION,
                              r.USER_CREATE,
                              r.DATE_CREATE,
                              r.USER_UPDATE,
                              r.DATE_UPDATE
                          }).FirstOrDefault(x => x.ID_ROLE == role);

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