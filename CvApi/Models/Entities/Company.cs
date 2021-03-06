﻿using CvApi.Models.Entities.ResolvingTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CvApi.Models.Entities
{
    [Table("Company")]
    public class Company
    {
        public Company()
        {
            this.JobAdvertisements = new HashSet<JobAdvertisement>();
        }

        [Key]
        public Guid CompanyID { get; set; }
        [Required, MaxLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required, MaxLength(100)]
        public string Address { get; set; }
        public string Phone { get; set; }
        [Required, MaxLength(100)]
        public string Email { get; set; }
        public virtual ICollection<JobAdvertisement> JobAdvertisements { get; set; }
    }
}
