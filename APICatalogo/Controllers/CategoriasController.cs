using APICatalogo.Data;
using APICatalogo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly APICatalogContext _context;

        public CategoriasController(APICatalogContext context) { 
            _context = context;
        }

        //Get
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategoria() {
        
            return await _context.Categoria.ToListAsync();
        }

        //Post 
        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria) { 
            _context.Categoria.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoria", new { id = categoria.CategoriaId }, categoria);
        }



        //Put
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool CategoriaExists(int id)
        {
            return _context.Categoria.Any(e => e.CategoriaId == id);
        }


        
        //Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarCategoria(int id) {

            var categoria = await _context.Categoria.FindAsync(id);
           
            if (categoria ==null)
                return NotFound();


            _context.Categoria.Remove(categoria);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }
      
    }
}
