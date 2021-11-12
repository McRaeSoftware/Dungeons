using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeons.Models
{
    public class CharacterBag
    {
        [Key]
        [Required]
        public int CharacterCode { get; set; }

        [Required]
        [RegularExpressionList(@"^[a-zA-Z ']+$",
            ErrorMessage = "Each item in the bag must only contain letters, spaces and apostrophes")]
        public List<string> ItemList;

        [Required]
        [DisplayName("gp")]
        [RegularExpression(@"^[0-9]+$",
            ErrorMessage = "Gold must be a number")]
        public int Gold { get; set; }

        [Required]
        [DisplayName("sp")]
        [RegularExpression(@"^[0-9]+$",
            ErrorMessage = "Silver must be a number")]
        public int Silver { get; set; }

        [Required]
        [DisplayName("cp")]
        [RegularExpression(@"^[0-9]+$",
            ErrorMessage = "Copper must be a number")]
        public int Copper { get; set; }
    }
}