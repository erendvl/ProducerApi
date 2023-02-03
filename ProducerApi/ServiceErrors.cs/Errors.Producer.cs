using ErrorOr;

namespace ProducerApi.ServiceErrors;

public static class Errors{
    public static class Producer{

        public static Error NotFound=> Error.NotFound(
            code:"Breakfast.NotFound",
            description:"Breafast Not Found"
        );
         public static Error InValidName=> Error.Validation(
            code:"Breakfast.NotFound",
            description:"You should input a name between 3 and 50 characters"
        );
         public static Error InValidDescription=> Error.Validation(
            code:"Breakfast.NotFound",
            description:"You should input a description between 50 and 200 characters"
        );


    }
}