using CvApi.Models.Entities.ResolvingTables;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CvApi.Models.Entities
{
    [Table("JobSkill")]
    public class JobSkill
    {
        [Key]
        public long JobSkillID { get; set; }
        [Required]
        public double Experience { get; set; }
        [Required]
        public long SkillID { get; set; }
        public virtual Skill Skill { get; set; }
        [Required]
        public long JobAdvertisementID { get; set; }
        public virtual JobAdvertisement JobAdvertisement { get; set; }
    }
}
