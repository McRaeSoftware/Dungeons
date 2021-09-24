using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeons.Models
{
    public class CharacterEquipped
    {
        [Required]
        public string CharacterCode { get; set; }

        [Required]
        [RegularExpressionList(@"^[a-zA-Z ']+$",
            ErrorMessage = "Special Items name must only contain letters, spaces and apostrophes")]
        public List<string> SpecialItems { get; set; }

        [Required]
        [DisplayName("AC")]
        [RegularExpression(@"^[0-9]{1,2}$",
            ErrorMessage = "Armour class must be a number")]
        public int ArmourClass { get; set; }

        [Required]
        [RegularExpressionList(@"^[a-zA-Z ']+$",
            ErrorMessage = "Armour name must only contain letters, spaces and apostrophes")]
        public string ArmourName { get; set; }

        [Required]
        [RegularExpressionList(@"^[a-zA-Z ']+$",
            ErrorMessage = "Main hand must only contain letters, spaces and apostrophes")]
        public string MainHand { get; set; }

        [Required]
        [RegularExpressionList(@"^[a-zA-Z ']+$",
            ErrorMessage = "Offhand must only contain letters, spaces and apostrophes")]
        public string OffHand { get; set; }
    }
}
