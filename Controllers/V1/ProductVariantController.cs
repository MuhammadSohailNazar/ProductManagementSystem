using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.Contracts.V1;
using ProductManagementSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagementSystem.Controllers.V1
{
    public class ProductVariantController : Controller
    {
        private List<ProductVariant> _productVariant;
        public ProductVariantController()
        {
            _productVariant = new List<ProductVariant>();
            for (int i = 1; i < 10; i++)
            {
                _productVariant.Add(
                    new ProductVariant
                    {
                        Id = Guid.NewGuid(),
                        Name = $"Product Variant {i}",
                        IsActive = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        IsDeleted = false,
                        BaseCurrency = "SAR",
                        ProductId = Guid.NewGuid(),
                        HasImages = false,
                        Price = 130,
                        StockAvailable = 200,
                        StockNotificationLimit = 40,
                        VariantCode = "FWERFDd22",
                        TrackStockQuantity = false,
                        SoldQuantity = 0,
                        IsDimensionAvailable = true,
                        ThresholdLimit = 30,

                    });
            }
        }

        [HttpGet(ApiRoutes.ProductVariant.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_productVariant);
        }

        [HttpGet(ApiRoutes.ProductVariant.Get)]
        public IActionResult Get([FromRoute] Guid productVariantId)
        {
            var productVariant = _productVariant.SingleOrDefault(p => p.Id == productVariantId);

            if (productVariant is null)
                return NotFound("Product Variant Not Found.");

            return Ok(productVariant);
        }

        [HttpPost(ApiRoutes.ProductVariant.Create)]
        public IActionResult Create([FromBody] ProductVariant productVariant)
        {
            _productVariant.Add(productVariant);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = baseUrl + "/" + ApiRoutes.ProductVariant.Get.Replace("{productVariantId}", productVariant.Id.ToString());

            return Created(locationUrl, productVariant);
        }

        [HttpDelete(ApiRoutes.ProductVariant.Delete)]
        public IActionResult Delete([FromRoute] Guid productVariantId)
        {
            var product = _productVariant.Find(x => x.Id == productVariantId);

            if (product is null)
                return NotFound("Product Variant not found.");

            _productVariant.Remove(product);

            return NoContent();

        }

        [HttpPut(ApiRoutes.ProductVariant.Update)]
        public IActionResult Delete([FromRoute] Guid productVariantId, [FromBody] ProductVariant request)
        {
            var productVariant = _productVariant.Find(x => x.Id == productVariantId);

            if (productVariant is null)
                return NotFound("Product VariantId not found.");

            productVariant.Name = request.Name;

            return Ok(productVariant);

        }
    }
}
