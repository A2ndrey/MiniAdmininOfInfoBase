using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics; //Process
using System.IO; // StreamReader

namespace OneC_Class
{
    class OneCExecuteCommand
    {
        public string OneCComandName, inputFile, outputFile, OneC_Path, username = "", password = "";

        public string OnecExecute()
        {
            string oneC_key = "", MyExecuteCommand;
            // bool result = true;
            string result = "";

            switch (OneCComandName)
            {
                case "SaveDtFromCD":
                    oneC_key = " /DumpIB ";
                    break;
                case "oher":
                    break;
            }

            if (username.Length != 0)
            {
                username = " /N " + username;
            }

            if (password.Length != 0)
            {
                password = " /P " + password;
            }

            inputFile.Replace("\\\\", "\\");
            outputFile.Replace("\"", "\"");

            MyExecuteCommand = "\"" + OneC_Path + "\" CONFIG /F " + inputFile + username + password + oneC_key + outputFile;

            //           Process.Start("cmd", "/c " + MyExecuteCommand); // /k - show command; /c don`t show command

            MyExecuteCommand = "/c " + MyExecuteCommand;

            //ProcessStartInfo processInfo = new ProcessStartInfo();
            //processInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //processInfo.WindowStyle = ProcessWindowStyle.Normal;
            //processInfo.FileName = "cmd.exe";
            //processInfo.WorkingDirectory = MyExecuteCommand;
            //processInfo.Arguments = MyExecuteCommand;
            //Process.Start(processInfo);


            using (Process process = new Process())
            {
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = MyExecuteCommand;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();

                StreamReader reader = process.StandardOutput;
                result = reader.ReadToEnd();

                //process.WaitForExit();
            }

            return result;


        }
    }
}
