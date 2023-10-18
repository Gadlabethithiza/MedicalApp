using System;
using eMedicalManagementMinimalAPI.Core.Entities;
using eMedicalManagementMVC.Interfaces;
using Newtonsoft.Json;

namespace eMedicalManagementMVC.Implementation
{
	public class ProvinceService : IProvinceService
    {
        //private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        //public ProvinceService(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        //{
        //    _hostingEnvironment = hostingEnvironment;
        //}

        public async Task<List<ProvinceItem>> GetPaginatedResult(int currentPage, int pageSize = 3)
        {
            var data = await GetData();
            return data.OrderBy(d => d.ProvinceId).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }

        public async Task<int> GetCount()
        {
            var data = await GetData();
            return data.Count();
        }

        public async Task<List<ProvinceItem>> GetData()
        {
            List<ProvinceItem> provinceList = new List<ProvinceItem>();

            try
            {

                try
                {
                    using (var httpClient = new HttpClient())
                    {
                        using (var response = await httpClient.GetAsync("http://localhost:8083/api/provinces"))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            provinceList = JsonConvert.DeserializeObject<List<ProvinceItem>>(apiResponse);
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            catch (Exception ex)
            {

            }

            return provinceList;
        }



    }
}

