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

        public IEnumerable<Post> Get(int orgId, int badge)
        {
            using (CopProjectDBEntities entities = new CopProjectDBEntities())
            {
                int id;

                id = entities.Users.FirstOrDefault(obj => obj.Badge == badge && obj.OrgID == orgId).UserID;
                entities.Configuration.ProxyCreationEnabled = false;
                var posts = entities.Posts.Where(j => j.UserId == id).ToList();
                foreach( var p in posts)
                {
                    p.User = null;
                }
                return posts;
             }


        }
    }
}
