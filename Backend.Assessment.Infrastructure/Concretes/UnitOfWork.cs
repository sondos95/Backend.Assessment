using Backend.Assessment.Application.Interfaces;
using Backend.Assessment.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Assessment.Infrastructure.Concretes
{
    public class UnitOfWork(ApplictaionDbContext context) : IUnitOfWork
    {
        private readonly ApplictaionDbContext _context = context;

        public DbContext Context => _context;

        public async Task<int> SaveChanges()
        {
            return await this._context.SaveChangesAsync();
        }
        public void Dispose()
        {
            this._context.Dispose();
        }

    }
}
