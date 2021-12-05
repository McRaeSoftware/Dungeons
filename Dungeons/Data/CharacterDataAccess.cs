using Dungeons.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeons.Data
{
    public class CharacterDataAccess : ICharacterDataAccess
    {
        public DungeonsDBContext _database;

        //Gets
        public async Task<List<Character>> GetMyCharacterListAsync(int userId)
        {
            return await _database.Character.Where(character => character.User_ID == userId).ToListAsync();
        }
                
        public async Task<Character> GetCharacterByCode(string code)
        {
            return await _database.Character.FirstAsync(character => character.Code == code);
        }
        public async Task<CharacterBag> GetCharacterBagByCode(string code)
        {
            return await _database.CharacterBag.FirstAsync(bag => bag.CharacterCode == code);
        }
        public async Task<CharacterEquipped> GetCharacterEquippedByCode(string code)
        {
            return await _database.CharacterEquipped.FirstAsync(equipped => equipped.CharacterCode == code);
        }

        //Creates
        public async Task<bool> CreateCharacter(Character character)
        {
            try
            {
                _database.Add(character);

                if (await _database.SaveChangesAsync() > 0)
                {
                    return true;
                }
            }
            catch
            {
                throw;
            }
            return false;
        }


        public async Task<bool> CreateCharacterBag(CharacterBag bag)
        {
            try
            {
                _database.Add(bag);
                if (await _database.SaveChangesAsync() > 0)
                {
                    return true;
                }
            }
            catch
            {
                throw;
            }
            return false;
        }

        public async Task<bool> CreateCharacterEquipped(CharacterEquipped equipped)
        {
            try
            {
                _database.Add(equipped);
                if (await _database.SaveChangesAsync() > 0)
                {
                    return true;
                }
            }
            catch
            {
                throw;
            }
            return false;
        }

        //Updates
        public async Task<bool> UpdateCharacter(Character character)
        {
            try
            {
                _database.Update(character);
                if (await _database.SaveChangesAsync() > 0)
                {
                    return true;
                }
            }
            catch
            {
                throw;
            }

            return false;
        }

        public async Task<bool> UpdateCharacterBag(CharacterBag bag)
        {
            try
            {
                _database.Update(bag);
                if (await _database.SaveChangesAsync() > 0)
                {
                    return true;
                }
            }
            catch
            {
                throw;
            }

            return false;
        }

        public async Task<bool> UpdateCharacterEquipped(CharacterEquipped equipped)
        {
            try
            {
                _database.Update(equipped);
                if (await _database.SaveChangesAsync() > 0)
                {
                    return true;
                }
            }
            catch
            {
                throw;
            }

            return false;
        }

        //Deletes
        public async Task<bool> DeleteCharacter(string code)
        {
            try
            {
                var character = await _database.Character.FindAsync(code);

                _database.Character.Remove(character);

                if (await _database.SaveChangesAsync() > 0)
                {
                    return true;
                }
            }
            catch
            {
                throw;
            }
            return false;
        }



        public async Task<bool> DeleteCharacterBag(string code)
        {
            try
            {
                var bag = await _database.CharacterBag.FindAsync(code);

                _database.CharacterBag.Remove(bag);

                if (await _database.SaveChangesAsync() > 0)
                {
                    return true;
                }
            }
            catch
            {
                throw;
            }
            return false;
        }

        public async Task<bool> DeleteCharacterEquipped(string code)
        {
            try
            {
                var equipped = await _database.CharacterEquipped.FindAsync(code);

                _database.CharacterEquipped.Remove(equipped);

                if (await _database.SaveChangesAsync() > 0)
                {
                    return true;
                }
            }
            catch
            {
                throw;
            }
            return false;
        }
    }
}
