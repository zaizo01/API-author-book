using API01.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API01.Controllers
{
    [ApiController]
    [Route("api/autores")]
    public class AutorControlller: ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AutorControlller(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Autor>>> Get()
        {
            return await context.Autores.Include(x => x.Libros).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Autor autor)
        {
            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Autor autor, int id)
        {
            if(autor.id != id)
            {
                return BadRequest("This is not exist");
            }
            context.Update(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var hasUser = await context.Autores.AnyAsync(x => x.id == id);

            if (!hasUser)
            {
                return NotFound();
            }

            context.Remove(new Autor { id = id });
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
