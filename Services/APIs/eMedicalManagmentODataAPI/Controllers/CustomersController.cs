using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eMedicalManagementMinimalAPI.Core.Entities;
using eMedicalManagementMinimalAPI.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eMedicalManagmentODataAPI.Controllers
{
    //https://learn.microsoft.com/en-us/odata/webapi-8/tutorials/basic-crud?tabs=net60%2Cvisual-studio-2022%2Cvisual-studio%2Cvs2022

    //[Route("odata")]
    public class CustomersController : ODataController
    {
        private readonly BasicCrudDbContext db;

        public CustomersController(BasicCrudDbContext db)
        {
            this.db = db;
        }

        //GET ALL
        [EnableQuery]
        [HttpGet("odata/Customers")]
        //[HttpGet("Customers")]
        public ActionResult<IQueryable<Customer>> Get()
        {
            return Ok(db.Customers);
        }

        //FIND BY ID
        [ODataIgnored]
        [HttpGet("odata/Customers({id})")]
        //[HttpGet("Customers({id})")]
        public ActionResult Get([FromRoute] int id)
        {
            var customer = db.Customers.SingleOrDefault(d => d.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        //CREATE
        [ODataIgnored]
        public ActionResult Post([FromBody] Customer customer)
        {
            db.Customers.Add(customer);

            return Created(customer);
        }

        //UPDATE
        [ODataIgnored]
        public ActionResult Put([FromRoute] int key, [FromBody] Customer updatedCustomer)
        {
            var customer = db.Customers.SingleOrDefault(d => d.Id == key);

            if (customer == null)
            {
                return NotFound();
            }

            customer.Name = updatedCustomer.Name;
            customer.CustomerType = updatedCustomer.CustomerType;
            customer.CreditLimit = updatedCustomer.CreditLimit;
            customer.CustomerSince = updatedCustomer.CustomerSince;

            db.SaveChanges();

            return Updated(customer);
        }

        //PATCH
        [ODataIgnored]
        public ActionResult Patch([FromRoute] int key, [FromBody] Delta<Customer> delta)
        {
            var customer = db.Customers.SingleOrDefault(d => d.Id == key);

            if (customer == null)
            {
                return NotFound();
            }

            delta.Patch(customer);

            db.SaveChanges();

            return Updated(customer);
        }

        //DELETE
        [ODataIgnored]
        public ActionResult Delete([FromRoute] int key)
        {
            var customer = db.Customers.SingleOrDefault(d => d.Id == key);

            if (customer != null)
            {
                db.Customers.Remove(customer);
            }

            db.SaveChanges();

            return NoContent();
        }
    }
}