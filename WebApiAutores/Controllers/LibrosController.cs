using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entidades;

namespace WebApiAutores.Controllers
{
    [ApiController]
    [Route("api/libros")]
    public class LibrosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public LibrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Libro>> Get(int id)
        {
            //                                  //Lo que hacemos es que voy a consultar a un libro,
            //                                  //  pero tambien quiero que me traiga informacion
            //                                  //  del autor.
            return await _context.Libros
                .Include(x => x.Autor).FirstOrDefaultAsync(x => x.id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Libro libro)
        {
            var existeAutor = await _context.Autores.AnyAsync(x => x.Id == libro.AutorId);

            if (
                !existeAutor
                )
            {
                return BadRequest($"No existe el autor de Id:{libro.AutorId}");
            }

            _context.Add(libro);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
