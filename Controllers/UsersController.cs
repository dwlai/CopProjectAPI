using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PostsDataAccess;

namespace CopProjectAPI.Controllers
{
    public class UsersController : ApiController
    {
        public IEnumerable<User> Get()
        {
            using (CopProjectDBEntities entities = new CopProjectDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.Users.ToList();
            }

        }

        public User Get(int orgId, int badge)
        {
            using (CopProjectDBEntities entities = new CopProjectDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.Users.FirstOrDefault(obj => obj.Badge == badge && obj.OrgID == orgId);
            }

        }
    }
}
