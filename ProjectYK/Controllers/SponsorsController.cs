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
    public class SponsorsController : ControllerBase
    {
        DBClass db;
        public SponsorsController(DBClass context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sponsor>>> Get()
        {
            return await db.Sponsors.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sponsor>> Get(int id)
        {
            Sponsor sponsor = await db.Sponsors.FirstOrDefaultAsync(x => x.Id == id);
            if (sponsor == null)
                return NotFound();
            return new ObjectResult(sponsor);
        }

        [HttpPost]
        public async Task<ActionResult<Sponsor>> Post(Sponsor sponsor)
        {
            if (sponsor == null)
            {
                return BadRequest();
            }

            db.Sponsors.Add(sponsor);
            await db.SaveChangesAsync();
            return Ok(sponsor);
        }

        [HttpPut]
        public async Task<ActionResult<Sponsor>> Put(Sponsor sponsor)
        {
            if (sponsor == null)
            {
                return BadRequest();
            }
            if (!db.Sponsors.Any(x => x.Id == sponsor.Id))
            {
                return NotFound();
            }

            db.Update(sponsor);
            await db.SaveChangesAsync();
            return Ok(sponsor);
        }

        [HttpDelete]
        public async Task<ActionResult<Sponsor>> Delete(int id)
        {
            Sponsor sponsor = db.Sponsors.FirstOrDefault(x => x.Id == id);
            if (sponsor == null)
            {
                return NotFound();
            }
            db.Sponsors.Remove(sponsor);
            await db.SaveChangesAsync();
            return Ok(sponsor);
        }
    }
}
