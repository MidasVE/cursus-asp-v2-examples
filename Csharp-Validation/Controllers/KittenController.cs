using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Csharp_Validation.Models;
using Csharp_Validation.DataContext;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

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
      var vm = new KittenCreateViewModel();
      AddOtherKittensToViewModel(vm);
      return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(KittenCreateViewModel vm)
    {
      var kitten = vm.Kitten;
      var mother = GetMother(vm);
      if (ModelState.IsValid
        && KittenIsUnique(kitten)
        && CheckMother(mother))
      {
        kitten.Mother = mother;
        _context.Kittens.Add(kitten);
        _context.SaveChanges();
        return RedirectToAction("Index");
      }
      AddOtherKittensToViewModel(vm);
      return View(vm);
    }

    private Kitten GetMother(KittenCreateViewModel vm)
    {
      int.TryParse(vm.SelectedMother, out var motherId);
      var mother = _context.Kittens.Find(motherId);
      return mother;
    }

    private bool CheckMother(Kitten mother)
    {
      if (mother == null)
      {
        ModelState.AddModelError("Mother", "Onbekende moeder");
        return false;
      }
      if (mother.DateOfBirth > DateTime.Now.AddYears(-1))
      {
        ModelState.AddModelError("Mother", "Moeder moest minstens 1 jaar oud zijn.");
        return false;
      }
      return true;
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

    private void AddOtherKittensToViewModel(KittenCreateViewModel vm)
    {
      vm.OtherKittens = _context.Kittens
        .Where(x => !x.IsMale)
        .Select(x => new SelectListItem
        {
          Value = $"{x.Id}",
          Text = x.Name
        })
        .ToList();
    }
  }
}
