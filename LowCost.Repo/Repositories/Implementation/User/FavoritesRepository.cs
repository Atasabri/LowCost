using LowCost.Domain.Context;
using LowCost.Domain.Models;
using LowCost.Repo.Generic;
using LowCost.Repo.Repositories.Interfaces.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Repo.Repositories.Implementation.User
{
    public class FavoritesRepository : GenericRepository<Favorites>, IFavoritesRepository
    {
        public FavoritesRepository(DB context)
            : base(context)
        {
        }
    }
}
