using ErrorOr;
using ProducerApi.Models;
using ProducerApi.ServiceErrors;

namespace ProducerApi.Services.Producers;

public class ProdcerService:IProducerService
{

    private readonly static  Dictionary<Guid,Producer>_producers=new();
    public ErrorOr<Created> CreateProducer(Producer producer)
    {
       _producers.Add(producer.Id,producer);
       return Result.Created;
    }

    public ErrorOr<Deleted> DeleteProducer(Guid id)
    {
        _producers.Remove(id);
        return Result.Deleted;
    }

    public ErrorOr<Producer> GetProducer(Guid id)
    {
        if(_producers.TryGetValue(id,out var producer))
        {
            return producer;
        }
        return Errors.Producer.NotFound;
    }

   
    public ErrorOr<UpsertedProducerResult> UpserBreakfast(Producer producer)
    {
       var isNewlyCreated=!_producers.ContainsKey(producer.Id);
       _producers[producer.Id]=producer;
        return new UpsertedProducerResult(isNewlyCreated);
    }
}