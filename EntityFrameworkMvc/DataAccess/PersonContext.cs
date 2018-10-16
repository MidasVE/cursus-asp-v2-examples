using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EntityFrameworkMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkMvc.DataAccess
{
  public class PersonContext : DbContext
  {
    public PersonContext(DbContextOptions<PersonContext> config) : base(config)
    {

    }

    public DbSet<Person> Persons { get; internal set; }
  }

  public class Person
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }
}