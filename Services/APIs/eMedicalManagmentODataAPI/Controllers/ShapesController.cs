using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eMedicalManagementMinimalAPI.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eMedicalManagmentODataAPI.Controllers
{
    public class ShapesController : ODataController
    {
        private static List<Shape> shapes = new List<Shape>
    {
        new Rectangle { Id = 1, Length = 7, Width = 4, Area = 28 },
        new Circle { Id = 2, Radius = 3.5, Area = 38.5 },
        new Rectangle { Id = 3, Length = 8, Width = 5, Area = 40 }
    };
    }
}