using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hook.Model;
namespace Hook.Data.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        IQueryable<User> GetUserInfoByToken(string token);
    }
}