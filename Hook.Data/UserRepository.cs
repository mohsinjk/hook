using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using Hook.Data.Contracts;
using Hook.Model;

namespace Hook.Data
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context) { }

        public IQueryable<User> GetUserInfoByToken(string token)
        {
            int t = int.Parse(token);
            return DbSet.Where(x => x.Id == t).Include("UserInfo");
        }
    }
}
