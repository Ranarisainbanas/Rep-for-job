using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectYK.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjectYK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        DBClass db;
        public EventsController(DBClass context)
        {
            db = context;            
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> Get()
        {
            return await db.Events.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> Get(int id)
        {
            Event @event = await db.Events.FirstOrDefaultAsync(x => x.Id == id);
            if (@event == null)
                return NotFound();
            return new ObjectResult(@event);
        }

        [HttpPost]
        public async Task<ActionResult<Event>> Post(Event @event)
        {
            if (@event == null)
            {
                return BadRequest();
            }

            db.Events.Add(@event);
            await db.SaveChangesAsync();
            return Ok(@event);
        }

        [HttpPut]
        public async Task<ActionResult<Event>> Put(Event @event)
        {
            if (@event == null)
            {
                return BadRequest();
            }
            if (!db.Events.Any(x => x.Id == @event.Id))
            {
                return NotFound();
            }

            db.Update(@event);
            await db.SaveChangesAsync();
            return Ok(@event);
        }

        [HttpDelete]
        public async Task<ActionResult<Event>> Delete(int id)
        {
            Event @event = db.Events.FirstOrDefault(x => x.Id == id);
            if (@event == null)
            {
                return NotFound();
            }
            db.Events.Remove(@event);
            await db.SaveChangesAsync();
            return Ok(@event);
        }
    }
}
