using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TalentConnect.UI.Domain
{
    public class User : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(128)]
        public string Email { get; set; }
        [Required, MaxLength(64)]
        public string FirstName { get; set; }
        [Required, MaxLength(64)]
        public string LastName { get; set; }
        [Required, MaxLength(128)]
        public string HashedPassword { get; set; }
        [Required, MaxLength(128)]
        public string PasswordSalt { get; set; }

        internal static User Add(
            string email, 
            string firstName, 
            string lastName,
            string hashedPassword, 
            string passwordSalt)
        {
            return new User()
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                HashedPassword = hashedPassword,
                PasswordSalt = passwordSalt
            };
        }
    }
}