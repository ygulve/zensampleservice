using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZenDerivco.Models
{
    public class Employee
    {        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long EmployeeId { get; set; }
        public int StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string DerivcoEmail { get; set; }
        public string Gender { get; set; }
        public long ManagerId { get; set; }
        public int TeamId { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}
