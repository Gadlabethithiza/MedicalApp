using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eMedicalManagementMinimalAPI.Core.Entities;
using eMedicalManagementMVC.Implementation;
using eMedicalManagementMVC.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace eMedicalManagementMVC.Controllers
{
    public class ProvincesController : Controller
    {
        //https://www.yogihosting.com/aspnet-core-consume-api/

        [BindProperty(SupportsGet = true)]
        public string SearchTerm
        {
            get; set;
        }

        // GET: Provinces
        [HttpGet]
        public async Task<IActionResult> Index(string sortOrder)
        { 
            IProvinceService client = new ProvinceService();

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";       

            var provinceList = await client.GetData();

            switch (sortOrder)
            {
                case "name_desc":
                    provinceList = provinceList.OrderByDescending(s => s.ProvinceName).ToList();
                    break;
                case "Date":
                    provinceList = provinceList.OrderBy(s => s.created_date).ToList();
                    break;
                case "date_desc":
                    provinceList = provinceList.OrderByDescending(s => s.created_date).ToList();
                    break;
                default:
                    provinceList = provinceList.OrderBy(s => s.ProvinceId).ToList();
                    break;
            }

            return View(provinceList);
        }

        //Get Province by ID
        public ViewResult GetProvince() => View();

        [HttpPost]
        public async Task<IActionResult> GetProvince(int id)
        {
            ProvinceItem province = new ProvinceItem();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:8083/api/provinces/" + id))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        province = JsonConvert.DeserializeObject<ProvinceItem>(apiResponse);
                    }
                    else
                        ViewBag.StatusCode = response.StatusCode;
                }
            }
            return View(province);
        }

        //Create Province
        public ViewResult AddProvince() => View();

        [HttpPost]
        public async Task<IActionResult> AddProvince(ProvinceItem province)
        {
            ProvinceItem createProvince = new ProvinceItem();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(province), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:8083/api/provinces", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    createProvince = JsonConvert.DeserializeObject<ProvinceItem>(apiResponse);
                }
            }
            return View(createProvince);
        }

        //[HttpPut]
        public async Task<IActionResult> UpdateProvince(int id)
        {
            ProvinceItem reservation = new ProvinceItem();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("http://localhost:8083/api/provinces/" + id))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        reservation = JsonConvert.DeserializeObject<ProvinceItem>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return View(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProvince(ProvinceItem province)
        {
            ProvinceItem updatedProvince = new ProvinceItem();
            using (var httpClient = new HttpClient())
            {
                //var content = new MultipartFormDataContent();
                //content.Add(new StringContent(reservation.ProvinceId.ToString()), "ProvinceId");
                //content.Add(new StringContent(reservation.ProvinceName), "ProvinceName");
                //content.Add(new StringContent(reservation.modified_date.ToString()), "modifieddate");
                //content.Add(new StringContent(reservation.modified_by), "modifiedby");

                province.modified_by = "Thulani Mathenjwa";
                StringContent content = new StringContent(JsonConvert.SerializeObject(province), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync("http://localhost:8083/api/provinces", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    updatedProvince = JsonConvert.DeserializeObject<ProvinceItem>(apiResponse);
                }
            }

            return View(updatedProvince);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProvince(int ReservationId)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:8083/api/provinces/" + ReservationId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }
    }
}