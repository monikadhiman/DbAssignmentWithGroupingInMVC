using DbAssignment.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbAssignment.Repositary
{
    public interface IUserRepositary
    {
       List<GroupingMonth> GetAll();
    }
}
