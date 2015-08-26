using ChurchMemberProfile.WS.Data;
using ChurchMemberProfile.WS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChurchMemberProfile.WS.Api.Controllers
{
    public class MemberProfileController : ApiController
    {
        MemberProfileRepository repository = new MemberProfileRepository();

        // GET: api/MemberProfile
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/MemberProfile/5
        public MemberProfile Get(int id)
        {
            return repository.GetById(id);
        }

        // POST: api/MemberProfile
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MemberProfile/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MemberProfile/5
        public void Delete(int id)
        {
        }
    }
}
