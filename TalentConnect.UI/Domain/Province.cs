using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TalentConnect.UI.Domain
{
    public class Province : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(2)]
        public string Code { get; set; }
        [Required, MaxLength(64)]
        public string Name { get; set; }
    }
}