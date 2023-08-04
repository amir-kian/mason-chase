using Mc2.CrudTest.Domain.Commands;
using Mc2.CrudTest.Domain.Interfaces;
using Mc2.CrudTest.Infrastructure;
using Mc2.CrudTest.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Mc2.CrudTest.Core.DTOs;
using Mc2.CrudTest.Domain.Queries;
using Mc2.CrudTest.Service.Handlers;
using Mc2.CrudTest.Domain.Events;

namespace Mc2.CrudTest.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            // Configure the DbContext.
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API Name", Version = "v1" });
            });
            builder.Services.AddScoped<IRequestHandler<GetAllCustomersQuery, CustomerReadDTO[]>, GetAllCustomersQueryHandler>();

            builder.Services.AddScoped<IWriteCustomerRepository, WriteCustomerRepository>();
            builder.Services.AddScoped<IReadCustomerRepository, ReadCustomerRepository>();
            builder.Services.AddScoped<IEventRepository<IDomainEvent>, EventRepository>();

            builder.Services.AddScoped<ICustomerEventHandler, CustomerEventHandler>();

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(CreateCustomerCommand))
                                            .RegisterServicesFromAssemblyContaining(typeof(CreateCustomerCommandHandler)));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API Name V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}