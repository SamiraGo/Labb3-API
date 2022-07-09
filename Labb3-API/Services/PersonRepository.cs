using Labb3_API.Model;
using Labb3_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb3_API.Services
{
    public class PersonRepository : IPersonRepository<Person>
    {
        private AppDbContext _appDbContext;

        public PersonRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _appDbContext.Persons.ToListAsync();
        }

        public async Task<Person> GetInterests(int id)
        {
            var person = GetSingle(id);
            if (person != null)
            {
                var hobbies = await _appDbContext.Persons
                    .Include(ph => ph.PersonHobbies)
                    .ThenInclude(h => h.Hobby)
                    .FirstOrDefaultAsync(p => p.PersonId == id);
                return hobbies;
            }
            return null;
        }

        public async Task<Person> GetLinks(int id)
        {
            var person = GetSingle(id);
            if (person != null)
            {
                var links = await _appDbContext.Persons
                    .Include(l => l.Links)
                    .ThenInclude(h => h.Hobby)
                    .FirstOrDefaultAsync(p => p.PersonId == id);
                return links;
            }
            return null;
        }

        public async Task<Person> GetSingle(int id)
        {
            return await _appDbContext.Persons.FirstOrDefaultAsync(p => p.PersonId == id);
        }
    }
}
