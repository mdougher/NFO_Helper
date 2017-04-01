using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace NFO_Helper
{
    class Exporter
    {
        static public IList<string> export(NFO nfo, string scheme, Image img)
        {
            // replace tags in the scheme.
            if(nfo.getProperty(NFOConstants.Title) != null && scheme.Contains("{title}") == true )
            {
                // we need to sanitize titles that come in!
                string replacement = nfo.getProperty(NFOConstants.Title).ToString();
                foreach (var c in Path.GetInvalidFileNameChars())
                {
                    replacement = replacement.Replace(c, '-');
                }
                scheme = scheme.Replace("{title}", replacement);
            }
            if(nfo.getProperty(NFOConstants.Year) != null && scheme.Contains("{year}") == true )
            {
                scheme = scheme.Replace("{year}", nfo.getProperty(NFOConstants.Year).ToString());
            }
            if(nfo.getProperty(NFOConstants.Id) != null && scheme.Contains("{id}") == true )
            {
                scheme = scheme.Replace("{id}", nfo.getProperty(NFOConstants.Id).ToString());
            }
            List<string> filesWritten = new List<string>();

            // first save the nfo file.
            string nfoFile = scheme;
            nfoFile = nfoFile.Replace("{extension}", "nfo");
            string nfoPath = Path.GetDirectoryName(nfoFile);
            if( String.IsNullOrEmpty(nfoPath) == false )
                Directory.CreateDirectory(nfoPath);
            File.WriteAllText(nfoFile, nfo.toXML(true));
            filesWritten.Add(nfoFile);

            // note: if the NFO contains a 'thumb', we do not need to save the image?
            bool isThumb = String.IsNullOrEmpty((string)nfo.getProperty(NFOConstants.Thumb)) == false;
            if (isThumb == false)
            {
                string imgFile = scheme;
                imgFile = imgFile.Replace("{extension}", "jpg");
                string imgPath = Path.GetDirectoryName(imgFile);
                if (String.IsNullOrEmpty(imgPath) == false)
                    Directory.CreateDirectory(imgPath);
                img.Save(imgFile);
                filesWritten.Add(imgFile);
            }

            return filesWritten;
        }
    }
}
