using DomainLayer.Persistence.Repositories.Interfaces;
using System;
using DomainLayer.Common.Dto;
using DomainLayer.Entities;
using DomainLayer.Persistence.Interfaces;
using DomainLayer.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace DomainLayer.Persistence.Repositories
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<History> _dbSet;

        public HistoryRepository(IWPFNTierHahnContextFactory contextFactory)
        {
            _context = contextFactory.GetContext();
            _dbSet = _context.Set<History>();
        }

        public async Task<History> GetAsync(int id, CancellationToken ct = default)
        {
            return await _dbSet.FindAsync(ct, id);
        }

        public async Task<History> UpdateAsync(History entity, CancellationToken ct = default)
        {
            _dbSet.AddOrUpdate(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Paginated<History>> GetPageAsync<TOrder>(Expression<Func<History, TOrder>> order,
             int pageNumber, int pageSize, CancellationToken ct = default)
        {
            var itemCount = await _dbSet.CountAsync();

            int pagesCount = 0;
            ICollection<History> pageItems = null;

            if (itemCount != 0 && pageSize > 0)
            {
                pagesCount = (itemCount / pageSize) +
                                 ((itemCount % pageSize == 0) ? 0 : 1);

                pageItems = await GetLimitAsync(order,
                                              pageSize,
                                              ((pageNumber - 1) < 0 ? 0 : (pageNumber - 1)) *
                                                                    pageSize,
                                                                    ct);
            }

            Paginated<History> paginatedResult = new Paginated<History>
            {
                ItemsCount = itemCount,
                PagesCount = pagesCount,
                PageNumber = pageNumber,
                PageItems = pageItems
            };

            return paginatedResult;
        }

        public virtual async Task<ICollection<History>> GetLimitAsync<TOrder>(Expression<Func<History, TOrder>> order, int take, int skip, CancellationToken ct = default)
        {
            return await _dbSet.OrderBy(order).Skip(skip).Take(take).ToListAsync(ct);
        }
    }
}
