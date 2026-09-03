using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using MyRecipeBook.Api.Filters;
using MyRecipeBook.Application;
using MyRecipeBook.Infrastructure;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new MyRecipeBook.Api.Converters.StringConverter());
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(); //1 fiz manualmente esta adição.

//MyRecipeBook.Infrastructure.DependencyInjectionExtension.AddInfrastructureServices(builder.Services);
//MyRecipeBook.Application.DependencyInjectionExtension.AddApplicationServices(builder.Services);
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    //Aqui você pode configurar as opções de localização, como idiomas suportados, cultura padrão, etc.

    var supportedCultures = new List<CultureInfo> { new ("en"), new CultureInfo("pt-BR"), new ("es") };

    options.DefaultRequestCulture = new RequestCulture("en");

    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;

    options.RequestCultureProviders = new List<IRequestCultureProvider>
    {
        new AcceptLanguageHeaderRequestCultureProvider()
    };

});
builder.Services.AddMvc(options =>
{
    options.Filters.Add<ExceptionFilter>();
});

builder.Services.AddRouting(options => options.LowercaseUrls = true); // Configura o roteamento para usar URLs em letras minúsculas.
var app = builder.Build();

//vamos falar pra api que ela vai usar a localização configurada acima.
var localizationOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>();

app.UseRequestLocalization(localizationOptions.Value);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger(); //2 fiz manualmente esta adição.
    app.UseSwaggerUI(); //3 conclusão da adição manual.

    app.UseHttpsRedirection();
}
app.UseAuthorization();

app.MapControllers();

app.Run();
