using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeons.Models
{
    public class Bag
    {
        [Required]
        public int CharacterCode { get; set; }

        [Required]
        public List<string> ItemList;

        [Required]
        [DisplayName("gp")]
        public int Gold { get; set; }

        [Required]
        [DisplayName("sp")]
        public int Silver { get; set; }

        [Required]
        [DisplayName("cp")]
        public int Copper { get; set; }


    }
}
