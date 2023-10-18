using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using eMedicalManagementMinimalAPI.Core.Entities;
using eMedicalManagementMinimalAPI.Core.Interfaces.Learning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eMedicalManagmentODataAPI.Controllers
{
    public class CompaniesController : ODataController
    {
        private readonly ICompanyRepo _repo;
        public CompaniesController(ICompanyRepo repo)
        {
            _repo = repo;
        }


        [EnableQuery(PageSize = 3)]
        [HttpGet]
        public IQueryable<Company> Get()
        {
            return _repo.GetAll();
        }

        [EnableQuery]
        [HttpGet("{id}")]
        public SingleResult<Company> Get([FromODataUri] int key)
        {
            return SingleResult.Create(_repo.GetById(key));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repo.Create(company);
            return Created("companies", company);
        }

        [HttpPut]
        public IActionResult Put([FromODataUri] int key, [FromBody] Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != company.ID)
            {
                return BadRequest();
            }
            _repo.Update(company);
            return NoContent();
        }


        [HttpDelete]
        public IActionResult Delete([FromODataUri] int key)
        {
            var company = _repo.GetById(key);
            if (company is null)
            {
                return BadRequest();
            }
            _repo.Delete(company.First());
            return NoContent();
        }

    }
}