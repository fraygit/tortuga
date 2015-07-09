using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tortuga.MongoData.Entities.Base;

namespace tortuga.MongoData.Entities.Service
{
    public interface IEntityService<T> where T : IMongoEntity
    {
        void Create(T entity);
        //T GetById(string id);
    }
}
