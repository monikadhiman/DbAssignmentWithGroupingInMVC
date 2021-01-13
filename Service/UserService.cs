using DbAssignment.DTO;
using DbAssignment.Repositary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbAssignment.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepositary userRepositary;
        public UserService(IUserRepositary _userRepositary)
        {
            userRepositary = _userRepositary;
        }
        public List<GroupingMonth> GetAllAsync()
        {
            return userRepositary.GetAll();
        }
    }
}
