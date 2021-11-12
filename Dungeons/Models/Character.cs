using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeons.Models
{
    public class Character
    {
        [Key]
        [RegularExpression(@"^[0-9]+$",
            ErrorMessage ="Character ID must only contain numbers")]
        public int Character_ID { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$",
            ErrorMessage = "User ID must only contain numbers")]
        public int User_ID { get; set; }

        [Required]
        [RegularExpression("@^[a-fA-F0-9]+$",
            ErrorMessage = "Code must be a string of Hexidecimals")]
        public string Code { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z ]+$",
            ErrorMessage = "Name can only contain letters and spaces.")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z ]+$",
            ErrorMessage = "Alignment can only contain letters and spaces.")]
        public string Alignment { get; set; }

        [Required]
        [DisplayName("Exp")]
        [RegularExpression(@"^[0-9]+$",
            ErrorMessage = "Experience can only contain numbers.")]
        public int Experience { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]$|(^[1][0-9]$)|(^20$)",
            ErrorMessage = "Level can only be between 1 and 20.")]
        public int Level { get; set; }

        [Required]
        [DisplayName("Race")]
        [RegularExpression(@"^[a-zA-z ]$",
            ErrorMessage ="Race must only contain letters and spaces.")]
        public string RaceName { get; set; }

        [Required]
        [DisplayName("Class")]
        [RegularExpression(@"^[a-zA-z]$",
            ErrorMessage = "Class must only contain letters.")]
        public string ClassName { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$", 
            ErrorMessage ="MaxHealth can only contain nmumbers.")]
        public int MaxHealth { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$",
            ErrorMessage = "CurrentHealth can only contain nmumbers.")]
        public int CurrentHealth { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$",
            ErrorMessage = "Strength can only contain nmumbers.")]
        public int Strength { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$",
            ErrorMessage = "Dexterity can only contain nmumbers.")]
        public int Dexterity { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$",
            ErrorMessage = "Constitution can only contain nmumbers.")]
        public int Constitution { get; set; }
            
        [Required]
        [RegularExpression(@"^[0-9]+$",
            ErrorMessage = "Intelligence can only contain nmumbers.")]
        public int Intelligence { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$",
            ErrorMessage = "Wisdom can only contain nmumbers.")]
        public int Wisdom { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$",
            ErrorMessage = "Charisma can only contain nmumbers.")]
        public int Charisma { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-z, ]+$",
            ErrorMessage ="Please seperate Saving throws with ', ' e.g. 'Wisdom, Charisma'.")]
        public string SavingThrows { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-z, ]+$",
            ErrorMessage = "Please seperate Proficiencies with ', ' e.g. 'Simple ranged weapons, Heavy Armour, Intimidation'.")]
        public string Proficiencies { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-z, ]+$",
            ErrorMessage = "Please seperate Languages with ', ' e.g. 'Common, Dwarvish, Elvish'.")]
        public string Languages { get; set; }
    }
}
