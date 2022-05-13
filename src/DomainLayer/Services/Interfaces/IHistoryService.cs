using DomainLayer.Common.Dto;
using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DomainLayer.Services.Interfaces
{
    public interface IHistoryService
    {
        Task<History> UpdateCustomer(History customer, CancellationToken ct = default);
        Task<Paginated<History>> GetPaginatedCustomersList<TOrder>(Expression<Func<History, TOrder>> order, int pageNumber, int pageSize, CancellationToken ct = default);

    }
}
