using System.Security.Authentication;
using api.TransferModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace api.Filters;

public class ValidateModel : ActionFilterAttribute
{
    
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        
    
        if (context.HttpContext.GetSessionData() == null) throw new AuthenticationException();
    
        if (context.ModelState.IsValid)
            return;
        var errorMessages = context.ModelState
            .Values
            .SelectMany(i => i.Errors.Select(e => e.ErrorMessage))
            .Aggregate((i, j) => i + "," + j);
        context.Result = new JsonResult(new ResponseDto
        {
            MessageToClient = errorMessages
        })
        {
            StatusCode = 400
        };
    }
}