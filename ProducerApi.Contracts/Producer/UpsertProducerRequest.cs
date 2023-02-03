
namespace ProducerApi.Contracts.ProducerApi;


public record UpsertProducerRequest(
      
          string PicUrl,
         string Name ,
         string Description,
         List<string> Movies

);