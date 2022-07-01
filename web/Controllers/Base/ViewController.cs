using Microsoft.AspNetCore.Mvc;

namespace MVCWebApplication.Controllers.Base;

public class ViewController : Controller
{
    public bool IsView()
    {
        return Request.Headers["Accept"].ToString().Contains("text/html");
    }

    public IActionResult View(Func<IActionResult> func)
    {
        if (IsView())
        {
            return View();
        }

        return func();
    }

    public IActionResult View(Func<object?, IActionResult> func, object? model)
    {
        if (IsView())
        {
            return View(model);
        }

        return func(model);

    }

    public IActionResult View(Func<string, IActionResult> func, string message)
    {
        if (IsView())
        {
            return View();
        }

        return func(message);

    }
    public IActionResult View(Func<Dictionary<string, string>, IActionResult> func, Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary modelState)
    {
        if (IsView())
        {
            return View();
        }

        var errors = new Dictionary<string, string>();
        foreach (var item in modelState)
        {
            if (item.Value.Errors.Count == 0)
            {
                continue;
            }

            errors.Add(item.Key.ToString(), "");
            foreach (var error in item.Value.Errors)
            {
                errors[$"{item.Key.ToString()}"] += error.ErrorMessage;
            }
        }
        return func(errors);

    }
}
