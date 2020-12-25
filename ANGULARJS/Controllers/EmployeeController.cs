using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
namespace ANGULARJS.Controllers
{
    public class EmployeeController : Controller
    {
        DAL.EmployeeRegistration ob = new EmployeeRegistration();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult AddEmployee(DAL.DALPROPERTIES.Employeereg emp)
        {
            return Json(ob.Add(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult List()
        {
            return Json(ob.ListAll(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(DAL.DALPROPERTIES.Employeereg Emp)
        {
            return Json(ob.DeleteEmployee(Emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(DAL.DALPROPERTIES.Employeereg Employe)


        {
            return Json(ob.Update(Employe), JsonRequestBehavior.AllowGet);
        }
    }
}
