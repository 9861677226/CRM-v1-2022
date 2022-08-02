using CRM.Data.Interfaces.Interfaces.Product;
using CRM.Data.Interfaces.Models.Product;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CRM.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _ProductRepository;
        public ProductController(IProduct ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            var productlist = _ProductRepository.GetAll();
            var json = JsonConvert.SerializeObject(productlist);
            return Content(json);
        }
        public IActionResult FinYear()
        {
            var finYear = _ProductRepository.GetFinYear();
            var json = JsonConvert.SerializeObject(finYear);
            return Content(json);
        }

        public IActionResult CompanyList()
        {
            var companylist = _ProductRepository.GetAllCompany();
            var json = JsonConvert.SerializeObject(companylist);
            return Content(json);
        }

        public IActionResult CategoryList(int id)
        {
            var categorylist = _ProductRepository.GetAllCategory(id);
            var json = JsonConvert.SerializeObject(categorylist);
            return Content(json);
        }

        public JsonResult Add([FromBody] ProductModel categoryModel)
        {
            return Json(_ProductRepository.Add(categoryModel));
        }
        public IActionResult GetbyID(int id)
        {
            var product = _ProductRepository.GetById(id);
            var json = JsonConvert.SerializeObject(product);
            return Content(json);
        }
        public IActionResult GetMaxID()
        {
            int maxid = _ProductRepository.GetMaxId();
            var json = JsonConvert.SerializeObject(maxid);
            return Content(json);
        }
        public JsonResult Update([FromBody] ProductModel categoryModel)
        {
            return Json(_ProductRepository.Update(categoryModel));
        }
        public JsonResult Delete(int id)
        {
            return Json(_ProductRepository.Delete(id));
        }
    }
}
