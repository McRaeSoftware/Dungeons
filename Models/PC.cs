using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeons.Models
{
    public class PC
    {
        [Key]
        public int Character_ID { get; set; }

        [Required]
        public int User_ID { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Alignment { get; set; }

        [Required]
        [DisplayName("Exp")]
        public int Experience { get; set; }

        [Required]
        public int Level { get; set; }

        [Required]
        [DisplayName("Race")]
        public string RaceName { get; set; }

        [Required]
        [DisplayName("Class")]
        public string ClassName { get; set; }

        [Required]
        [DisplayName("AC")]
        public int ArmourClass { get; set; }

        [Required]
        public int MaxHealth { get; set; }

        [Required]
        public int CurrentHealth { get; set; }

        [Required]
        public int Strength { get; set; }

        [Required]
        public int Dexterity { get; set; }

        [Required]
        public int Constitution { get; set; }

        [Required]
        public int Intelligence { get; set; }

        [Required]
        public int Wisdom { get; set; }

        [Required]
        public int Charisma { get; set; }

        [Required]
        public string SavingThrows { get; set; }

        [Required]
        public string Proficiencies { get; set; }

        [Required]
        public string Languages { get; set; }

    }
}
