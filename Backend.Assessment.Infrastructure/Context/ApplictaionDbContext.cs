using Backend.Assessment.Application.Interfaces;
using Backend.Assessment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Assessment.Infrastructure.Context
{
    public class ApplictaionDbContext : DbContext
    {
        public ApplictaionDbContext(DbContextOptions<ApplictaionDbContext> options) : base(options)
        {

        }

        public DbSet<Driver> Driver { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
