using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PostsDataAccess;

namespace CopProjectAPI.Controllers
{
    public class PostsController : ApiController
    {
        public IEnumerable<Post> Get()
        {
            using (CopProjectDBEntities entities = new CopProjectDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.Posts.ToList();
            }

        }
    }
}
