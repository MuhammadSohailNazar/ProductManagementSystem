using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.Contracts.V1;
using ProductManagementSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagementSystem.Controllers.V1
{
    public class ProductsController : Controller
    {
        private List<Product> _products;
        public ProductsController()
        {
            _products = new List<Product>();
            for (int i = 1; i < 10; i++)
            {
                _products.Add(
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = $"Product {i}",
                        ProductCode = Guid.NewGuid().ToString(),
                        Description = $"Product {i} description.",
                        TermsAndConditions = $"Product {i} Term and Conditions.",
                        Specification = $"Product {i} Specification.",
                        IsActive = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        IsDeleted = false,
                        ProductBrandId = Guid.NewGuid(),
                        CategoryId = Guid.NewGuid(),
                        SubCategoryId = Guid.NewGuid(),
                        HasVarient = i % 3 == 0 ? true : false,
                        IsFeatured = i % 4 == 0 ? true : false,
                        BaseCurrency = "SAR",
                        IsBannerFeatured = i % 2 == 0 ? true : false,

                    });
            }
        }

        [HttpGet(ApiRoutes.Product.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_products);
        }

        [HttpGet(ApiRoutes.Product.Get)]
        public IActionResult Get([FromRoute] Guid productId)
        {
            var product = _products.SingleOrDefault(p => p.Id == productId);

            if (product is null)
                return NotFound("Product Not Found.");

            return Ok(_products);
        }

        [HttpPost(ApiRoutes.Product.Create)]
        public IActionResult Create([FromBody] Product product)
        {
            _products.Add(product);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = baseUrl + "/" + ApiRoutes.Product.Get.Replace("{productId}", product.Id.ToString());

            return Created(locationUrl, product);
        }

        [HttpDelete(ApiRoutes.Product.Delete)]
        public IActionResult Delete([FromRoute] Guid productId)
        {
            var product = _products.Find(x => x.Id == productId);

            if (product is null)
                return NotFound("Product not found.");

            _products.Remove(product);

            return NoContent();

        }

        [HttpPut(ApiRoutes.Product.Update)]
        public IActionResult Delete([FromRoute] Guid productId , [FromBody] Product request)
        {
            var product = _products.Find(x => x.Id == productId);

            if (product is null)
                return NotFound("Product not found.");

            product.Name = request.Name;

            return Ok(product);

        }
    }
}
