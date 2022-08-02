using CRM.Data.Interfaces.Interfaces.Customer;
using CRM.Data.Interfaces.Models.Customer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CRM.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomer _CustomerRepository;
        public CustomerController(ICustomer CustomerRepository)
        {
            _CustomerRepository = CustomerRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            var companylist = _CustomerRepository.GetAll();
            var json = JsonConvert.SerializeObject(companylist);
            return Content(json);
        }

        public JsonResult Add([FromBody] CustomerModel customerModel)
        {
            return Json(_CustomerRepository.Add(customerModel));
        }
        public IActionResult GetbyID(int id)
        {
            var companylist = _CustomerRepository.GetById(id);
            var json = JsonConvert.SerializeObject(companylist);
            return Content(json);
        }
        public IActionResult GetMaxID()
        {
            int maxid = _CustomerRepository.GetMaxId();
            var json = JsonConvert.SerializeObject(maxid);
            return Content(json);
        }
        public JsonResult Update([FromBody] CustomerModel customerModel)
        {
            return Json(_CustomerRepository.Update(customerModel));
        }
        public JsonResult Delete(int id)
        {
            return Json(_CustomerRepository.Delete(id));
        }
    }
}
