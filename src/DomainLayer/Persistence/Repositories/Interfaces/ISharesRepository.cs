using DomainLayer.Common.Dto;
using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DomainLayer.Persistence.Repositories.Interfaces
{
    public interface ISharesRepository
    {
        Task<Shares> GetAsync(int id, CancellationToken ct = default);
        Task<Shares> UpdateAsync(Shares entity, CancellationToken ct = default);
        Task<Paginated<Shares>> GetPageAsync<TOrder>(Expression<Func<Shares, TOrder>> order, int pageNumber, int pageSize, CancellationToken ct = default);

    }
}
