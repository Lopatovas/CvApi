using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CvApi.Models.Entities
{
    [Table("Skill")]
    public class Skill
    {
        public long SkillID { get; set; }
        public string Name { get; set; }
    }
}
