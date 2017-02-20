using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using TalentConnect.UI.Domain;

namespace TalentConnect.UI.Infrastructure.Context
{
    public class TalentConnectContext : DbContext, IDbContext
    {
        private const string _connectionStringKey = "name=TalentConnect";

        public TalentConnectContext()
            :this(_connectionStringKey)
        {
            Database.Initialize(true);
        }

        public TalentConnectContext(
            string connectionStringKey):base (connectionStringKey)
        {

        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<User> Users { get; set; }

        #region IDbContext Members

        public IDbSet<TEntity> GetDbSet<TEntity>() where TEntity : class
        {
            IDbSet<TEntity> entitySet = null;
            foreach (PropertyInfo pi in this.GetType().GetProperties())
            {
                if (pi.PropertyType.Equals(typeof(DbSet<TEntity>)))
                {
                    entitySet = pi.GetValue(this, null) as IDbSet<TEntity>;
                    break;
                }
            }

            return entitySet;
        }

        public string GetDbSetName<TEntity>() where TEntity : class
        {
            string entitySetName = null;
            foreach (PropertyInfo pi in this.GetType().GetProperties())
            {
                if (pi.PropertyType.Equals(typeof(DbSet<TEntity>)))
                {
                    entitySetName = pi.Name;
                    break;
                }
            }

            return entitySetName;
        }

        public void Save()
        {
            this.SaveChanges();
        }

        # endregion

    }
}