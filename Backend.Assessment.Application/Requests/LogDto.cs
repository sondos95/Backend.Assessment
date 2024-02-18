using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Assessment.Application.Requests
{
    public class LogDto
    {
        public int Level { get; set; }
        public required string Message { get; set; }
        public required string FileName { get; set; }
        public required string Timestamp { get; set; }
    }
}
