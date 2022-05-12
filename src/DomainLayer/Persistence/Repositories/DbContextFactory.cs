using DomainLayer.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Persistence.Repositories
{
    /// <summary>
    /// DbContext factory implementation, without creating dependency
    /// </summary>
    public class DbContextFactory : IDbContextFactory
    {
        private WPFNTierHahnDbContext _context;

        public DbContext GetContext()
        {
            return _context ?? (_context = new WPFNTierHahnDbContext());
        }
    }
}
