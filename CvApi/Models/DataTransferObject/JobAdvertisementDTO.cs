using System;

namespace CvApi.Models.DataTransferObject
{
    public class JobAdvertisementDTO
    {
        public Guid? JobAdvertisementID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ContactEmail { get; set; }
        public double SalaryFrom { get; set; }
        public double SalaryTo { get; set; }
        public string City { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime EndsAt { get; set; }
        public Guid? CompanyID { get; set; }
    }
}
