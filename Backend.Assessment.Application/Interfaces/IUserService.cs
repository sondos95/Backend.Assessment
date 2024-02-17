using Backend.Assessment.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Assessment.Application.Interfaces
{
    public interface IUserService
    {
        IActionResult CreateRandomNames();
        List<User> GetAllUsersAlphabetized();
        string GetUserNameAlphabetized(string Name);   
    }
}
