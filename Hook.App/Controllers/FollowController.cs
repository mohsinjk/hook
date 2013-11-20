using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using Hook.Data.Contracts;
using Hook.Model;
namespace Hook.Controllers
{
    public class FollowController : ApiBaseController
    {
        public FollowController(IUnitOfWork uow)
        {
            Uow = uow;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Follow> Following()
        {
            var user = TokenHeaderProcessing();
            if (user == null)
                return null;

            loginUserId = user.UserInfoId;
            return Uow.Follows.GetAll().Where(x => x.UserId == loginUserId).Include("FollowUser").ToList();
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Follow> Followers()
        {
            var user = TokenHeaderProcessing();
            if (user == null)
                return null;

            loginUserId = user.UserInfoId;
            return Uow.Follows.GetAll().Where(x => x.FollowUserId == loginUserId).Include("User").ToList();
        }

        // GET api/values/5
        public Follow Get(int id)
        {
            var follow = Uow.Follows.GetById("follow",id);
            if (follow != null) return follow;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        // POST api/values
        [HttpPost]
        public HttpResponseMessage Post(Follow follow)
        {
            var user = TokenHeaderProcessing();
            if (user == null)
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);

            var group = Uow.Groups.GetAll().FirstOrDefault(x => x.UserId == user.Id);
            follow.GroupId = group.Id;
            Uow.Follows.Add(follow);
            Uow.Commit();

            follow.FollowUser = Uow.Users.GetById("follow",follow.FollowUser.Id).UserInfo;

            var response = Request.CreateResponse(HttpStatusCode.Created, follow);

            // Compose location header that tells how to get this session
            // e.g. ~/api/feed1/5
            response.Headers.Location =
                new Uri(Url.Link(WebApiConfig.ControllerAndId, new { id = follow.Id }));

            return response;
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, Follow follow)
        {
            var user = TokenHeaderProcessing();
            if (user == null)
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);

            follow.Id = id;
            Uow.Follows.Update(follow);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            var user = TokenHeaderProcessing();
            if (user == null)
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);

            Uow.Follows.Delete("follow",id);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}