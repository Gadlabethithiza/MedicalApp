using System;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace eMedicalManagementMVC.Services
{
	public class CustomPageRouteModelConvention : IPageRouteModelConvention
    {
        public void Apply(PageRouteModel model)
        {
            foreach (var selector in model.Selectors.ToList())
            {
                var template = selector.AttributeRouteModel.Template;
                if (template.Contains("/"))
                {
                    // is a folder
                    var segments = template.Split(new[] { '/' }, StringSplitOptions.None);
                    if (segments.Count() == 2)
                    {
                        selector.AttributeRouteModel.Template = $"{segments[0]}/{segments[1].Replace(segments[0], string.Empty).Replace("Index", string.Empty)}".TrimEnd('/');
                    }
                    else
                    {
                        throw new ApplicationException("Nested folders are not permitted");
                    }
                }
            }
        }
    }
}