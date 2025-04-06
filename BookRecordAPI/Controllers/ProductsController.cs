﻿//using Microsoft.AspNetCore.Mvc;
//using BookRecordAPI.Data;
//using BookRecordAPI.Models;
//using Microsoft.EntityFrameworkCore;

//namespace BookRecordAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProductsController : ControllerBase
//    {
//        private readonly ApplicationDbContext _context;

//        public ProductsController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // GET: api/products
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
//        {
//            return await _context.Products.ToListAsync();
//        }

//        // GET: api/products/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Product>> GetProduct(int id)
//        {
//            var product = await _context.Products.FindAsync(id);

//            if (product == null)
//                return NotFound();

//            return product;
//        }

//        // POST: api/products
//        [HttpPost]
//        public async Task<ActionResult<Product>> CreateProduct(Product product)
//        {
//            _context.Products.Add(product);
//            await _context.SaveChangesAsync();
//            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);
//        }

//        // PUT: api/products/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateProduct(int id, Product product)
//        {
//            if (id != product.ProductId)
//                return BadRequest();

//            _context.Entry(product).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!_context.Products.Any(e => e.ProductId == id))
//                    return NotFound();
//                throw;
//            }

//            return NoContent();
//        }

//        // DELETE: api/products/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteProduct(int id)
//        {
//            var product = await _context.Products.FindAsync(id);
//            if (product == null)
//                return NotFound();

//            _context.Products.Remove(product);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }
//    }
//}
