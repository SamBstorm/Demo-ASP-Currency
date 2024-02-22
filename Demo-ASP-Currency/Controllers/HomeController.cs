using Demo_ASP_Currency.Handlers;
using Demo_ASP_Currency.Models;
using Demo_Mockup_Currency.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Demo_ASP_Currency.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductService _service;

        public HomeController(ILogger<HomeController> logger, ProductService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            IEnumerable<ProductListItem> model = _service.Get().Select(p => p.ToListItem());
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductCreateForm form)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                _service.Insert(form.ToProduct());
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public IActionResult Edit(Guid id)
        {
            ProductEditForm model = _service.Get(id).ToEditForm();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, ProductEditForm form)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ProductEditForm model = _service.Get(id).ToEditForm();
                return View(model);
            }
        }
        public IActionResult Delete(Guid id)
        {
            ProductDetails model = _service.Get(id).ToDetails();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id, ProductDetails details)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
