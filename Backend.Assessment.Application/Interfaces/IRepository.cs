using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Assessment.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<ActionResult<IEnumerable<T>>> FindAll();
        Task<ActionResult<T>> FindById(object id);
        Task<ActionResult<T>> Create(T entity);
        Task<IActionResult> CreateRange(List<T> entity);
        Task<ActionResult<T>> Update(int id, T entity);
        Task<ActionResult<bool>> Delete(object id);
    }
}
