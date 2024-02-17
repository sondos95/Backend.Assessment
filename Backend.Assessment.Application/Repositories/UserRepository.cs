using Backend.Assessment.Application.Interfaces;
using Backend.Assessment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Assessment.Application.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(IUnitOfWork unitOfwork) : base(unitOfwork)
        {

        }

    }
}
