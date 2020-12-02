using System;

namespace CvApi.Models.DataTransferObject
{
    public class JobSkillDTO
    {
        public Guid? JobSkillID { get; set; }
        public double Experience { get; set; }
        public Guid? SkillID { get; set; }
        public Guid? JobAdvertisementID { get; set; }

        public string Name { get; set; }
    }
}
