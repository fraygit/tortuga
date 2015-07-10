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

    }
}
