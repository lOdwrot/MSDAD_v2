using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CommonTypes
{
    public class ServiceCreator
    {
        private static string CLIENT_EXECUTABLE_PATH = "../../../WindowsFormsApp1/bin/Debug/Client.exe";
        public String createClientInstance(String args)
        {
            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = CLIENT_EXECUTABLE_PATH,
                        Arguments = args,
                        UseShellExecute = false,
                        RedirectStandardOutput = false,
                        CreateNoWindow = false
                    }
                };

                process.Start();
                return "OK";
            }
            catch (Exception err)
            {
                return err.Message;
            } 
        }
    }
}
