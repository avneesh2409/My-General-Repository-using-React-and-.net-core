using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRepository.Utilities
{
    public class AppSettings
    {
        public const string Settings = "AppSettings";
        public string DbConnect { get; set; }
        public string JwtKey { get; set; }
        public string JwtIssuer { get; set; }
        public string JwtAudience { get; set; }
    }
}
