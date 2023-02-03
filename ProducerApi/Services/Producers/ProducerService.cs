using ProducerApi.Models;

namespace ProducerApi.Services.Producers;

public class ProdcerService:IProducerService
{

    private readonly static  Dictionary<Guid,Producer>_producers=new();
    public void CreateProducer(Producer producer)
    {
       _producers.Add(producer.Id,producer);
    }

    public void DeleteProducer(Guid id)
    {
        _producers.Remove(id);
    }

    public Producer GetProducer(Guid id)
    {
        return _producers[id];
    }

   
    public void UpserBreakfast(Producer producer)
    {
        _producers[producer.Id]=producer;
    }
}