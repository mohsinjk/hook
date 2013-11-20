using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using Hook.Data.Contracts;
using Hook.Model;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Hook.Controllers
{
    public class FeedController : ApiBaseController
    {
        public FeedController(IUnitOfWork uow)
        {
            Uow = uow;
        }

        // GET api/feed1
        public IEnumerable<Feed> Get()
        {
            var ii = Uow.Feeds.GetById("feed",4);
            var user = TokenHeaderProcessing();
            if (user == null)
                return null;

            loginUserId = user.UserInfoId;
            //My Feeds
            var myFeed = Uow.Feeds.GetAll().Where(x => x.UserId == loginUserId);

            var followUserIds = new List<int>();
            followUserIds = Uow.Follows.GetAll().Where(x => x.UserId == loginUserId).Select(y => y.FollowUserId).ToList();
            //My follow feeds
            var followFeed = Uow.Feeds.GetAll().Where(x => followUserIds.Contains(x.UserId));

            //Unoin: My feeds and My follow feeds
            var feeds = myFeed.Union(followFeed).OrderByDescending(x => x.MessageDateTime).Include("User").ToList();

            return feeds;
        }

        // GET api/feed1
        [HttpGet]
        public IEnumerable<Feed> GetMyFeed()
        {
            var user = TokenHeaderProcessing();
            if (user == null)
                return null;

            loginUserId = user.UserInfoId;
            //My Feeds
            var myFeed = Uow.Feeds.GetAll().Where(x => x.UserId == loginUserId).OrderByDescending(x => x.MessageDateTime).Include("User").ToList();
            return myFeed;
        }

        [HttpGet]
        public IEnumerable<Feed> GetFavoriteFeed()
        {
            var user = TokenHeaderProcessing();
            if (user == null)
                return null;

            loginUserId = user.UserInfoId;

            var myFavorite = Uow.Favorites.GetAll().Where(x => x.UserId == loginUserId);

            var favoriteFeedIds = new List<int>();
            favoriteFeedIds = Uow.Favorites.GetAll().Where(x => x.UserId == loginUserId).Select(y => y.FeedId).ToList();

            //Favorite Feeds
            var favoriteFeed = Uow.Feeds.GetAll().Where(x => favoriteFeedIds.Contains(x.Id)).OrderByDescending(x => x.MessageDateTime).Include("User").ToList();
            return favoriteFeed;
        }

        // GET api/feed1/5
        public Feed Get(int id)
        {
            var user = TokenHeaderProcessing();
            if (user == null)
                return null;

            var feed = Uow.Feeds.GetById("feed",id);
            if (feed != null) return feed;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        // POST api/feed1
        [HttpPost]
        public HttpResponseMessage Post(Feed feed)
        {
            var user = TokenHeaderProcessing();
            if (user == null)
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);

            var group = Uow.Groups.GetAll().FirstOrDefault(x => x.UserId == user.Id);

            feed.GroupId = group.Id;
            Uow.Feeds.Add(feed);
            Uow.Commit();

            var response = Request.CreateResponse(HttpStatusCode.Created, feed);

            //Compose location header that tells how to get this session
            //e.g. ~/api/feed1/5
            response.Headers.Location = new Uri(Url.Link(WebApiConfig.ControllerAndId, new { id = feed.Id }));

            return response;
        }
        // PUT api/feed1/5
        public HttpResponseMessage Put(int id, Feed feed)
        {
            var user = TokenHeaderProcessing();
            if (user == null)
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);

            feed.Id = id;
            Uow.Feeds.Update(feed);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE api/feed1/5
        public HttpResponseMessage Delete(int id)
        {
            var user = TokenHeaderProcessing();
            if (user == null)
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);

            Uow.Feeds.Delete("feed",id);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}