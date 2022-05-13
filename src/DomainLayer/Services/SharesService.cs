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
    public class SharesService : ISharesService
    {
        private readonly IWPFNTierHahnContext _context;

        public SharesService(IWPFNTierHahnContext context)
        {
            _context = context;
        }


        public async Task<Shares> UpdateCustomer(Shares customer, CancellationToken ct = default)
        {
            return await _context.Shares.UpdateAsync(customer);
        }

        public async Task<Paginated<Shares>> GetPaginatedCustomersList<TOrder>(Expression<Func<Shares, TOrder>> order, int pageNumber, int pageSize, CancellationToken ct = default)
        {
            return await _context.Shares.GetPageAsync(order, pageNumber, pageSize, ct);
        }
    }
}
