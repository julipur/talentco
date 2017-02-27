using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TalentConnect.UI.Domain.Model;
using TalentConnect.UI.Infrastructure.Security;

namespace TalentConnect.UI.Infrastructure.Context
{
    public class DBInitializer
    {
        public static void Initialize()
        {
            Database.SetInitializer<TalentConnectContext>(new TalentConnectDatabaseStrategy());
            using (var context = new TalentConnectContext())
            {
                context.Database.Initialize(true);
            }
        }
    }

    public class TalentConnectDatabaseStrategy : DropCreateDatabaseIfModelChanges<TalentConnectContext>
    {
        protected override void Seed(TalentConnectContext context)
        {
            string hashedPassword, salt;
            var hasher = new SaltedHash();
            hasher.GetHashAndSaltString("p@ssw0rd", out hashedPassword, out salt);

            context.Users.Add(User.Add("jabbar@talentconnect.co", "Abdul Jabbar", "Zaffar", hashedPassword, salt, Role.Admin));
            context.Users.Add(User.Add("qudoos@talentconnect.co", "Abdul Qudoos", "Chaudhry", hashedPassword, salt, Role.Admin));
        }
    }
}