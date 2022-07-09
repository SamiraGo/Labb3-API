
using Labb3_API.Model;
using Labb3_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb3_API.Services
{
    public class HobbyRepository : IRepository<Hobby>
    {
        private AppDbContext _appDbContext;
        public HobbyRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Hobby> Add(Hobby newEntity)
        {
            var newHobby = await _appDbContext.Hobbies.AddAsync(newEntity);
            await _appDbContext.SaveChangesAsync();
            return newHobby.Entity;
        }

        public async Task<IEnumerable<Hobby>> GetAll()
        {
            return await _appDbContext.Hobbies.ToListAsync();
        }

        public async Task<Hobby> GetSingle(int id)
        {
            return await _appDbContext.Hobbies
                .FirstOrDefaultAsync(l => l.HobbyId == id);
        }
    }
}
