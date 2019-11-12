using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CommonTypes
{
    public class ServiceCreator : MarshalByRefObject
    {
        private static string CLIENT_EXECUTABLE_PATH = "../../../WindowsFormsApp1/bin/Debug/Client.exe";
        private static string SERVER_EXECUTABLE_PATH = "../../../Server/bin/Debug/Server.exe";
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
                return "Client created";
            }
            catch (Exception err)
            {
                return err.Message;
            } 
        }

        public String createServerInstance(String args)
        {
            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = SERVER_EXECUTABLE_PATH,
                        Arguments = args,
                        UseShellExecute = false,
                        RedirectStandardOutput = false,
                        CreateNoWindow = false
                    }
                };

                process.Start();
                return "Server Created";
            }
            catch (Exception err)
            {
                return err.Message;
            }
        }
    }
}
