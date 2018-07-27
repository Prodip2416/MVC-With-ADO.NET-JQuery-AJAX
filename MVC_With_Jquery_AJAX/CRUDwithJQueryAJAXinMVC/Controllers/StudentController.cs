using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using FullCRUDWithJquery.Models;
using Newtonsoft.Json;

namespace FullCRUDWithJquery.Controllers
{
    public class StudentController : Controller
    {
        StudentDB studentDb= new StudentDB();
        DepartmentDB departmentDb= new DepartmentDB();
        public ActionResult Index()
        {
            ViewBag.ListDepartment = new SelectList(departmentDb.GetAllStudent(), "DepartmentId", "DepartmentName");
            return View();
        }

        public JsonResult GetAllStudent()
        {
            return Json(studentDb.GetAllStudent(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStudentById(int id)
        {
            Student student = studentDb.GetAllStudent().Find(x => x.StudentId == id);
            string value=String.Empty;

            value = JsonConvert.SerializeObject(student, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
               return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddStudent(Student student)
        {
            bool result = false;
            if (studentDb.AddStudent(student))
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return Json(result,JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateStudent(int id,Student student)
        {
            bool result = false;
            if (studentDb.UpdateStudent(student))
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteStudent(int studentId)
        {
            bool result = false;
            if (studentDb.DeleteStudent(studentId))
            {
                result = true;
            }
            else
            {
                result= false;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}