using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Assessment.Domain.Entities
{
    public class Driver
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(25)]
        public required string FirstName { get; set; }
        [MaxLength(25)]
        public required string LastName { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid Phone Number")]
        public required string PhoneNumber { get; set; }
    }
}
