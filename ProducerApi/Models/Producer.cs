using System.Collections.Generic;
using ErrorOr;
using ProducerApi.ServiceErrors;

namespace ProducerApi.Models;

public class Producer
    {
        public const int MinNameLength=3;
        public const int MaxNameLength=50;

         public const int MinDescriptionLength=50;
        public const int MaxDescriptionLength=200;
        

        public Guid Id { get;  }

        public string PicUrl { get; }
        public string Name { get;  }
        public string Description { get ;}
        public List<string>Movies { get; }

        public DateTime LastModifiedDateTime{get;}


    private Producer(Guid id,string picUrl,string name,string description, List<string>movies,DateTime lastModifiedDateTime)
    {
       
        Id=id;
        PicUrl=picUrl;
        Name=name;
        Description=description;
        Movies=movies;
        lastModifiedDateTime=LastModifiedDateTime;
        
    }

    public static ErrorOr<Producer> Create(
        string picUrl,
         string name ,
         string description ,
         List<string>movies,
         Guid? id=null
    )
    {
        List<Error> errors=new();

        if(name.Length<MinNameLength||name.Length>MaxNameLength)
        {
            errors.Add(Errors.Producer.InValidName);

        }
         if(description.Length<MinDescriptionLength||description.Length>MaxDescriptionLength)
        {
            errors.Add(Errors.Producer.InValidDescription);

        }
        if(errors.Count>0)
        {
            return errors; 
        }

    var producer=new Producer(
        id ?? Guid.NewGuid(),
        picUrl,
        name,
        description,
        movies,
        DateTime.UtcNow
    );
  
        return producer;
    }

    }
