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
    public class FavoriteController : ApiBaseController
    {

        public FavoriteController(IUnitOfWork uow)
        {
            Uow = uow;
        }

        // GET api/favorite
        public IEnumerable<Favorite> Get(string token)
        {
            var user = Uow.Users.GetUserInfoByToken(token).FirstOrDefault();
            if (user == null)
                return null;

            loginUserId = user.UserInfoId;
            //My Favorites
            var myFavorite = Uow.Favorites.GetAll().Where(x => x.UserId == loginUserId).Include("Feed").ToList(); ;
            return myFavorite;
        }

        // GET api/favorite/5
        public Favorite Get(int id)
        {
            var favorite = Uow.Favorites.GetById("favorite", id);
            if (favorite != null) return favorite;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        // POST api/favorite
        public HttpResponseMessage Post(Favorite favorite)
        {
            Uow.Favorites.Add(favorite);
            Uow.Commit();

            var response = Request.CreateResponse(HttpStatusCode.Created, favorite);

            // Compose location header that tells how to get this session
            // e.g. ~/api/favorite/5
            response.Headers.Location =
                new Uri(Url.Link(WebApiConfig.ControllerAndId, new { id = favorite.Id }));

            return response;
        }

        // PUT api/favorite/5
        public HttpResponseMessage Put(int id, Favorite favorite)
        {
            favorite.Id = id;
            Uow.Favorites.Update(favorite);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE api/favorite/5
        public HttpResponseMessage Delete(int id)
        {
            Uow.Favorites.Delete("favorite", id);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}