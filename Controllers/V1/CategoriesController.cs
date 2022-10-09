using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.Contracts.V1;
using ProductManagementSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagementSystem.Controllers.V1
{
    public class CategoriesController : Controller
    {
        private List<Category> _category;
        public CategoriesController()
        {
            _category = new List<Category>();
            for (int i = 1; i < 10; i++)
            {
                _category.Add(
                    new Category
                    {
                        Id = Guid.NewGuid(),
                        Name = Guid.NewGuid().ToString(),
                        Description = $"Category {i} description",
                        IsActive = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        IsDeleted = false,
                        ParentId = Guid.NewGuid(),
                        ParentCategoryId = Guid.NewGuid()

                    });
            }
        }

        [HttpGet(ApiRoutes.Category.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_category);
        }

        [HttpGet(ApiRoutes.Category.Get)]
        public IActionResult Get([FromRoute] Guid categoryId)
        {
            var category = _category.SingleOrDefault(p => p.Id == categoryId);

            if (category is null)
                return NotFound("Category Not Found.");

            return Ok(category);
        }

        [HttpPost(ApiRoutes.Category.Create)]
        public IActionResult Create([FromBody] Category category)
        {
            _category.Add(category);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = baseUrl + "/" + ApiRoutes.Category.Get.Replace("{categoryId}", category.Id.ToString());

            return Created(locationUrl, category);
        }

        [HttpDelete(ApiRoutes.Category.Delete)]
        public IActionResult Delete([FromRoute] Guid categoryId)
        {
            var category = _category.Find(x => x.Id == categoryId);

            if (category is null)
                return NotFound("Category not found.");

            _category.Remove(category);

            return NoContent();

        }

        [HttpPut(ApiRoutes.Category.Update)]
        public IActionResult Delete([FromRoute] Guid categoryId, [FromBody] Category request)
        {
            var category = _category.Find(x => x.Id == categoryId);

            if (category is null)
                return NotFound("Category not found.");

            category.Name = request.Name;

            return Ok(category);

        }
    }
}
