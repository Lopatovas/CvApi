using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CvApi.Models.Entities.ResolvingTables
{
    [Table("Application")]
    public class Application
    {
        [Key]
        public long ApplicationID { get; set; }
        [Required]
        public long UserID { get; set; }
        public virtual User User { get; set; }
        [Required]
        public long JobAdvertisementID { get; set; }
        public virtual JobAdvertisement JobAdvertisement { get; set; }
        [Required]
        public long CoverLetterID { get; set; }
        public virtual CoverLetter CoverLetter { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
