using DatabaseContext.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Modelos.Inventories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaErpAPI.Controllers.Inventories
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ContextConfig _db;
        public CategoriesController(ContextConfig db)
        {
           _db = db;
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<ActionResult> GetCategories()
        {
            return Ok(await _db.Categories.ToListAsync());
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategory(Guid id)
        {
            try
            {
                var Category = await _db.Categories.FindAsync(id);
                if (Category == null)
                    return BadRequest(new { message = "Categoria não cadastrado" });
                return Ok(Category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<ActionResult> PostCategory([FromBody] Category category)
        {
            try
            {
                await _db.Categories.AddAsync(category);
                _db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutCategory(Guid id, [FromBody] Category category)
        {
            try
            {
                var categoryFinded = await _db.Categories.FindAsync(id);
                if (categoryFinded == null)
                    return BadRequest(new { message = "Categoria não cadastrado" });

                categoryFinded.Description = category.Description;

                _db.Categories.Update(categoryFinded);
                await _db.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            var Category = await _db.Categories.FindAsync(id);
            if (Category == null)
                return BadRequest(new { message = "Categoria não cadastrado" });
            _db.Remove(Category);
            await _db.SaveChangesAsync();
            return Ok(Category);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut]
        public async Task<ActionResult> AbleDisableCategory([FromBody] Guid id)
        {
            try
            {
                var categoryFinded = await _db.Categories.FindAsync(id);
                if (categoryFinded == null)
                    return BadRequest(new { message = "Categoria não cadastrado" });

                categoryFinded.Able = !categoryFinded.Able;

                _db.Categories.Update(categoryFinded);
                await _db.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
