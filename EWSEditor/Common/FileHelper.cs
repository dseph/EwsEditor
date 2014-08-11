using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace EWSEditor.Common
{
    /// <summary>
    /// Set of static utility methods related to file IO
    /// </summary>
    public class FileHelper
    {
        /// <summary>
        /// Take a given string and create a valid file name by replacing
        /// invalid characters with underscores.
        /// </summary>
        /// <param name="data">String to convert.</param>
        /// <returns>Converted file name.</returns>
        public static string SanitizeFileName(string fileName)
        {
            // If data is null, return "_"
            if (fileName == null || fileName == string.Empty)
            {
                return "_";
            }

            // Find and replace all invalid characters with underscores
            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
            {
                fileName = fileName.Replace(c, '_');
            }

            return fileName;
        }

        /// <summary>
        /// Ensure that the given file name will be unique by adding a 
        /// timestamp to the end of the file name if the proposed name 
        /// already exists.
        /// </summary>
        /// <param name="filePath">Proposed full file path</param>
        /// <returns>Unique file path</returns>
        public static string EnsureUniqueFileName(string filePath)
        {
            // If it already exists then add ticks to the end of the file name
            if (System.IO.File.Exists(filePath))
            {
                int i = 1;
                while (System.IO.File.Exists(filePath))
                {
                    string newFileName = string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0}-({1}){2}",
                        Path.GetFileNameWithoutExtension(filePath),
                        i,
                        Path.GetExtension(filePath));

                    if (!System.IO.File.Exists(filePath.Replace(Path.GetFileName(filePath), newFileName)))
                    {
                        filePath = filePath.Replace(Path.GetFileName(filePath), newFileName);
                        break;
                    }
                    i++;
                }
            }

            return filePath;
        }

        /// <summary>
        /// Save the given objects to a file.
        /// </summary>
        /// <param name="filePath">Path to create the file.</param>
        /// <param name="objects">Objects to serialize to the file.</param>
        /// <returns>Path to created file.</returns>
        public static string SerializeObjectToFile(string filePath, object[] objects)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                // If there are multiple objects to write there needs to be
                // a containing tag around them all
                if (objects.Length > 1) {sw.WriteLine("<SerializedObjects>");}

                foreach (object o in objects)
                {
                    XmlSerializer xmlSer = new XmlSerializer(o.GetType());
                    xmlSer.Serialize(sw, o);
                }

                if (objects.Length > 1) { sw.WriteLine("</SerializedObjects>"); }
            }

            return filePath;
        }

        /// <summary>
        /// Serialize the given object to a XML file.
        /// </summary>
        /// <param name="filePath">Path to create the file.</param>
        /// <param name="o">Object to serialize to the file.</param>
        /// <returns>Path to created file.</returns>
        public static string SerializeObjectToFile(string filePath, object o)
        {
            return SerializeObjectToFile(filePath, new object[] {o});
        }

        /// <summary>
        /// Write the passed in data to a temporary XML file and return the path.
        /// </summary>
        /// <param name="data">Data to be written to temp file.</param>
        /// <returns>Path to the temp file created.</returns>
        public static string WriteDataToTempXML(string data)
        {
            string tempFile = Path.GetTempFileName().Replace(".tmp", ".xml");
            
            StreamWriter sw = File.CreateText(tempFile);
            sw.WriteLine(data);
            sw.Close();

            return tempFile;
        }

        /// <summary>
        /// Write the passed in data to a temporary HTML file and return the path.
        /// </summary>
        /// <param name="data">Data to be written to temp file.</param>
        /// <returns>Path to the temp file created.</returns>
        public static string WriteDataToTempHTML(string data)
        {
            string tempFile = Path.GetTempFileName().Replace(".tmp", ".html");
            StreamWriter sw = File.CreateText(tempFile);
            sw.WriteLine(data);
            sw.Close();
            return tempFile;
        }

        // Reads Binary file and turns it into a base64 string.
        public static string GetBinaryFileAsBase64(string sFile)
        {

            FileStream oFileStream = new FileStream(sFile, FileMode.Open, FileAccess.Read);
            BinaryReader oBinaryReader = new BinaryReader(oFileStream);
            byte[] arrByte = oBinaryReader.ReadBytes((int)oFileStream.Length);
            string sData = Convert.ToBase64String(arrByte);
            return sData;
        }
    }
}
