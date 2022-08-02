using CRM.Data.Interfaces.Interfaces.Category;
using CRM.Data.Interfaces.Models.Category;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CRM.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategory _CategoryRepository;
        public CategoryController(ICategory CategoryRepository)
        {
            _CategoryRepository = CategoryRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            var categorylist = _CategoryRepository.GetAll();
            var json = JsonConvert.SerializeObject(categorylist);
            return Content(json);
        }

        public IActionResult CompanyList()
        {
            var companylist = _CategoryRepository.GetAllCompany();
            var json = JsonConvert.SerializeObject(companylist);
            return Content(json);
        }

        public JsonResult Add([FromBody] CategoryModel categoryModel)
        {
            return Json(_CategoryRepository.Add(categoryModel));
        }
        public IActionResult GetbyID(int id)
        {
            var category = _CategoryRepository.GetById(id);
            var json = JsonConvert.SerializeObject(category);
            return Content(json);
        }
        public IActionResult GetMaxID()
        {
            int maxid = _CategoryRepository.GetMaxId();
            var json = JsonConvert.SerializeObject(maxid);
            return Content(json);
        }
        public JsonResult Update([FromBody] CategoryModel categoryModel)
        {
            return Json(_CategoryRepository.Update(categoryModel));
        }
        public JsonResult Delete(int id)
        {
            return Json(_CategoryRepository.Delete(id));
        }
    }
}
