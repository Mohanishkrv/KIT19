using KIT19.Data;
using KIT19.Models;
using KIT19.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KIT19.Controllers
{
    public class ProductsController : Controller
    {
        public ProductsController(ProductDbContext productDbContext)
        {
            ProductDbContext = productDbContext;
        }

        public ProductDbContext ProductDbContext { get; }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await ProductDbContext.Products.ToListAsync();
            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel addProductRequest)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                ProductName = addProductRequest.ProductName,
                ProductSize = addProductRequest.ProductSize,
                Category = addProductRequest.Category,
                MfgDate = addProductRequest.MfgDate,
                Price = addProductRequest.Price
            };
            await ProductDbContext.Products.AddAsync(product);
            await ProductDbContext.SaveChangesAsync();
            return RedirectToAction("Add");
        }

        [HttpGet]
        public IActionResult Search()
        {
            var allProducts = ProductDbContext.Products.ToList();
            var viewModel = new SearchProductViewModel
            {
                Products = allProducts
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Search(SearchProductViewModel searchModel)
        {
            var query = ProductDbContext.Products.AsQueryable();

            if (!string.IsNullOrEmpty(searchModel.ProductName))
            {
                query = query.Where(p => p.ProductName.Contains(searchModel.ProductName));
            }

            if (!string.IsNullOrEmpty(searchModel.ProductSize))
            {
                query = query.Where(p => p.ProductSize.Contains(searchModel.ProductSize));
            }

            if (!string.IsNullOrEmpty(searchModel.Category))
            {
                query = query.Where(p => p.Category.Contains(searchModel.Category));
            }

            if (searchModel.Price > 0)
            {
                query = query.Where(p => p.Price == searchModel.Price);
            }

            if (searchModel.MfgDate != default)
            {
                query = query.Where(p => p.MfgDate.Date == searchModel.MfgDate.Date);
            }
            searchModel.Products = await query.ToListAsync();

            return View(searchModel);
        }


    }
}
