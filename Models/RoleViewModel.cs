using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSE_DEPARTMENT.Models
{
    public class RoleViewModel
    {
        public RoleViewModel() { }

        public RoleViewModel(ApplicationRole role)
        {
            Id = role.Id;
            Name = role.Name;
        }

        public String Id { get; set; }
        public String Name { get; set; }
    }
}