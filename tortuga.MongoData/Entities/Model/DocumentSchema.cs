using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tortuga.MongoData.Entities.Base;

namespace tortuga.MongoData.Entities.Model
{
    public class DocumentSchema : MongoEntity
    {
        public String Name { get; set; }
        public List<Field> Fields { get; set; }
    }

    public class Field
    {
        public String Name { get; set; }
        public DataType DataType { get; set; }
        public Guid FieldGuid { get; set; }
        public List<Field> Fields { get; set; }
    }

    public enum DataType
    {
        String = 0,
        Number = 1,
        Document = 3
    }
}
