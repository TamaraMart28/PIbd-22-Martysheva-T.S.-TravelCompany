using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TravelCompanyCompApp.Models;
using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.ViewModels;
using Microsoft.Extensions.Configuration;

namespace TravelCompanyCompApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            if (Program.Autorized == false)
            {
                return Redirect("~/Home/Enter");
            }
            return
            View(APIClient.GetRequest<List<CompanyViewModel>>($"api/Company/GetCompanyList"));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Enter()
        {
            return View();
        }

        [HttpPost]
        public void Enter(string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                if (_configuration["Password"] != password)
                {
                    throw new Exception("Неверный пароль");
                }
                Program.Autorized = true;
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите пароль");
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (Program.Autorized == false)
            {
                return Redirect("~/Home/Enter");
            }
            return View();
        }

        [HttpPost]
        public void Create(string companyName, string nameResponsible)
        {
            if (String.IsNullOrEmpty(companyName) || String.IsNullOrEmpty(nameResponsible))
            {
                return;
            }
            APIClient.PostRequest("api/Company/CreateOrUpdateCompany", new CompanyBindingModel
            {
                CompanyName = companyName,
                NameResponsible = nameResponsible,
                DateCreate = DateTime.Now,
                CompanyConditions = new Dictionary<int, (string, int)>()
            });
            Response.Redirect("Index");
        }

        [HttpGet]
        public IActionResult AddCondition()
        {
            if (Program.Autorized == false)
            {
                return Redirect("~/Home/Enter");
            }
            ViewBag.Companies = APIClient.GetRequest<List<CompanyViewModel>>("api/Company/GetCompanyList");
            ViewBag.Conditions = APIClient.GetRequest<List<ConditionViewModel>>("api/Company/GetConditionsList");
            return View();
        }

        [HttpPost]
        public void AddCondition(int company, int condition, int count)
        {
            APIClient.PostRequest("api/Company/AddConditionToCompany", new AddConditionBindingModel
            {
                Id = company,
                ConditionId = condition,
                Count = count
            });
            Response.Redirect("Index");
        }

        [HttpGet]
        public IActionResult Delete()
        {
            if (Program.Autorized == false)
            {
                return Redirect("~/Home/Enter");
            }
            ViewBag.Companies = APIClient.GetRequest<List<CompanyViewModel>>("api/Company/GetCompanyList");
            return View();
        }

        [HttpPost]
        public void Delete(int company)
        {
            APIClient.PostRequest("api/Company/DeleteCompany", new CompanyBindingModel
            {
                Id = company
            });
            Response.Redirect("Index");
        }

        [HttpGet]
        public IActionResult Privacy(int companyId)
        {
            if (Program.Autorized == false)
            {
                return Redirect("~/Home/Enter");
            }
            CompanyViewModel company = APIClient.GetRequest<CompanyViewModel>($"api/Company/GetCompany?companyId={companyId}");
            ViewBag.CompanyName = company.CompanyName;
            ViewBag.NameResponsible = company.NameResponsible;
            ViewBag.CompanyConditions = company.CompanyConditions.Values;
            return View();
        }

        [HttpPost]
        public void Privacy(int companyId, string companyName, string nameResponsible)
        {
            if (String.IsNullOrEmpty(companyName) || String.IsNullOrEmpty(nameResponsible))
            {
                return;
            }
            CompanyViewModel company = APIClient.GetRequest<CompanyViewModel>($"api/Company/GetCompany?companyId={companyId}");
            APIClient.PostRequest("api/Company/CreateOrUpdateCompany", new CompanyBindingModel
            {
                Id = companyId,
                CompanyName = companyName,
                NameResponsible = nameResponsible,
                CompanyConditions = company.CompanyConditions,
                DateCreate = DateTime.Now
            });
            Response.Redirect("Index");
        }
    }
}
