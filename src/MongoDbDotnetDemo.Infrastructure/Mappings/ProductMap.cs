using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDbDotnetDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbDotnetDemo.Infrastructure.Mappings
{
    public class ProductMap
    {
        public static void Register()
        {
            if (BsonClassMap.IsClassMapRegistered(typeof(Product)))
                return;

            BsonClassMap.RegisterClassMap<Product>(cm =>
            {
                cm.AutoMap();

                cm.MapIdMember(p => p.Id)
                  .SetIdGenerator(StringObjectIdGenerator.Instance)
                  .SetSerializer(
                      new MongoDB.Bson.Serialization.Serializers.StringSerializer(BsonType.ObjectId)
                  );
            });
        }
    }
}
