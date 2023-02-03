using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ProducerApi.Controllers;

[ApiController]
[Route("[controller]")]

public class ApiController:ControllerBase
{


   protected IActionResult Problem(List<Error>errors)
   {

       if(errors.All(e=> e.Type==ErrorType.Validation))
       {
        var modelStateDictionaru=new ModelStateDictionary();

        foreach(var error in errors)
        {
            modelStateDictionaru.AddModelError(error.Code,error.Description);
        }

              return ValidationProblem(modelStateDictionaru);
        }


        if(errors.Any(e=>e.Type==ErrorType.Unexpected))
        {

            return Problem();

        }



       var firsterror=errors[0];

       var statuscode=firsterror.Type switch
       {
        ErrorType.NotFound=>StatusCodes.Status404NotFound,
        ErrorType.Conflict=>StatusCodes.Status409Conflict,
        ErrorType.Validation=>StatusCodes.Status400BadRequest,
        _=>StatusCodes.Status500InternalServerError
       };

       return Problem(statusCode: statuscode,title: firsterror.Description );
   }
}