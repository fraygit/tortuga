﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tortuga.MongoData.Entities.Base
{
    public interface IMongoEntity
    {
        ObjectId Id { get; set; }
    }
}
