using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningExperience.Models
{
    public interface IMongoDbSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
        string Host { get; set; }
        int Port { get; set; }
        string User { get; set; }
        string Password { get; set; }
    }
}
