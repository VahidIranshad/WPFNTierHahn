using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Persistence.Interfaces
{
    /// <summary>
    /// DbContext factory interface
    /// </summary>
    public interface IDbContextFactory
    {
        DbContext GetContext();
    }
}
