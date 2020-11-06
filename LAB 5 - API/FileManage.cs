using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using LAB_5___Encryption_Algorithms;
using LAB_5___Encryption_Algorithms.Encryption_Algorithms;
using System.Runtime.InteropServices.WindowsRuntime;

namespace LAB_5___API
{
    public class FileManage
    {
        public string EncryptedFilePath { get; set; }
        public string EncryptedFileName { get; set; }
        public string DecryptedFilePath { get; set; }
        public string DecryptedFileName { get; set; }
        public void SaveFile(IFormFile file, string path, string name)
        {
            string file_path = path + $"\\Data\\temporal\\{name}";
            if (File.Exists(file_path))
            {
                File.Delete(file_path);
            }
            using (var fs = new FileStream(file_path, FileMode.OpenOrCreate))
            {
                file.CopyTo(fs);
            }
            return;
        }


        public void DeleteFile(string path, string name)
        {
            string file_path = $"{path}\\Data\\temporal\\{name}";
            File.Delete(file_path);
        }

        public void EncryptFile(string path, string file_name, string algorithm, Key key)
        {
            string[] name = file_name.Split(".");
            string saved_file = path + $"\\Data\\temporal\\{name[0]}.txt";
            byte[] buffer;
            using (FileStream fs = new FileStream(saved_file, FileMode.Open))
            {
                buffer = new byte[fs.Length];
                using (var br = new BinaryReader(fs))
                {
                    br.Read(buffer, 0, (int)fs.Length);
                }
            }
            
            byte[] content;
            string extension;
            switch (algorithm.Trim())
            {
                case "cesar":
                    if (key.Word == null)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        content = new Cesar().EncryptData(buffer, key);
                        extension = ".csr";
                        break;
                    }
                case "zigzag":
                    if (key.Levels < 2)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        content = new ZigZag().EncryptData(buffer, key);
                        extension = ".zz";
                        break;
                    }
                case "ruta":
                    if (key.Rows < 2 && key.Columns < 2)
                    {
                        throw new Exception();
                    }
                    else if (key.Columns < 2)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        content = new Route().EncryptData(buffer, key);
                        extension = ".rt";
                        break;
                    }
                default: throw new Exception();
            }

            string result_path = path + $"\\Data\\ciphers\\{name[0]}{extension}";
            using (var fs = new FileStream(result_path, FileMode.OpenOrCreate))
            {
                fs.Write(content, 0, content.Length);
            }
            EncryptedFilePath = result_path;
            EncryptedFileName = $"{name[0]}{extension}";
        }

        public void DecryptFile(string path, string file_name, Key key)
        {

            byte[] buffer;
            string file_path = path + $"\\Data\\ciphers\\{file_name}";
            using (FileStream fs = new FileStream(file_path, FileMode.OpenOrCreate))
            {
                buffer = new byte[fs.Length];
                using (var br = new BinaryReader(fs))
                {
                    br.Read(buffer, 0, buffer.Length);
                }
            }

            byte[] result;
            string extension = file_name.Split(".")[1];
            switch (extension)
            {
                case "csr":
                    if (key.Word == null)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        result = new Cesar().DecryptData(buffer, key);
                        break;
                    }
                case "zz":
                    if (key.Levels < 2)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        result = new ZigZag().DecryptData(buffer, key);
                        break;
                    }
                case "rt":
                    if (key.Rows < 2 && key.Columns < 2)
                    {
                        throw new Exception();
                    }
                    else if (key.Columns < 2)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        result = new Route().DecryptData(buffer, key);
                        break;
                    }
                default: throw new Exception();
            }


            string[] path_result = path.Split("Data");
            string name = file_name.Split(".")[0];
            string file_result = path_result[0] + $"\\Data\\deciphers\\{name}.txt";
            using (var fs = new FileStream(file_result, FileMode.OpenOrCreate))
            {
                fs.Write(result, 0, result.Length);
            }
            DecryptedFilePath = file_result;
            DecryptedFileName = $"{name}.txt";
        }


        public static byte[] ConvertToByte(string content)
        {
            byte[] array = new byte[content.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Convert.ToByte(content[i]);
            }
            return array;
        }
    }
}
