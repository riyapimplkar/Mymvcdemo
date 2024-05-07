using Mymvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mymvcdemo.Controllers
{
    public class mvcdemoController : Controller
    {
        // GET: mvcdemo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult mvcdemoIndex()
        {
            return View();
        }
        public ActionResult DetailsIndex(int Id)
        {
            ViewBag.Id = Id;
            return View();
        }
        public ActionResult Savereg(mvcdemoModel model)
        {
            try
            {
                return Json(new { Message = (new mvcdemoModel().Savereg(model)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult GetRegistrationList(mvcdemoModel model)
        {
            try
            {
                return Json(new { model = new mvcdemoModel().GetRegistrationList() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult deleteRegistration(int Id)
        {
            try
            {
                return Json(new { model = new mvcdemoModel().deleteRegistration(Id) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult getRegisterbyID(int Id)
        {
            try
            {
                return Json(new { model = new mvcdemoModel().getRegisterbyID(Id) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
    
