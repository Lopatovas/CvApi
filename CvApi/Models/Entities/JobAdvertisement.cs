using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CvApi.Models.Entities.ResolvingTables
{
    [Table("JobAdvertisement")]
    public class JobAdvertisement
    {
        public JobAdvertisement()
        {
            this.JobSkills = new HashSet<JobSkill>();
            this.Applications = new HashSet<Application>();
        }
        [Key]
        public long JobAdvertisementID { get; set; }
        [Required, MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required, MaxLength(100)]
        public string ContactEmail { get; set; }
        [Required]
        public double SalaryFrom { get; set; }
        [Required]
        public double SalaryTo { get; set; }
        [Required]
        public string City { get; set; }
        [Required]

        public DateTime CreatedAt { get; set; }
        [Required]

        public DateTime EndsAt { get; set; }
        [Required]
        public long CompanyID { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<JobSkill> JobSkills { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
    }
}
