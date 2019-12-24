using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CvApi.Models.Entities
{
    [Table("Skill")]
    public class Skill
    {
        [Key]
        public long SkillID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
