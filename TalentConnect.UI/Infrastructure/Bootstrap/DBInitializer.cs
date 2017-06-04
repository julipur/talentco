using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using TalentConnect.UI.Domain.Model;
using TalentConnect.UI.Infrastructure.Security;
using TalentConnect.UI.Domain.Commands;

namespace TalentConnect.UI.Infrastructure.Bootstrap
{
    public class DBInitializer
    {
        public async Task Initialize()
        {
            await new DataInitializer().Seed();
        }
    }

    public class DataInitializer
    {
        public async Task Seed()
        {
            string hashedPassword, salt;
            var hasher = new SaltedHash();
            hasher.GetHashAndSaltString("p@ssw0rd", out hashedPassword, out salt);

            await new AddUserCommandHandler().HandleAsync(new AddUserCommand()
            {
                Email = "jabbar@talentconnect.co",
                FirstName = "Abdul Jabbar",
                LastName = "Zaffar",
                HashedPassword = hashedPassword,
                PasswordSalt = salt,
                Role = (int) Role.Admin
            });

            await new AddUserCommandHandler().HandleAsync(new AddUserCommand()
            {
                Email = "qudoos@talentconnect.co",
                FirstName = "Abdul Qudoos",
                LastName = "Chaudhry",
                HashedPassword = hashedPassword,
                PasswordSalt = salt,
                Role = (int)Role.Admin
            });
        }
    }
}