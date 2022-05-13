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
    public interface IHistoryRepository
    {
        Task<History> GetAsync(int id, CancellationToken ct = default);
        Task<History> UpdateAsync(History entity, CancellationToken ct = default);
        Task<Paginated<History>> GetPageAsync<TOrder>(Expression<Func<History, TOrder>> order, int pageNumber, int pageSize, CancellationToken ct = default);

    }
}
