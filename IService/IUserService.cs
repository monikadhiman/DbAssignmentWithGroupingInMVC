using DbAssignment.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbAssignment.Service
{
    public interface IUserService
    {
        List<GroupingMonth> GetAllAsync();
    }
}
