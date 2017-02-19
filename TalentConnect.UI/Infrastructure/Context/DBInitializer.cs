using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TalentConnect.UI.Domain;
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
            var provinces = InitlializeProvinces();
            provinces.ForEach(p => context.Provinces.Add(p));

            string hashedPassword, salt;
            var hasher = new SaltedHash();
            hasher.GetHashAndSaltString("p@ssw0rd", out hashedPassword, out salt);

            context.Users.Add(User.Add("jabbar@talentconnect.co", "Abdul Jabbar", "Zaffar", hashedPassword, salt, Role.Admin));
            context.Users.Add(User.Add("qudoos@talentconnect.co", "Abdul Qudoos", "Chaudhry", hashedPassword, salt, Role.Admin));
        }

        private List<Province> InitlializeProvinces()
        {
            return new List<Province>()
            {
                new Province () {Code = "AB", Name = "Alberta"},
                new Province () {Code = "BC", Name = "British Columbia"},
                new Province () {Code = "MB", Name = "Manitoba"},
                new Province () {Code = "NB", Name = "New Brunswick"},
                new Province () {Code = "NL", Name = "Newfoundland and Labrador"},
                new Province () {Code = "NT", Name = "Northwest Territories"},
                new Province () {Code = "NS", Name = "Nova Scotia"},
                new Province () {Code = "NU", Name = "Nunavut"},
                new Province () {Code = "ON", Name = "Ontario"},
                new Province () {Code = "PE", Name = "Prince Edward Island"},
                new Province () {Code = "QC", Name = "Quebec"},
                new Province () {Code = "SK", Name = "Saskatchewan"},
                new Province () {Code = "YT", Name = "Yukon"}
            };
        }
    }
}