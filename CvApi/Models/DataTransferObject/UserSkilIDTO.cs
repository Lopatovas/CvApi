using System;

namespace CvApi.Models.DataTransferObject
{
    public class UserSkillDTO
    {
        public Guid? UserSkillID { get; set; }
        public double Experience { get; set; }
        public Guid SkillID { get; set; }
        public Guid? UserID { get; set; }
    }
}
