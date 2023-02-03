using Microsoft.AspNetCore.Mvc;
using ProducerApi.Contracts.ProducerApi;
using ProducerApi.Models;

namespace ProducerApi.Controllers;

[ApiController]
[Route("[controller]")]

public class ProducerController:ControllerBase
{

[HttpPost()]
public IActionResult CreateProducer(CreateProducerRequest request)
{
    var Producer= new Producer(
        Guid.NewGuid(),
        request.PicUrl,
        request.Name,
        request.Description,
        request.Movies,
        DateTime.UtcNow
        
        

    );

    var response=new ProducerResponse(
        Producer.Id,
        Producer.PicUrl,
        Producer.Name,
        Producer.Description,
        Producer.Movies,
        Producer.LastModifiedDateTime
    );


    return CreatedAtAction(
        actionName:nameof(GetProducer),
        routeValues: new{id=Producer.Id},
        value:response
        
    );
}


[HttpGet("{id:guid}")]
public IActionResult GetProducer(Guid id)
{
    return Ok(id);
}

[HttpPut("{id:guid]")]
public IActionResult UpsertProducer(Guid id,UpsertProducerRequest request)
{
    return Ok(request);
}

[HttpPut("{id:guid]")]
public IActionResult DeleteProducer(Guid id)
{
    return Ok(id);
}
}