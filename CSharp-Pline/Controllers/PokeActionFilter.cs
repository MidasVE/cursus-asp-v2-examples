using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

namespace CSharp_Pline.Controllers
{
  public class PokeActionFilter : ActionFilterAttribute
  {
    public override void OnActionExecuting(ActionExecutingContext context)
    {
      System.Console.WriteLine($"TEST 123 {context.Controller.GetType().Name} - {context.ActionDescriptor.DisplayName}");
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
      System.Console.WriteLine($"TEST 456 {context.Controller.GetType().Name} - {context.ActionDescriptor.DisplayName}");
    }
  }
}
