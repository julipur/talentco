using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentConnect.UI.Infrastructure.Context
{
    public interface IDbContext
    {
        IDbSet<TEntity> GetDbSet<TEntity>() where TEntity : class;
        string GetDbSetName<TEntity>() where TEntity : class;
        void Save();
    }
}
