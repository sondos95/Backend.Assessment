using Backend.Assessment.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Assessment.Application.Repositories
{
    public abstract class Repository<T> : ControllerBase, IRepository<T> where T : class
    {
        protected readonly DbContext _context;
        protected DbSet<T> dbSet;
        private readonly IUnitOfWork _unitOfWork;

        public Repository(IUnitOfWork unitOfwork)
        {
            _unitOfWork = unitOfwork;
            dbSet = _unitOfWork.Context.Set<T>();
        }

        public async Task<ActionResult<IEnumerable<T>>> FindAll()
        {
           return await dbSet.ToListAsync();
        }

        public async Task<ActionResult<T>> FindById(object id)
        {
            return dbSet.Find(id);
        }

        public async Task<ActionResult<T>> Create(T entity)
        {
            dbSet.Add(entity);
            try
            {
                await _unitOfWork.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        public async Task<ActionResult<T>> Update(int id, T entity)
        {
            var existing = await dbSet.FindAsync(id);
            if (existing == null)
            {
                return NotFound();
            }

            _unitOfWork.Context.Entry(existing).CurrentValues.SetValues(entity);

            try
            {
                await _unitOfWork.SaveChanges();
                return entity;
            }
            catch (DbUpdateConcurrencyException)
            {
                return NoContent();
            }

        }

        public async Task<ActionResult<bool>> Delete(object id)
        {
            var entity = dbSet.Find(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
                try
                {
                    await _unitOfWork.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return NotFound(false);
            }
        }

        public async Task<IActionResult> CreateRange(List<T> entity)
        {
            dbSet.AddRange(entity);
            try
            {
                await _unitOfWork.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}