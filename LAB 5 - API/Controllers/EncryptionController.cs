using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LAB_5___API.Controllers
{
    [Route("api")]
    [ApiController]
    public class EncryptionController : ControllerBase
    {
        private IWebHostEnvironment environment;
        public EncryptionController(IWebHostEnvironment env)
        {
            environment = env;
        }

        [HttpGet]
        public string Index()
        {
            string text = "\t\t\t- LAB 5 -\n\nKevin Romero 1047519\nJosé De León 1072619";
            return text;
        }

        [HttpPost("cipher/{method}")]
        public ActionResult CompressFile([FromForm] IFormFile file, string method, [FromForm] string key)
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpPost("decipher")]
        public ActionResult DecompressFile([FromForm] IFormFile file)
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("encrypted")]
        public IEnumerable<FileManage> GetEncrypted()
        {
            List<FileManage> list = new List<FileManage>();
            return list;
        }
    }
}
