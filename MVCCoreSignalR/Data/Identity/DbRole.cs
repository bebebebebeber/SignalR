﻿using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FastDostavka.Data.Entities.IdentityUser
{
    public class DbRole:IdentityRole<int>
    {
        public virtual ICollection<DbUserRole> UserRoles { get; set; }
        //public string Description { get; set; }
    }
}
