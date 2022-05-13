using DomainLayer.Persistence.Interfaces;
using DomainLayer.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Persistence
{
    public class WPFNTierHahnContext : IWPFNTierHahnContext
    {

        public WPFNTierHahnContext(ISharesRepository sharesRepository)
        {
            Shares = sharesRepository;
        }
        public WPFNTierHahnContext(IHistoryRepository historyRepository)
        {
            History = historyRepository;
        }
        public ISharesRepository Shares { get; }
        public IHistoryRepository History { get; }
    }
}
