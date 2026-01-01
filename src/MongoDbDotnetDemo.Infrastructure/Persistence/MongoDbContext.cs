using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDbDotnetDemo.Infrastructure.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbDotnetDemo.Infrastructure.Persistence
{
    public sealed class MongoDbContext
    {
        public IMongoDatabase Database
        {
            get;
        }

        public MongoDbContext(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            Database = client.GetDatabase(settings.Value.DatabaseName);
        }
    }
}
