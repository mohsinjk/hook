using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hook.Model;
namespace Hook.Data.Contracts
{
    public interface IFeedRepository: IRepository<Feed>
    {
        IQueryable<Feed> GetFeeds(int userId);
    }
}
