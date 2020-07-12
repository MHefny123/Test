using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly HefnyDBContext context;
        public ProductController(HefnyDBContext context)
        {
            this.context = context;

            if (context.Product.Count() == 0)
            {
                context.Product.Add(new Product { Id = 0, ProdDesc = "desc", ProdName = "defualt Name", ProdPrice = 0, UpdatedAt = DateTime.Now.Date });
                context.SaveChanges();

            }

        }

        // GET: api/Product All
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return await context.Product.ToListAsync();
        }


        // GET: api/Product By ID

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int ID)
        {
            var Product = await context.Product.FindAsync(ID);
            if (Product == null)
            {
                return NotFound();
            }
            return Product;
        }


        // POST: api/Todo
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product Product)
        {
            context.Product.Add(Product);
            await context.SaveChangesAsync();

            // return CreatedAtAction("GetProduct", new { ID = Product.Id }, Product);
            return CreatedAtAction("GetProduct", new { ID = Product.Id });
        }


        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product Product)
        {

            Product.Id = id;
            Product.UpdatedAt = DateTime.Now.Date;
            if (id != Product.Id)
            {
                return BadRequest();
            }

            context.Entry(Product).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }


        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var Product = await context.Product.FindAsync(id);
            if (Product == null)
            {
                return NotFound();
            }

            context.Product.Remove(Product);
            await context.SaveChangesAsync();

            return Product;
        }

    }

}