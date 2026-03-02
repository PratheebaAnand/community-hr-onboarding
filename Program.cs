using OnboardEaseMini.Repositories;
using OnboardEaseMini.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped<EmployeeRepository>();
builder.Services.AddScoped<EmployeeService>();

var app = builder.Build();
   app.MapOpenApi();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
