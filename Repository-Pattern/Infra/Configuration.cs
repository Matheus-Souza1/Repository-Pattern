using Microsoft.Extensions.Configuration;
using Repository_Pattern.Infra.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository_Pattern.Infra
{
    public class Configuration : IInfraConfiguration
    {
        private readonly IConfiguration _configuration;

        public Configuration(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string ConnectionString => _configuration.GetConnectionString("stringConnection");
    }
}
