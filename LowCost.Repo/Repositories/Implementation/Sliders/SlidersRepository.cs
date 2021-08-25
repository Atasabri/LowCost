using LowCost.Domain.Context;
using LowCost.Domain.Models;
using LowCost.Repo.Generic;
using LowCost.Repo.Repositories.Interfaces.Sliders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Repo.Repositories.Implementation.Sliders
{
    public class SlidersRepository : GenericRepository<Slider>, ISlidersRepository
    {
        public SlidersRepository(DB context)
        : base(context)
        {
        }
    }
}
