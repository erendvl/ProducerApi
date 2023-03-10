using ProducerApi.Services.Producers;

var builder = WebApplication.CreateBuilder(args);
 {

 builder.Services.AddControllers(); 
 builder.Services.AddScoped<IProducerService,ProdcerService>();

 }

var app = builder.Build();
{
      app.UseExceptionHandler("/error");
      app.UseHttpsRedirection();
      app.MapControllers();
      app.Run();
}