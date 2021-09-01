using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeons.Models
{
    public class Equipped
    {
        [Required]
        public string CharacterCode { get; set; }

        [Required]
        public List<string> SpecialItems { get; set; }

        [Required]
        [DisplayName("AC")]
        public int ArmourClass { get; set; }

        [Required]
        public string ArmourName { get; set; }

        [Required]
        public string MainHand { get; set; }

        [Required]
        public string OffHand { get; set; }
    }
}
