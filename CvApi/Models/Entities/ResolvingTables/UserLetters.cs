using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CvApi.Models.Entities
{
    [Table("UserLetter")]
    public class UserLetters
    {
        [Key]
        public long UserlettersID { get; set; }
        [Required]
        public long UserID { get; set; }
        public virtual User User { get; set; }
        [Required]
        public long CoverLetterID { get; set; }
        public virtual CoverLetter CoverLetter { get; set; }
    }
}
