using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace wm_psn_enabled
{
    internal class Program
    {
        
        public static void deleteFile(string path)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(path);
            request.Method = WebRequestMethods.Ftp.DeleteFile;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            response.Close();
        }
        public static void rebootConsole(string ps3_ip)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://" + ps3_ip+ "/reboot.ps3");
            request.MaximumAutomaticRedirections = 4;
            request.MaximumResponseHeadersLength = 4;
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            response.Close();

        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("This is a small program to remove the webman plugin that blocks access to PSN by default, your console will restart automatically upon success.");
            Console.WriteLine("Please enter your console IP:");
            string console_ip = Console.ReadLine();
            deleteFile("ftp://" + console_ip +"/dev_hdd0/tmp/wm_res/npsignin_plugin.rco");
            Console.WriteLine("Plugin has been deleted your console will reboot");
            rebootConsole(console_ip);
            // I know this is ugly, but i fucking hate error handlings in c#, if it works, console reboots, if it doesnt, the program shit itself :DD
            
        }
    }
}
