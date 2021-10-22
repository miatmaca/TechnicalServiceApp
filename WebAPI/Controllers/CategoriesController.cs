using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("add")]
        public IActionResult Add(Category category)
        {
            var result = _categoryService.Add(category);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("update")]
        public IActionResult Update(Category category)
        {
            var getCategory = _categoryService.GetCategory(category.CategoryName,category.OemId);
            if (getCategory != null)
            {
                getCategory.CategoryName = category.CategoryName;
                getCategory.Status = category.Status;
                getCategory.ModifiedBy = category.ModifiedBy;    
                var result = _categoryService.Update(getCategory);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);

            }
            else
            {
                return BadRequest("Değer Eşleşmiyor");
            }
            
               
            
           
        }
        [HttpPost("delete")]
        public IActionResult Delete(Category category)
        {
            var result = _categoryService.Delete(category);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getalloemıd")]
        public IActionResult GetAllOemId(int oemId)
        {
            var result = _categoryService.GetAllOemId(oemId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallbystatusone")]
        public IActionResult GetAllByStatusOne()
        {
            var result = _categoryService.GetAllByStatusOne();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
