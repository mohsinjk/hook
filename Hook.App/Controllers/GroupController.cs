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
    public class GroupController : ApiBaseController
    {

        public GroupController(IUnitOfWork uow)
        {
            Uow = uow;
        }

        // GET api/group
        public IEnumerable<Group> Get()
        {
            var user = TokenHeaderProcessing();
            if (user == null)
                return null;
            //My Groups
            var myGroup = Uow.Groups.GetAll().Where(x => x.UserId == user.Id).ToList();
            return myGroup;
        }

        // GET api/group/5
        public Group Get(int id)
        {
            var group = Uow.Groups.GetById("group", id);
            if (group != null) return group;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        // POST api/group
        public HttpResponseMessage Post(Group group)
        {
            var user = TokenHeaderProcessing();
            if (user == null)
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);

            Uow.Groups.Add(group);
            Uow.Commit();

            var response = Request.CreateResponse(HttpStatusCode.Created, group);

            // Compose location header that tells how to get this session
            // e.g. ~/api/group/5
            response.Headers.Location =
                new Uri(Url.Link(WebApiConfig.ControllerAndId, new { id = group.Id }));

            return response;
        }

        // PUT api/group/5
        public HttpResponseMessage Put(int id, Group group)
        {
            var user = TokenHeaderProcessing();
            if (user == null)
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);

            group.Id = id;
            Uow.Groups.Update(group);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE api/group/5
        public HttpResponseMessage Delete(int id)
        {
            var user = TokenHeaderProcessing();
            if (user == null)
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);

            Uow.Groups.Delete("group", id);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}