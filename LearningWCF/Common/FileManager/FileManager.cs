// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Configuration;
using System.Reflection;

namespace FileManager
{
    public class FileUploadUtil
    {
        public void SaveFile(string filename, byte[] data)
        {
            FileStream fs = null;
            
            string fileUploadDir = ConfigurationManager.AppSettings["fileUploadDir"];

            if (String.IsNullOrEmpty(fileUploadDir))
                throw new ConfigurationErrorsException("Required application setting is missing: fileUploadDir");

            DirectoryInfo dirInfo = new DirectoryInfo(fileUploadDir);
            if (!dirInfo.Exists)
                throw new ConfigurationErrorsException("Application setting is invalid: fileUploadDir");

            // TODO: what if filename exists already?

            using (fs = new FileStream(String.Format("{0}\\{1}", fileUploadDir, filename), FileMode.Create, FileAccess.Write, FileShare.None))
            {
                int len = data.Length;
                int pos = 0;
                if (len > int.MaxValue)
                {
                    fs.Write(data, pos, int.MaxValue);
                    pos += int.MaxValue;
                    len -= int.MaxValue;
                }
                fs.Write(data, pos, len);

            }
        }


        public byte[] GetFile(string filename)
        {
            FileStream fs = null;
            byte[] data = null;

            string fileUploadDir = System.Configuration.ConfigurationManager.AppSettings["fileUploadDir"];
            // TODO: what if directory missing?
            // TODO: what if file doesn't exist?

            using (fs = new FileStream(String.Format("{0}\\{1}", fileUploadDir, filename), FileMode.Open, FileAccess.Read, FileShare.Read))
            {

                data = new byte[fs.Length];
                int len = data.Length;
                int pos = 0;
                if (len > int.MaxValue)
                {
                    fs.Read(data, pos, int.MaxValue);
                    pos += int.MaxValue;
                    len -= int.MaxValue;
                }
                fs.Read(data, pos, len);
            }
            return data;
        }
    }
}
