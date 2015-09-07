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
    public class PropertyDefController : ApiController
    {
        PropertyDefinitionRepository repository = new PropertyDefinitionRepository();
        // GET api/propertydef
        public IEnumerable<PropertyTemplateItem> Get()
        {
            return repository.GetAll();
        }

        // GET api/propertydef/5
        public PropertyTemplateItem Get(int id)
        {
            return repository.GetById(id);
        }

        // POST api/propertydef
        public void Post([FromBody]string value)
        {
        }

        // PUT api/propertydef/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/propertydef/5
        public void Delete(int id)
        {
            repository.DeleteOnSubmit(id);
        }
    }
}
