using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace NFO_Helper
{
    class NFO_Filter_File
    {
        public string fileName { get; set; }
        public NFO_Filter filter { get; set; }

        public NFO_Filter_File()
        {
            filter = new NFO_Filter();
        }

        public bool parseFile(string filename)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    String line = sr.ReadToEndAsync().Result;
                    filter = JsonConvert.DeserializeObject<NFO_Filter>(line);
                }
            }
            catch (JsonException ex)
            {
                throw new NfoReadWriteException("Json Exception: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new NfoReadWriteException("Failed to read text: " + ex.Message);
            }
            return true;
        }
        public bool writeFile(string filename)
        {
            string output = "";
            try
            {
                output = JsonConvert.SerializeObject(filter);
            }
            catch (JsonException ex)
            {
                throw new NfoReadWriteException("Json Exception: " + ex.Message);
            }

            if (String.IsNullOrEmpty(output) == true)
            {
                throw new NfoReadWriteException("Invalid output string! Cannot write to file.");
            }

            try
            {
                System.IO.File.WriteAllText(filename, output);
            }
            catch(Exception ex)
            {
                throw new NfoReadWriteException("WriteAllText threw exception: " + ex.Message);
            }
            return true;
        }
    }
}
