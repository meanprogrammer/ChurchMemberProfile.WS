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
    public class PropertyValController : ApiController
    {
        MemberProfilePropertyRepository repository = new MemberProfilePropertyRepository();
        // GET api/propertyval
        public IEnumerable<MemberProfilePropertyValue> Get(int parentId)
        {
            repository = new MemberProfilePropertyRepository(parentId);
            return repository.GetAll();
        }

        // GET api/propertyval/5
        public MemberProfilePropertyValue Get(int parentId, int recordId)
        {
            repository = new MemberProfilePropertyRepository(parentId);
            return repository.GetById(recordId);
        }

        // POST api/propertyval
        public void Post([FromBody]MemberProfilePropertyValue value)
        {
            repository.InsertOnSubmit(value);
        }

        // PUT api/propertyval/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/propertyval/5
        public void Delete(int parentId, int id)
        {
            repository = new MemberProfilePropertyRepository(parentId);
            repository.DeleteOnSubmit(id);
        }
    }
}
