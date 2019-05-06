using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenDerivco.Models;
using ZenDerivco.Models.Repositroy;

namespace ZenDerivco.Data
{
    public class EmployeeManager : IDataRepository<Employee>
    {
        readonly ZenDerivcoContext _context;

        public EmployeeManager(ZenDerivcoContext context)
        {
            _context = context;
        }

        public void Add(Employee entity)
        {
            _context.Employees.Add(entity);
            _context.SaveChanges();

        }

        public void Delete(Employee entity)
        {
            _context.Employees.Remove(entity);
            _context.SaveChanges();
        }

        public Employee Get(long Id)
        {
            return _context.Employees.FirstOrDefault(e => e.EmployeeId == Id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public void Update(Employee dbEntity, Employee entity)
        {
            dbEntity.FirstName = entity.FirstName;
            dbEntity.LastName = entity.LastName;
            dbEntity.Email = entity.Email;
            dbEntity.DateOfBirth = entity.DateOfBirth;
            dbEntity.Gender = entity.Gender;
            dbEntity.ManagerId = entity.ManagerId;
            dbEntity.Password = entity.Password;
            dbEntity.PhoneNumber = entity.PhoneNumber;
            dbEntity.RoleId = entity.RoleId;
            dbEntity.StaffId = entity.StaffId;
            dbEntity.TeamId = entity.TeamId;
            dbEntity.UserId = entity.UserId;

            _context.SaveChanges();
        }
    }
}
