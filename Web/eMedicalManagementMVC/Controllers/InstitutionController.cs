using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eMedicalManagementMinimalAPI.Core.Entities;
using eMedicalManagementMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eMedicalManagementMVC.Controllers
{
    public class InstitutionController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();

            //IEnumerable<InstitutionItem> institutionList = new List<InstitutionItem>();

            //try
            //{
            //    using (var httpClient = new HttpClient())
            //    {
            //        using (var response = await httpClient.GetAsync("http://localhost:8083/api/institutions"))
            //        {
            //            string apiResponse = await response.Content.ReadAsStringAsync();
            //            institutionList = JsonConvert.DeserializeObject<List<InstitutionItem>>(apiResponse);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //}

            //return View(institutionList);
        }



    }
}

