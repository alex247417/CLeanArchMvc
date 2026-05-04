using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CleanArchMvc.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task <IActionResult> Index()
        {
            var categories = await _categoryService.GetCategoriesAsync();

            return View(categories);
        }
    }
}
