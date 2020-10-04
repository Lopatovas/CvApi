using System;

namespace CvApi.Models.DataTransferObject
{
    public class CompanyDTO
    {
        public Guid CompanyID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
