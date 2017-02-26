using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TalentConnect.UI.Domain
{
    public class Job : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(128)]
        public string Title { get; set; }
        [Required, MaxLength(int.MaxValue)]
        public string Description { get; set; }
        [Required, MaxLength(64)]
        public string City { get; set; }
        [Required, MaxLength(64)]
        public string Province { get; set; }
        [Required]
        public JobTypes JobType { get; set; }
        public int? YearsOfExperience { get; set; }
        public DateTime ClosingDate { get; set; }
        [Required]
        public bool FullTime { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public bool Filled { get; set; }
        public int? Hours { get; set; }
        public string Rate { get; set; } 
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}