var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(); //1 fiz manualmente esta adição.

var app = builder.Build();

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
