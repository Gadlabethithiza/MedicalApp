using System;
using eMedicalManagementMinimalAPI.Core.Entities;

namespace eMedicalManagementMVC.Services
{
	public class ProvinceModel
	{
        ///<summary>
        /// Gets or sets Customers.
        ///</summary>
        public List<ProvinceItem> ProvincesData { get; set; }

        ///<summary>
        /// Gets or sets CurrentPageIndex.
        ///</summary>
        public int CurrentPageIndex { get; set; }

        ///<summary>
        /// Gets or sets PageCount.
        ///</summary>
        public int PageCount { get; set; }

        ///<summary>
        /// Gets or sets PageCount.
        ///</summary>
        public int Count { get; set; }
    }
}

