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
    /// <summary>
    /// service layer for Shares entity
    /// </summary>
    public interface ISharesService
    {
        Task<Shares> UpdateCustomer(Shares customer, CancellationToken ct = default);
        Task<Paginated<Shares>> GetPaginatedCustomersList<TOrder>(Expression<Func<Shares, TOrder>> order, int pageNumber, int pageSize, CancellationToken ct = default);

    }
}
