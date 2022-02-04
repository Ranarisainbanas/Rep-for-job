using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectYK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectYK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        DBClass db;
        public TypesController(DBClass context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeOfEvent>>> Get()
        {
            return await db.typeOfEvents.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TypeOfEvent>> Get(int id)
        {
            TypeOfEvent type = await db.typeOfEvents.FirstOrDefaultAsync(x => x.Id == id);
            if (type == null)
                return NotFound();
            return new ObjectResult(type);
        }

        [HttpPost]
        public async Task<ActionResult<TypeOfEvent>> Post(TypeOfEvent type)
        {
            if (type == null)
            {
                return BadRequest();
            }

            db.typeOfEvents.Add(type);
            await db.SaveChangesAsync();
            return Ok(type);
        }

        [HttpPut]
        public async Task<ActionResult<TypeOfEvent>> Put(TypeOfEvent type)
        {
            if (type == null)
            {
                return BadRequest();
            }
            if (!db.typeOfEvents.Any(x => x.Id == type.Id))
            {
                return NotFound();
            }

            db.Update(type);
            await db.SaveChangesAsync();
            return Ok(type);
        }

        [HttpDelete]
        public async Task<ActionResult<TypeOfEvent>> Delete(int id)
        {
            TypeOfEvent type = db.typeOfEvents.FirstOrDefault(x => x.Id == id);
            if (type == null)
            {
                return NotFound();
            }
            db.typeOfEvents.Remove(type);
            await db.SaveChangesAsync();
            return Ok(type);
        }
    }
}
