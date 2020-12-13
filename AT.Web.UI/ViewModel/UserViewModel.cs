using AT.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AT.Web.UI.ViewModel
{
    public class UserViewModel
    {
        public InsuredUser InsuredUser { get; set; }
        public List<SelectListItem> CityList { get; set; }
        public IEnumerable<InsuredUser> InsuredUsers { get; set; }


    }
}
