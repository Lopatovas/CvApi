using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CvApi.Models.Entities
{
    [Table("Experience")]
    public class Experience
    {
        [Key]
        public long ExperienceID { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        [Required, MaxLength(100)]
        public string CompanyName { get; set; }
        [ForeignKey("User")]
        public long UserID { get; set; }
    }
}
