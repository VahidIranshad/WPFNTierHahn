using DomainLayer.Common.Dto;
using DomainLayer.Entities;
using DomainLayer.Persistence.Interfaces;
using DomainLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DomainLayer.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly IWPFNTierHahnContext _context;

        public HistoryService(IWPFNTierHahnContext context)
        {
            _context = context;
        }


        public async Task<History> UpdateCustomer(History customer, CancellationToken ct = default)
        {
            return await _context.History.UpdateAsync(customer);
        }

        public async Task<Paginated<History>> GetPaginatedCustomersList<TOrder>(Expression<Func<History, TOrder>> order, int pageNumber, int pageSize, CancellationToken ct = default)
        {
            return await _context.History.GetPageAsync(order, pageNumber, pageSize, ct);
        }
    }
}
