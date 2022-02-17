using System;
using System.Collections.Generic;
using System.Text;
using BETShop.Application.Common.Interfaces.Configuration;

namespace BETShop.Infrastructure.Configuration
{
    public class MongoDatabaseConfiguration : IDatabaseConfiguration
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
