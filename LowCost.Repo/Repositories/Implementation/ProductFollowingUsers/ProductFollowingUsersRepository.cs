using LowCost.Domain.Context;
using LowCost.Domain.Models;
using LowCost.Repo.Generic;
using LowCost.Repo.Repositories.Interfaces.ProductFollowingUsers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Repo.Repositories.Implementation.ProductFollowingUsers
{
    public class ProductFollowingUsersRepository : GenericRepository<ProductFollowingUser>, IProductFollowingUsersRepository
    {
        public ProductFollowingUsersRepository(DB context)
            : base(context)
        {
        }
    }
}
