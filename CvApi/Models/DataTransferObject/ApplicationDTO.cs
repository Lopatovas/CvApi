using CvApi.Models.Enums;
using System;

namespace CvApi.Models.DataTransferObject
{
    public class ApplicationDTO
    {
        public Guid ApplicationID { get; set; }

        public Guid? UserID { get; set; }

        public string Username { get; set; }

        public Guid? JobAdvertisementID { get; set; }

        public DateTime CreatedAt { get; set; }

        public ApplicationStatus Status { get; set; }
    }
}
