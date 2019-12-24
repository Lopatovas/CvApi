using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CvApi.Models.Entities
{
    [Table("CoverLetter")]
    public class CoverLetter
    {
        [Key]
        public long CoverLetterID { get; set; }
        [Required, MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
