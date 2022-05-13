using DomainLayer.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Persistence.Interfaces
{
    public interface IWPFNTierHahnContext
    {
        ISharesRepository Shares { get; }
        IHistoryRepository History { get; }
    }
}
