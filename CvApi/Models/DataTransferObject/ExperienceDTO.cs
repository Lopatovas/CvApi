using System;

namespace CvApi.Models.DataTransferObject
{
    public class ExperienceDTO
    {
        public Guid? ExperienceID { get; set; }
        public string Description { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string CompanyName { get; set; }
        public Guid? UserID { get; set; }
    }
}
