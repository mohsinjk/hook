using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using Hook.Data.Contracts;
using Hook.Model;

namespace Hook.Data
{
    public class FeedRepository: Repository<Feed>, IFeedRepository
    {
        public FeedRepository(DbContext context):base(context) { }

        public IQueryable<Feed> GetFeeds(int userId) 
        {

            var myFeed = DbSet.Where(x => x.UserId == userId).Include("User");

            Repository<Follow> objFollow = new Repository<Follow>(DbContext);
            var followUserIds = new List<int>();
            followUserIds = objFollow.GetAll().Where(x => x.UserId == userId).Select(y=>y.FollowUserId).ToList();
            var followFeed = DbSet.Where(x=>followUserIds.Contains(x.Id));

            var feeds = myFeed.Union(followFeed);


            var getFeeds = DbSet.Where(x=>x.UserId==userId).Include("User");
            return getFeeds;
        }
    }
}
