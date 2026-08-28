using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyRecipeBook.Communication.ExceptionsBase;
using MyRecipeBook.Communication.Response;
using MyRecipeBook.Exception;
using System.Net;

namespace MyRecipeBook.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
       if(context.Exception is ErrorOnValidationException errorOnvalidationException)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

            
            context.Result = new BadRequestObjectResult(new ResponseErrorJson(errorOnvalidationException.GetErrorMessages()));
        }
        else
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;


            context.Result = new ObjectResult(new ResponseErrorJson(ResourceMessagesException.UNKNOW_ERROR));
        }
    }
}
