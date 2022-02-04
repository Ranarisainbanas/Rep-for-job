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
    public class PlacesController : ControllerBase
    {
        DBClass db;
        public PlacesController(DBClass context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Place>>> Get()
        {
            return await db.Places.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Place>> Get(int id)
        {
            Place place = await db.Places.FirstOrDefaultAsync(x => x.Id == id);
            if (place == null)
                return NotFound();
            return new ObjectResult(place);
        }

        [HttpPost]
        public async Task<ActionResult<Place>> Post(Place place)
        {
            if (place == null)
            {
                return BadRequest();
            }

            db.Places.Add(place);
            await db.SaveChangesAsync();
            return Ok(place);
        }

        [HttpPut]
        public async Task<ActionResult<Place>> Put(Place place)
        {
            if (place == null)
            {
                return BadRequest();
            }
            if (!db.Places.Any(x => x.Id == place.Id))
            {
                return NotFound();
            }

            db.Update(place);
            await db.SaveChangesAsync();
            return Ok(place);
        }

        [HttpDelete]
        public async Task<ActionResult<Place>> Delete(int id)
        {
            Place place = db.Places.FirstOrDefault(x => x.Id == id);
            if (place == null)
            {
                return NotFound();
            }
            db.Places.Remove(place);
            await db.SaveChangesAsync();
            return Ok(place);
        }
    }
}
