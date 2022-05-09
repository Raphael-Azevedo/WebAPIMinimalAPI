using ApiCatalgo.ApiEndpoints;
using ApiCatalgo.AppServicesExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddApiSwagger();
builder.AddPersistence();
builder.Services.AddCors();
builder.AddAutenticationJwt();

var app = builder.Build();

app.MapAutenticacaoEndpoints();
app.MapCategoriasEndpoints();
app.MapProdutosEndpoints();

var environment = app.Environment;
app.UseExceptionHandling(environment)
   .UseSwaggerMiddlaware()
   .UseAppCors();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.Run();
