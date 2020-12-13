using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AT.Web.UI.Models;
using AT.Service;
using AT.Data.Entities;
using AT.Web.UI.ViewModel;
using AT.Data.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using AT.Data.Helpers;

namespace AT.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IInsuredUserService _insuredUserService;
        private readonly ICityService _cityService;
        private readonly IDistrictService _districtService;
        public HomeController(IInsuredUserService insuredUserService, ICityService cityService, IDistrictService districtService)
        {
            _insuredUserService = insuredUserService;
            _cityService = cityService;
            _districtService = districtService;
        }

        public IActionResult Index()
        {
            var model = new UserViewModel
            {
                CityList = GetCityList()
            };
            return View(model);
        }

        private List<SelectListItem> GetCityList()
        {
            var cities = _cityService.GetAll();
            var cityList = (from c in cities
                            select new SelectListItem
                            {
                                Value = c.Id.ToString(),
                                Text = c.Name

                            }).ToList();
            return cityList;
        }

        public IActionResult GetDistrictList(int cityId)
        {
            var model = _districtService.GetDistrictList(cityId);
            return Ok(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Index(UserViewModel model)
        {
            var returnModel = new ReturnModel();

            if (!ModelState.IsValid)
            {
                returnModel.IsSuccess = false;
                returnModel.Message = "Formu Eksiksiz Doldurunuz";
                return Ok(returnModel);
            }

            var confirmTc = IdentityControl.TcNo(model.InsuredUser.IdentityNo);
            if (!confirmTc)
            {
                returnModel.IsSuccess = false;
                returnModel.Message = "TC KİMLİK HATASI";
                return Ok(returnModel);
            }

            var newInsured = new InsuredUser
            {
                FirstName = model.InsuredUser.FirstName,
                LastName = model.InsuredUser.LastName,
                PolicyNo = model.InsuredUser.PolicyNo,
                IdentityNo = model.InsuredUser.IdentityNo,
                CityId = model.InsuredUser.CityId,
                DistrictId = model.InsuredUser.DistrictId,
                RezervDate = model.InsuredUser.RezervDate,
                IsConfirm = false,
                CreatedBy = string.Format("{0} {1}", model.InsuredUser.FirstName, model.InsuredUser.LastName),
                CreatedDate = DateTime.Now,
                UpdatedBy = string.Format("{0} {1}", model.InsuredUser.FirstName, model.InsuredUser.LastName),
                UpdatedDate = DateTime.Now 
            };

            try
            {
                _insuredUserService.Add(newInsured);
                returnModel.IsSuccess = true;
                returnModel.Message = "Kayıt Başarılı";
            }
            catch (Exception ex)
            {
                returnModel.Message = "Hata Oluştu" + ex.Message;
            }

            return Ok(returnModel);
        }


    }
}
