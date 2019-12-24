using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CvApi.Models.Entities
{
    [Table("Message")]
    public class Message
    {
        [Key]
        public long MessageID { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]

        public long UserID { get; set; }
        public virtual User User { get; set; }
        [Required]
        public long CompanyID { get; set; }
        public virtual Company Company { get; set; }
    }
}
