using Labb3_API.Model;
using Labb3_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb3_API.Services
{
    public class PersonHobbyRepository : IRepository<PersonHobby>
    {
        private AppDbContext _appDbContext;

        public PersonHobbyRepository(AppDbContext labb3DbContext)
        {
            _appDbContext = labb3DbContext;
        }
        public async Task<PersonHobby> Add(PersonHobby personHobby)
        {
            var newPersonHobby = await _appDbContext.PersonHobbies.AddAsync(personHobby);
            await _appDbContext.SaveChangesAsync();
            return newPersonHobby.Entity;

        }

        public async Task<IEnumerable<PersonHobby>> GetAll()
        {
            return await _appDbContext.PersonHobbies.ToListAsync();
        }

        public async Task<PersonHobby> GetSingle(int id)
        {
            return await _appDbContext.PersonHobbies
                .FirstOrDefaultAsync(p => p.PersonHobbyId == id);
        }


    }
}
