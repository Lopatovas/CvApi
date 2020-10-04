using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CvApi.Models.Entities.ResolvingTables
{
    [Table("Application")]
    public class Application
    {
        [Key]
        public Guid ApplicationID { get; set; }
        [Required]
        public Guid UserID { get; set; }
        public virtual User User { get; set; }
        [Required]
        public Guid JobAdvertisementID { get; set; }
        public virtual JobAdvertisement JobAdvertisement { get; set; }
        [Required]
        public Guid CoverLetterID { get; set; }
        public virtual CoverLetter CoverLetter { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
