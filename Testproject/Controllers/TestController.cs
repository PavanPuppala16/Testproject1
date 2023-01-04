using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Testproject.Models;
using Testproject.business_Logic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;


namespace Testproject.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Employee obj)
        {
            if (ModelState.IsValid)
            {
                bool res = Logic_bl.InsertData2(obj);
                if (res == true)
                {
                    return RedirectToAction("Display2", "Test");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult Display2()
        {
            return View(Logic_bl.GetAllData3());
        }
        [HttpGet]
        public IActionResult Edit2(int? Id)
        {
            return View(Logic_bl.GetuserByID2((int)Id));
        }
        [HttpPost]
        public IActionResult Edit2(Employee obj)
        {
            if (ModelState.IsValid)
            {
                bool res = (Logic_bl.UpdateData2(obj));
                if (res == true)
                {
                    return RedirectToAction("Display2", "Test");
                }
                else
                {
                    return View(obj);
                }
            }
            return View();
        }
        public IActionResult Delete2(int? Id)
        {
            bool res = Logic_bl.DeleteData2((int)Id);
            if (res == true)
            {
                return RedirectToAction("Display2");
            }
            else
            {
                return View();
            }
            return View();
        }
        public IActionResult template()
        {
            return View();
        }
    }

 }

