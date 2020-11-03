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
        public ActionResult EncryptTest([FromForm] CipherInput input, string method)
        {
            try
            {
                string file_path = environment.ContentRootPath;
                string file_name = input.File.FileName;

                FileManage file_manager = new FileManage();
                file_manager.SaveFile(input.File, file_path, file_name);
                file_manager.EncryptFile(file_path, file_name, method, input.Key);
                file_manager.DeleteFile(file_path, file_name);

                FileStream result = new FileStream(file_manager.EncryptedFilePath, FileMode.Open);
                return File(result, "text/plain", file_manager.EncryptedFileName);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

            [HttpPost("decipher")]
        public ActionResult DecryptFile([FromForm] CipherInput input)
        {
            try
            {
                string file_path = environment.ContentRootPath;
                string file_name = input.File.FileName;

                FileManage file_manager = new FileManage();
                file_manager.SaveFile(input.File, file_path, file_name);
                file_manager.DecryptFile(file_path, file_name, input.Key);
                file_manager.DeleteFile(file_path, file_name);

                FileStream result = new FileStream(file_manager.DecryptedFilePath, FileMode.Open);
                return File(result, "text/plain", file_manager.DecryptedFileName);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

    }
}
