using AutoMapper;
using DbAssignment.DTO;
using DbAssignment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DbAssignment.Repositary
{
    public class UserRepositary : IUserRepositary
    {
        private readonly AppDbContext appDbContext;
        private readonly IMapper mapper;
        public UserRepositary(AppDbContext _appDbContext, IMapper _mapper)
        {
            appDbContext = _appDbContext;
            mapper = _mapper;
        }
        public List<GroupingMonth> GetAll()
        {
            //return await appDbContext.User.Include(x => x.Role).Include(x => x.Department).Select(x => new UserDto
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Address = x.Address,
            //    RegistrationDt = x.RegistrationDt,
            //    ExpireDt = x.ExpireDt,
            //    RefreshDt = x.RefreshDt,
            //    DepartmentId = x.Department.Id,
            //    RoleId = x.Role.Id
            //}).ToListAsync();
            List<User> user = appDbContext.User.ToList();
            List<Department> dept = appDbContext.Department.ToList();
            List<Role> role = appDbContext.Role.ToList();
            
            var data = (from u in user
                        join d in dept
                        on u.DepartmentId equals d.Id
                        join r in role
                        on u.RoleId equals r.Id
                        //   group by u.RegistrationDt into g
                        select new UserDto
                        {
                            Id = u.Id,
                            Name = u.Name,
                            Address = u.Address,
                            RegistrationDt = u.RegistrationDt.ToShortDateString(),
                            ExpireDt = u.ExpireDt.ToShortDateString(),
                            RefreshDt = u.RefreshDt.ToShortDateString(),
                            //DepartmentId = u.Department.Id,
                            departmentDto = new DepartmentDto { DepartmentId = d.Id, Name = d.Name },
                            roleDto = new RoleDto { RoleId = r.Id, Name = r.Name },
                            Month = u.RegistrationDt.ToString("MMMM")
                            //RoleId = u.Role.Id
                        }).GroupBy(x => new
                        {
                            x.Month,
                            x.departmentDto.Name
                        }).OrderBy(g => g.Key.Month).ThenBy(g => g.Key.Name).Distinct().Select(y => new GroupingMonth
                        {
                            MonthKey = y.Key.Month,
                            DeptKey = y.Key.Name,
                            UserDto = y.OrderBy(l => l.roleDto.RoleId)
                        }).Distinct();
            return data.ToList();

        }
    }
}
