using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace EndProject.Domain.Arguments.Platform
{
    public class AddPlatformResponse
    {
        public Guid Id { get; set; }
        public string  Nome { get; set; }
        public string Message { get; set; }
    }
}
