using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EntityFrameworkMvc.DataAccess;

namespace EntityFrameworkMvc.Controllers
{
  [Route("api/home")]
  public class HomeController : Controller
  {
    private PersonContext _personContext;

    public HomeController(PersonContext personContext)
    {
      _personContext = personContext;
    }

    [Route("persons")]
    [HttpGet()]
    public IActionResult GetPersonAsJson()
    {
      var persons = _personContext.Persons.ToList();
      return Ok(persons);
    }

    [Route("persons/add/random")]
    [HttpPost]
    public IActionResult AddRandomPerson()
    {
      var person = new Person { Name = $"{Guid.NewGuid()}" };
      _personContext.Persons.Add(person);
      _personContext.SaveChanges();
      return new CreatedResult(string.Empty, person);
    }

    [Route("persons/{id}")]
    [HttpDelete]
    public IActionResult RemovePerson([FromRoute]int id)
    {
      _personContext.Remove(_personContext.Persons.Find(id));
      _personContext.SaveChanges();
      return NoContent();
    }

    [Route("persons/{id}")]
    [HttpGet]
    public IActionResult GetSinglePerson([FromRoute]int id)
    {
      ;
      return Ok(_personContext.Persons.Find(id));
    }
  }
}
