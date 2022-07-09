using Labb3_API.Model;
using Labb3_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb3_API.Services
{
    public class LinkRepository : IRepository<Link>
    {
        private AppDbContext _appDbContext;

        public LinkRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Link> Add(Link newEntity)
        {
            var newLink = await _appDbContext.Links.AddAsync(newEntity);
            await _appDbContext.SaveChangesAsync();
            return newLink.Entity;
        }

        public async Task<IEnumerable<Link>> GetAll()
        {
            return await _appDbContext.Links.ToListAsync();
        }

        public async Task<Link> GetSingle(int id)
        {
            return await _appDbContext.Links
                .FirstOrDefaultAsync(l => l.LinkId == id);
        }
    }
}
