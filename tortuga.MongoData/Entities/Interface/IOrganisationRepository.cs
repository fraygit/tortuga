using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tortuga.MongoData.Entities.Model;
using tortuga.MongoData.Entities.Service;

namespace tortuga.MongoData.Entities.Interface
{
    public interface IOrganisationRepository : IEntityService<Organisation>
    {
        Task<Organisation> GetOrganisationByUserName(string organisationName, string username);
    }
}
