using System.Web.Http;
using Hook.Data.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using Hook.Model;

namespace Hook.Controllers
{
    [AllowCrossSiteJson]
    public class ApiBaseController : ApiController
    {
        public int loginUserId { get; set; }
        public IUnitOfWork Uow { get; set; }

        protected User TokenHeaderProcessing()
        {
            IEnumerable<string> headerValues = Request.Headers.GetValues("X-Token-Header");
            var token = headerValues.FirstOrDefault();

            var user = Uow.Users.GetUserInfoByToken(token).FirstOrDefault();
            return user;
        }
    }
}
