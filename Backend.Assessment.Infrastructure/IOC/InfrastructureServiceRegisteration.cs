using Backend.Assessment.Application.Interfaces;
using Backend.Assessment.Infrastructure.Concretes;
using Backend.Assessment.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Assessment.Infrastructure.IOC
{
    public static class InfrastructureServiceRegisteration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplictaionDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("AssessmentDatabase")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

    }
}
