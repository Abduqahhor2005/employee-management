using EMS;
using EMS.Service.Employee;
using EMS.Service.Journal;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IJournalService, JournalService>();
builder.Services.AddDbContext<DataContext>(x=>
    x.UseNpgsql(builder.Configuration["ConnectionString"]));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();