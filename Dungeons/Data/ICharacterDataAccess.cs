using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dungeons.Models;

namespace Dungeons.Data
{
    public interface ICharacterDataAccess
    {
        //Gets
        Task<List<Character>> GetMyCharacterListAsync(int userId);
        Task<Character> GetCharacterByCode(string code);
        Task<CharacterBag> GetCharacterBagByCode(string code);
        Task<CharacterEquipped> GetCharacterEquippedByCode(string code);

        //Creates
        Task<bool> CreateCharacter(Character character);
        Task<bool> CreateCharacterBag(CharacterBag bag);
        Task<bool> CreateCharacterEquipped(CharacterEquipped equipped);

        //Updates
        Task<bool> UpdateCharacter(Character character);
        Task<bool> UpdateCharacterBag(CharacterBag bag);
        Task<bool> UpdateCharacterEquipped(CharacterEquipped equipped);

        //Deletes
        Task<bool> DeleteCharacter(string code);
        Task<bool> DeleteCharacterBag(string code);
        Task<bool> DeleteCharacterEquipped(string code);
    }
}
