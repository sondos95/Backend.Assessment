using Backend.Assessment.Domain.Entities;
using Backend.Assessment.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Assessment.UnitTesting.Mocks
{
    public static class DBContext
    {
        public static async Task<ApplictaionDbContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<ApplictaionDbContext>();
            options.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString());
            options.EnableSensitiveDataLogging();
            var databaseContext = new ApplictaionDbContext(options.Options);
            databaseContext.Database.EnsureCreated();
            // Drivers
            if (await databaseContext.Driver.CountAsync() <= 0)
            {
                for (int i = 1; i <= 10; i++)
                {
                    databaseContext.Driver.Add(new Driver()
                    {
                        Email = i.ToString(),
                        FirstName = i.ToString(),
                        Id = i,
                        LastName = i.ToString(),
                        PhoneNumber = i.ToString()
                    });
                    await databaseContext.SaveChangesAsync();
                }
            }

            //Users
            if (await databaseContext.Users.CountAsync() <= 0)
            {
                for (int i = 1; i <= 10; i++)
                {
                    databaseContext.Users.Add(new User()
                    {
                        Id = i,
                        UserName = i.ToString(),
                    });
                    await databaseContext.SaveChangesAsync();
                }
            }
            return databaseContext;
        }
    }
}
