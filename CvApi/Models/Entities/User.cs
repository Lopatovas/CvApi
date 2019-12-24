using CvApi.Models.Entities.ResolvingTables;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CvApi.Models.Entities
{
    [Table("User")]
    public class User
    {
        public User()
        {
            this.UserSkills = new HashSet<UserSkill>();
            this.UserExperiences = new HashSet<UserExperience>();
            this.UserLetters = new HashSet<UserLetters>();
            this.Messages = new HashSet<Message>();
            this.Applications = new HashSet<Application>();
        }

        [Key]
        public long UserID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
        public virtual ICollection<UserExperience> UserExperiences { get; set; }
        public virtual ICollection<UserSkill> UserSkills { get; set; }
        public virtual ICollection<UserLetters> UserLetters { get; set; }

    }
}
