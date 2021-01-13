using DbAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbAssignment.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string RegistrationDt { get; set; }
        public string ExpireDt { get; set; }
        public string RefreshDt { get; set; }

        public DepartmentDto departmentDto { get; set; }
        public RoleDto roleDto { get; set; }
        public string Month { get; set; }
      
    }
}
