using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CvApi.Models.Entities.ResolvingTables
{
    [Table("UserExperience")]
    public class UserExperience
    {
        [Key]
        public long UserExperienceID { get; set; }
        [Required]
        public long UserID { get; set; }
        public virtual User User { get; set; }
        [Required]
        public virtual Experience Experience { get; set; }
        [Required]
        public long ExperienceID { get; set; }
    }
}
