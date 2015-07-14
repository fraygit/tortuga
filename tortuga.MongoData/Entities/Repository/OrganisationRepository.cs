using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tortuga.MongoData.Entities.Interface;
using tortuga.MongoData.Entities.Model;
using tortuga.MongoData.Entities.Service;

namespace tortuga.MongoData.Entities.Repository
{
    public class OrganisationRepository : EntityService<Organisation>, IOrganisationRepository
    {
        public async Task<Organisation> GetOrganisation(string organisationName, string username)
        {
            var builder = Builders<Organisation>.Filter;
            var filter = builder.Eq("Name", organisationName) & builder.Eq("Users", username);
            var organisations = await this.ConnectionHandler.MongoCollection.Find(filter).FirstOrDefaultAsync();
            return organisations;
        }

        public async Task<List<Organisation>> GetOrganisations(string username)
        {
            var builder = Builders<Organisation>.Filter;
            var filter = builder.Eq("Users", username);
            var organisations = await this.ConnectionHandler.MongoCollection.Find(filter).ToListAsync();
            return organisations;
        }
    }
}
