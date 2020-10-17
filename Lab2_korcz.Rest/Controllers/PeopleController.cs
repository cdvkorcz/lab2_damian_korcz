using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2_korcz.Rest.Context;
using Lab2_korcz.Rest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Lab2_korcz.Rest.Controllers
{
    [ApiController]
    [Route("api/people")]
    public class PeopleController : ControllerBase
    {
        private readonly AzureDbContext db;

        public PeopleController(AzureDbContext db)
        {
            this.db = db;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(db.People.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var person = db.People.FirstOrDefault(w => w.PersonID == id);

            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Person person)
        {
            db.People.Add(person);
            db.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var people = db.People.First(f => f.PersonID == id);
            if (people == null)
            {
                return NotFound();
            }

            db.People.Remove(people);
            db.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, Person person)
        {
            var people = db.People.First(f => f.PersonID == id);

            people.FirstName = person.FirstName;
            people.LastName = person.LastName;
            db.SaveChanges();
            
            return NoContent();
        }


    }
}
