using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbAssignment.DTO
{
    public class Grouping
    {
        public IGrouping<string, UserDto> GroupingMonth { get; set; }
    }
    public class GroupingMonth
    {
        public string MonthKey { get; set; }
        public string DeptKey { get; set; }
        public IEnumerable<UserDto> UserDto { get; set; }
    }
}
