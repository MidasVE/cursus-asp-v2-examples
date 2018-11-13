using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Csharp_Validation.Models;
using Csharp_Validation.DataContext;
using System;

namespace Csharp_Validation.Controllers
{
  public class KittenController : Controller
  {
    private KittenDbContext _context;

    public KittenController(KittenDbContext context)
    {
      _context = context;
    }

    public IActionResult Index()
    {
      var model = new KittenLitter();
      model.Kittens = _context.Kittens.ToList();
      return View(model);
    }

    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(
        [Bind("Id,Name,NiceScale,DateOfBirth")] Kitten kitten)
    {
      if (ModelState.IsValid && KittenIsUnique(kitten))
      {
        _context.Kittens.Add(kitten);
        _context.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(kitten);
    }

    private bool KittenIsUnique(Kitten kitten)
    {
      var existingKittenWithSameName = _context.Kittens.Any(x => x.Name == kitten.Name);
      if (existingKittenWithSameName)
      {
        ModelState.AddModelError("NON_UNIQUE_KITTEN", "Geef je kittens aub unieke namen, ze lijken al zo hard op elkaar.");
        return false;
      }
      return true;
    }
  }
}
