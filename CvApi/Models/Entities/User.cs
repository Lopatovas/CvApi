using CvApi.Models.Entities.ResolvingTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CvApi.Models.Entities
{
    [Table("User")]
    public class User
    {

        [Key]
        public Guid UserID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public string Description { get; set; }
        [ForeignKey("Company")]
        public Guid? CompanyID { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
        public virtual ICollection<Experience> UserExperiences { get; set; }
        public virtual ICollection<UserSkill> UserSkills { get; set; }

    }
}
