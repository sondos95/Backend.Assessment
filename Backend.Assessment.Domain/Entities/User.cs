using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Assessment.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string UserName { get; set; }
    }
}
