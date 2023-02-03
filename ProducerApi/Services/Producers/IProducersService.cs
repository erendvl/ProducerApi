using ErrorOr;
using ProducerApi.Models;

namespace ProducerApi.Services.Producers;


public interface IProducerService
{
     ErrorOr<Created>CreateProducer(Producer producer);
    ErrorOr<Deleted> DeleteProducer(Guid id);
    ErrorOr<Producer> GetProducer(Guid id);
    ErrorOr<UpsertedProducerResult> UpserBreakfast(Producer producer);
}