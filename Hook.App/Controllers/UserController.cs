using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hook.Data.Contracts;
using Hook.Model;
namespace Hook.Controllers
{
    public class UserController : ApiBaseController
    {
        public UserController(IUnitOfWork uow)
        {
            Uow = uow;
        }

        [HttpGet]
        public UserVM  Auth(string userName, string password)
        {
            userName = userName.ToLower();
            
            var objUser = Uow.Users.GetAll().Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();
            if (objUser != null)
            {
                var userInfo = Uow.UserInfos.GetById("user", objUser.UserInfoId);
                UserVM obj = new UserVM();
                obj.Id = userInfo.Id;
                obj.FullName=userInfo.FullName;
                obj.Email=userInfo.Email;
                obj.PhoneNumber=userInfo.PhoneNumber;
                obj.CompanyName=userInfo.CompanyName;
                obj.Information=userInfo.Information;
                obj.Token=objUser.Id.ToString();
                return obj;
            }
            return null;
        }

        // GET api/values
        public IEnumerable<User> Get()
        {
            return Uow.Users.GetAll();
        }

        // GET api/values/5
        public User Get(int id)
        {
            var user = Uow.Users.GetById("user",id);
            if (user != null) return user;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        // POST api/values
        public HttpResponseMessage Post(User user)
        {
            var firstCompanyUser = Uow.Users.GetAll().FirstOrDefault();
            if (user.UserInfo.CompanyName.ToLower() == "comaround")
                user.UserInfo.CompanyName = firstCompanyUser.UserInfo.CompanyName;
            else
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            
            var follow = new Follow();
            Uow.Users.Add(user);
            follow.UserId = user.Id;
            follow.FollowUserId = 1;
            follow.GroupId = 1;
            Uow.Follows.Add(follow);

            Uow.Commit();

            var response = Request.CreateResponse(HttpStatusCode.Created, user);

            // Compose location header that tells how to get this session
            // e.g. ~/api/feed1/5
            response.Headers.Location =
                new Uri(Url.Link(WebApiConfig.ControllerAndId, new { id = user.Id }));

            return response;
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, User user)
        {
            user.Id = id;
            Uow.Users.Update(user);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            Uow.Users.Delete("user",id);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
    public class UserVM:UserInfo
    {
        public string Token { get; set; }
    }
}