using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using ProducerApi.Contracts.ProducerApi;
using ProducerApi.Models;
using ProducerApi.ServiceErrors;
using ProducerApi.Services.Producers;

namespace ProducerApi.Controllers;



public class ProducerController:ApiController
{
private readonly IProducerService _producerService;
public ProducerController(IProducerService producerService)
{
    _producerService=producerService;
}

[HttpPost]
public IActionResult CreateProducer(CreateProducerRequest request)
{
    ErrorOr<Producer> requestProducerResult= Producer.Create(
        request.PicUrl,
        request.Name,
        request.Description,
        request.Movies
 

    );

    if(requestProducerResult.IsError)
    {
        Problem(requestProducerResult.Errors);
    }

    var producer=requestProducerResult.Value;
  ErrorOr<Created>createProducerResult =_producerService.CreateProducer(producer);

    

  return createProducerResult.Match(
    created=>CreatedAsGetProducer(producer),
    errors=>Problem(errors)

  );
}
   
  

[HttpGet("{id:guid}")]
public IActionResult GetProducer(Guid id)
{
    ErrorOr<Producer> getProducerResult=_producerService.GetProducer(id);

     return getProducerResult.Match(
        producer=>Ok(MapProducerResponse(producer)),
        errors=> Problem(errors)
     );

   
}



    [HttpPut("{id:guid]")]
public IActionResult UpsertProducer(Guid id,UpsertProducerRequest request)
{
    
    ErrorOr<Producer> requestProducerResult=Producer.Create(
        request.PicUrl,
        request.Name,
        request.Description,
        request.Movies,
        id
    );
    if(requestProducerResult.IsError)
    {
        return Problem(requestProducerResult.Errors);
    }
    var producer=requestProducerResult.Value;


    ErrorOr<UpsertedProducerResult> upsertProducerResult=_producerService.UpserBreakfast(producer);

    return upsertProducerResult.Match(
        upserted=>upserted.isNewlyCreated? CreatedAsGetProducer(producer):NoContent(),
        error=>Problem(error)
    );
}

[HttpPut("{id:guid]")]
public IActionResult DeleteProducer(Guid id)
{
   ErrorOr<Deleted>deletedProducerResult = _producerService.DeleteProducer(id);

   return deletedProducerResult.Match(
    deleted=>NoContent(),
    errors=>Problem(errors)
   );
}


    private ProducerResponse MapProducerResponse(Producer producer)
    {
       return  new ProducerResponse(
        producer.Id,
        producer.PicUrl,
        producer.Name,
        producer.Description,
        producer.Movies,
        producer.LastModifiedDateTime);
    
    }
 private CreatedAtActionResult CreatedAsGetProducer(Producer producer)
   {
    return CreatedAtAction(
        actionName:nameof(GetProducer),
        routeValues: new{id=producer.Id},
        value:MapProducerResponse(producer)
        
    );
   }
}
