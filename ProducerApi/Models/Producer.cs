namespace ProducerApi.Models;

public class Producer
    {
        public Guid Id { get;  }

        public string PicUrl { get; }
        public string Name { get;  }
        public string Description { get ;}
        public List<string>Movies { get; }

        public DateTime LastModifiedDateTime{get;}


    public Producer(Guid id,string picUrl,string name,string description,List<string>movies,DateTime lastModifiedDateTime)
    {
       
        Id=id;
        PicUrl=picUrl;
        Name=name;
        Description=description;
        Movies=movies;
        lastModifiedDateTime=LastModifiedDateTime;
        
    }

    }
