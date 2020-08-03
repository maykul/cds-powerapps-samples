using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerApps.Samples
{
    public static class ErrorLog
    {

        public static void Logger(string ErrorCode, string ErrorMsg)
        {
            try
            {
                string path = Directory.GetCurrentDirectory();
                path = path + "\\Logs\\";

                // check if directory exists
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path = path + DateTime.Today.ToString("dd-MMM-yy") + ".log";
                // check if file exist
                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                }
                // log the error now
                using (StreamWriter writer = File.AppendText(path))
                {
                    string error = "\n" + DateTime.Now.ToString() + ": " + ErrorCode + ": " + ErrorMsg;
                    writer.WriteLine(error);
                    writer.Flush();
                    writer.Close();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}