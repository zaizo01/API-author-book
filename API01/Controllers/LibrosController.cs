﻿using API01.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API01.Controllers
{
    [ApiController]
    [Route("api/libros")]
    public class LibrosController: ControllerBase
    {
        private readonly ApplicationDbContext context;

        public LibrosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Libro>> Get(int id)
        {
            return await context.Libros.Include(x => x.Autor).FirstOrDefaultAsync(x => x.id == id);

        }

        [HttpPost]
        public async Task<ActionResult> Post(Libro libro)
        {
            var hasAutor = await context.Autores.AnyAsync(x => x.id == libro.AutorId);

            if (!hasAutor)
            {
                return BadRequest($"No exite el autor de id: {libro.AutorId}");
            }

            context.Add(libro);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
