﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CvApi.Models.Entities
{
    [Table("UserSkill")]
    public class UserSkill
    {
        [Key]
        public long UserSkillID { get; set; }
        [Required]
        public double Experience { get; set; }
        [Required]
        public long SkillID { get; set; }
        public virtual Skill Skill { get; set; }
        [Required]
        public long UserID { get; set; }
        public virtual User User { get; set; }
    }
}
