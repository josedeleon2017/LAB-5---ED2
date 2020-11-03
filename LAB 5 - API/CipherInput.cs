using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace LAB_5___API
{
    public class CipherInput
    {
        public IFormFile File { get; set; }
        public Key Key { get; set; }
    }

}
