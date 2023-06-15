using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace PlatformService.Api.Attributes;

public class ValidateModelAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState.Where(x => x.Value.Errors.Count > 0)
                                           .ToDictionary(x => x.Key, x => x.Value.Errors.Select(y => y.ErrorMessage))
                                           .ToArray();

            context.Result = new BadRequestObjectResult(errors);
        }
    }
}
