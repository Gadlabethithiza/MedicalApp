using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
//https://dotnet-helpers.com/mvc/retrieve-views-from-different-folders-in-mvc/
//https://www.c-sharpcorner.com/UploadFile/abhikumarvatsa/retrieve-views-from-different-folders-in-mvc/

namespace eMedicalManagementMVC.Controllers
{
    public class AdministrationController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View("~/Views/SchoolModule/Administration/Index.cshtml");
        }
    }
}