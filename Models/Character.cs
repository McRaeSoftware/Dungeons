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
        public int Character_ID { get; set; }

        [Required]
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
        [DisplayName("Race")] // Possibly only letters alowed on this one new races can be added
        public string RaceName { get; set; }

        [Required]
        [DisplayName("Class")]
        public string ClassName { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$")]
        public int MaxHealth { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$")]
        public int CurrentHealth { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$")]
        public int Strength { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$")]
        public int Dexterity { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$")]
        public int Constitution { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$")]
        public int Intelligence { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$")]
        public int Wisdom { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$")]
        public int Charisma { get; set; }

        // TODO:
        // DISCUSS HOW WE WANT TO FORMAT
        // seperate words with ", "?
        [Required]
        public string SavingThrows { get; set; }

        [Required]
        public string Proficiencies { get; set; }

        [Required]
        public string Languages { get; set; }

    }
}
