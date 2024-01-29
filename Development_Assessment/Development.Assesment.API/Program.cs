using Development.Assesment.Data;
using Development.Assesment.Data.Context;
using Development.Assesment.Data.Factory;
using Development.Assesment.Data.Interface;
using Development.Assesment.Data.Interfaces;
using Development.Assesment.Data.Operations;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DbContext
var configuration = new ConfigurationBuilder()  
.SetBasePath(builder.Environment.ContentRootPath)
.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
.AddEnvironmentVariables()
.Build();

builder.Services.AddDbContext<AssesmentContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Development.Assesment.API"))
); 
#endregion

#region Scoped
builder.Services.AddScoped<IOperationsFactory, OperationsFactory>();
builder.Services.AddScoped<IUserOperations, UserOperations>();
builder.Services.AddScoped<IPermissionOperations, PermissionOperations>();
builder.Services.AddScoped<IGroupOperations, GroupOperations>();
#endregion

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
