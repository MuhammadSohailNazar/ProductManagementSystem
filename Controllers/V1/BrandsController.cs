using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.Contracts.V1;
using ProductManagementSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagementSystem.Controllers.V1
{
    public class BrandsController : Controller
    {
        private List<Brand> _brand;
        public BrandsController()
        {
            _brand = new List<Brand>();
            for (int i = 1; i < 10; i++)
            {
                _brand.Add(
                    new Brand
                    {
                        Id = Guid.NewGuid(),
                        Code = Guid.NewGuid().ToString(),
                        Name = $"Brand {i}",
                        IsActive = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        IsDeleted = false,

                    });
            }
        }

        [HttpGet(ApiRoutes.Brand.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_brand);
        }

        [HttpGet(ApiRoutes.Brand.Get)]
        public IActionResult Get([FromRoute] Guid brandId)
        {
            var brand = _brand.SingleOrDefault(p => p.Id == brandId);

            if (brand is null)
                return NotFound("Brand Not Found.");

            return Ok(brand);
        }

        [HttpPost(ApiRoutes.Brand.Create)]
        public IActionResult Create([FromBody] Brand brand)
        {
            _brand.Add(brand);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = baseUrl + "/" + ApiRoutes.Brand.Get.Replace("{brandId}", brand.Id.ToString());

            return Created(locationUrl, brand);
        }

        [HttpDelete(ApiRoutes.Brand.Delete)]
        public IActionResult Delete([FromRoute] Guid brandId)
        {
            var barnd = _brand.Find(x => x.Id == brandId);

            if (barnd is null)
                return NotFound("Brand not found.");

            _brand.Remove(barnd);

            return NoContent();

        }

        [HttpPut(ApiRoutes.Brand.Update)]
        public IActionResult Delete([FromRoute] Guid brandId, [FromBody] Brand request)
        {
            var brand = _brand.Find(x => x.Id == brandId);

            if (brand is null)
                return NotFound("Brand not found.");

            brand.Name = request.Name;

            return Ok(brand);

        }
    }
}
