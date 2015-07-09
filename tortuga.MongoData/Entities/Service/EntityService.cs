using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tortuga.MongoData.Entities.Base;

namespace tortuga.MongoData.Entities.Service
{
    public class EntityService<T> : IEntityService<T> where T : IMongoEntity
    {
        protected readonly ConnectionHandler<T> ConnectionHandler;

        public virtual void Create(T entity)
        {
            var result = this.ConnectionHandler.MongoCollection.InsertOneAsync(entity);

        }

        
    }
}
