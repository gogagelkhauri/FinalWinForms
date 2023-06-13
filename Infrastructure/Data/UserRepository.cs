using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<User>> GetAll()
        {
            return await _dbContext.Set<User>().ToListAsync();
        }

        public async Task<User> GetByUserNameAsync(string userName)
        {
            return await _dbContext.Set<User>().Include(u => u.Roles).SingleOrDefaultAsync(e => e.UserName == userName);
        }

        public void UpdateUser(User book)
        {
            _dbContext.Entry(book).State = EntityState.Modified;
        }
    }
}
