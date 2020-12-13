using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AT.Data.Model;
using AT.Service;
using AT.Web.UI.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AT.Web.UI.Controllers
{
    public class InsuredReserveController : Controller
    {
        private readonly IInsuredUserService _insuredUserService;

        public InsuredReserveController(IInsuredUserService insuredUserService)
        {
            _insuredUserService = insuredUserService;
        }

        public IActionResult Index()
        {
            var model = new UserViewModel
            {
                InsuredUsers = _insuredUserService.GetAllInclude().Where(x => x.IsConfirm != true)
            };
            return View(model);
        }

        public IActionResult ReserveList()
        {
            var model = new UserViewModel
            {
                InsuredUsers = _insuredUserService.GetAllInclude().Where(x => x.IsConfirm != false)
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var insured = _insuredUserService.GetById(id);
            return Ok(insured);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(UserViewModel model)
        {
            var returnModel = new ReturnModel();

            if (model.InsuredUser.ConfirmRezervDate == null)
            {
                returnModel.IsSuccess = false;
                returnModel.Message = "TARİH GİRİNİZ";
                return Ok(returnModel);
            }

            var insured = _insuredUserService.GetById(model.InsuredUser.Id);

            insured.IsConfirm = true;
            insured.ConfirmRezervDate = model.InsuredUser.ConfirmRezervDate;

            try
            {
                _insuredUserService.Update(insured);
                returnModel.IsSuccess = true;
                returnModel.Message = "Rezervasyon Güncellendi";
            }
            catch (Exception ex)
            {
                returnModel.Message = "Hata Oluştu" + ex.Message;
            }

            return Ok(returnModel);
        }
    }
}