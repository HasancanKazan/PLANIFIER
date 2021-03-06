﻿using Planifier.Data.Contracts;
using Planifier.DataAccess.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planifier.DataAccess.User
{
    public class UserRepository : PlanifierRepository<USER>,IUserRepository
    {
        public UserRepository(PlanifierDatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
