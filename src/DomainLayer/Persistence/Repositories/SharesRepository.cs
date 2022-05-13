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
    public class SharesRepository: ISharesRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Shares> _dbSet;

        public SharesRepository(IWPFNTierHahnContextFactory contextFactory)
        {
            _context = contextFactory.GetContext();
            _dbSet = _context.Set<Shares>();
        }

        public async Task<Shares> GetAsync(int id, CancellationToken ct = default)
        {
            return await _dbSet.FindAsync(ct, id);
        }

        public async Task<Shares> UpdateAsync(Shares entity, CancellationToken ct = default)
        {
            entity.UpdatedTime = DateTime.Now;
            _dbSet.AddOrUpdate(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Paginated<Shares>> GetPageAsync<TOrder>(Expression<Func<Shares, TOrder>> order,
             int pageNumber, int pageSize, CancellationToken ct = default)
        {
            var itemCount = await _dbSet.CountAsync();

            int pagesCount = 0;
            ICollection<Shares> pageItems = null;

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

            Paginated<Shares> paginatedResult = new Paginated<Shares>
            {
                ItemsCount = itemCount,
                PagesCount = pagesCount,
                PageNumber = pageNumber,
                PageItems = pageItems
            };

            return paginatedResult;
        }

        public virtual async Task<ICollection<Shares>> GetLimitAsync<TOrder>(Expression<Func<Shares, TOrder>> order, int take, int skip, CancellationToken ct = default)
        {
            return await _dbSet.OrderBy(order).Skip(skip).Take(take).ToListAsync(ct);
        }
    }
}
