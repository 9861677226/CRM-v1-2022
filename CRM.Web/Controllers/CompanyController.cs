using CRM.Data.Interfaces.Interfaces.Company;
using CRM.Data.Interfaces.Models.Company;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CRM.Web.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompany _CompanyRepository;
        public CompanyController(ICompany CompanyRepository)
        {
             _CompanyRepository = CompanyRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            var companylist = _CompanyRepository.GetAll();
            var json = JsonConvert.SerializeObject(companylist);
            return Content(json);
        }
        
        public JsonResult Add([FromBody] CompanyModel companyModel)
        {
            return Json(_CompanyRepository.Add(companyModel));
        }
        public IActionResult GetbyID(int id)
        {
            var companylist = _CompanyRepository.GetById(id);
            var json = JsonConvert.SerializeObject(companylist);
            return Content(json);
        }
        public IActionResult GetMaxID()
        {
            int maxid = _CompanyRepository.GetMaxId();
            var json = JsonConvert.SerializeObject(maxid);
            return Content(json);
        }
        public JsonResult Update([FromBody] CompanyModel companyModel)
        {
            return Json(_CompanyRepository.Update(companyModel));
        }
        public JsonResult Delete(int id)
        {
            return Json(_CompanyRepository.Delete(id));
        }
    }
}
