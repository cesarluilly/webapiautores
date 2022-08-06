using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entidades;

namespace WebApiAutores.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public AutoresController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Autor>>> Get()
        {
            //                                              //Como vamos a comunicarnos con una
            //                                              //  una DB la buena practica es usar
            //                                              //  programacion asincrona.
            return await _context.Autores.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Autor autor)
        {
            _context.Add(autor);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")] // api/autores
        public async Task<ActionResult> put(Autor autor, int id)
        {
            if (
                autor.Id != id
                )
            {
                return BadRequest("El id del autor no coincide con el ID de la URL");
            }

            var existe = await _context.Autores.AnyAsync(x => x.Id == id);

            if (
                !existe
                )
            {
                return NotFound();
            }

            _context.Update(autor);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")] //api/autores/2
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Autores.AnyAsync(x => x.Id == id);

            if(
                !existe
                )
            {
                return NotFound();
            }

            _context.Remove(new Autor() { Id = id});
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
