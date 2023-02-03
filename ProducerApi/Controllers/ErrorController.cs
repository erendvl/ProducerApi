using Microsoft.AspNetCore.Mvc;

namespace ProducerApi.Controllers;

public class ErrorController:Controller
{
    [Route("/error")]

    public IActionResult Error()
    {
        return Problem();
    }
}

