using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DapperSampleProject.Services;
using DapperSampleProject.ViewModels;
//dotnet add package ExcelDataReader
using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperSampleProject.Controllers
{
    public class ProductController : Controller
    {
        private IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await productService.GetAsync();
            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await productService.GetCategoryForComboAsync();
            ViewBag.Suppliers = await productService.GetSupplierForComboAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            //await productService.AddAsync(model);
            await productService.AddWithSPAsync(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Categories = await productService.GetCategoryForComboAsync();
            ViewBag.Suppliers = await productService.GetSupplierForComboAsync();
            var product = await productService.GetByIdAsync(id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel model)
        {
            //validation
            await productService.UpdateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await productService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> BulkInsert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BulkInsert(IFormFile excelFile)
        {
            var products = new List<ProductViewModel>();
            using (var ms = new MemoryStream())
            {
                excelFile.CopyTo(ms);
                using (var reader = ExcelReaderFactory.CreateReader(ms))
                {
                    // Choose one of either 1 or 2:

                    // 1. Use the reader methods
                    do
                    {
                        while (reader.Read())
                        {
                            if(reader[0].ToString().ToLower() == "ProductName".ToLower()) continue;
                            var product = new ProductViewModel();
                            product.ProductName = reader[0].ToString();
                            product.CategoryId = Convert.ToInt32(reader[1]);
                            product.SupplierId = Convert.ToInt32(reader[2]);
                            product.UnitPrice = Convert.ToDouble(reader[3]);
                            products.Add(product);
                        }
                    } while (reader.NextResult());
                }

                if(products.Count > 0)
                {
                    await productService.BulkAddAsync(products);
                }
            }
            return View(RedirectToAction(nameof(Index)));
        }

        [HttpPost]
        public async Task<IActionResult> BulkDelete(int[] ids){
            await productService.BulkDeleteAsync(ids);
            return Ok();
        }

        public async Task<IActionResult> ShowProductsAndCategories()
        {
            var products = new List<ProductViewModel>();
            var categories = new List<CategoryViewModel>();
            (products,categories) = await productService.GetProductsAndCategoriesAsync();
            ViewData["Categories"] = categories;
            return View(products);
        }
    }
}