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
        Task<Organisation> GetOrganisation(string organisationName, string username);
        Task<List<Organisation>> GetOrganisations(string username);
    }
}
