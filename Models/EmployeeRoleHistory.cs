using System;

namespace ZenDerivco.Models
{
    public class EmployeeRoleHistory
    {

        public int EmpRoleHistoryId { get; set; }
        public int EmployeeId { get; set; }
        public int RoleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
