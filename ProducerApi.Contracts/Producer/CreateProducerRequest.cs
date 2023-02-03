namespace ProducerApi.Contracts.ProducerApi;


public record CreateProducerRequest(
      
         string PicUrl,
         string Name ,
         string Description,
         List<string> Movies

);