using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hook.Model;
namespace Hook.Data.Contracts
{
    public interface IUnitOfWork
    {
        void Commit();
        IUserRepository Users { get; }
        IRepository<UserInfo> UserInfos { get; }
        IRepository<Follow> Follows { get; }
        IRepository<Favorite> Favorites { get; }
        IRepository<Group> Groups { get; }
        IRepository<Connection> Connections { get; }
        IFeedRepository Feeds { get; }

    }
}
