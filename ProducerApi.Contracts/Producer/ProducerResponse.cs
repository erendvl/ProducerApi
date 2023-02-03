namespace ProducerApi.Contracts.ProducerApi;


public record ProducerResponse(
      
        
         Guid Id,
          string PicUrl,
         string Name ,
         string Description,
         List<string> Movies,
         DateTime LastModifiedDateTime

);