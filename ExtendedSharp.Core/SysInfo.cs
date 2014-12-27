using System;
using System.Globalization;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security.Principal;
using ExtendedSharp.Core.Extensions;

namespace ExtendedSharp.Core
{
    public static class SysInfo
    {
        public static string GetIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            return host.AddressList.Where(i => i.AddressFamily == AddressFamily.InterNetwork)
                .Select(ip => ip.ToString())
                .ToDelimString(";");
        }

        public static string GetName()
        {
            var user = WindowsIdentity.GetCurrent();
            if (user != null) return user.Name;
            return String.Empty;
        }

        public static string GetUserDomainName()
        {
            return Environment.UserDomainName;
        }

        public static string GetOsVersion()
        {
            return Environment.OSVersion.VersionString;
        }

        public static string GetAntiVirusInfo()
        {
            var wmipathstr = @"\\" + Environment.MachineName + @"\root\SecurityCenter2";
            var searcher = new ManagementObjectSearcher(wmipathstr, "SELECT * FROM AntivirusProduct");
            var instances = searcher.Get();
            return instances.Cast<ManagementBaseObject>()
                .Select(d => d.GetPropertyValue("displayName") + " " + d.GetPropertyValue("productState"))
                .ToDelimString();
        }

        public static string GetMachinName()
        {
            return Environment.MachineName;
        }

        public static string GetMacAddress()
        {
            return
                NetworkInterface.GetAllNetworkInterfaces()
                    .Select(nic => nic.Name + "," + nic.NetworkInterfaceType + "," + nic.GetPhysicalAddress())
                    .ToDelimString(";");
        }

        public static string GetSystemDateTime()
        {
            return DateTime.Now.ToString(CultureInfo.InvariantCulture);
        }

        public static string GetAuthenticationType()
        {
            var user = WindowsIdentity.GetCurrent();
            return user != null ? user.AuthenticationType : null;
        }

        public static bool IsNetworkAvailable()
        {
            return NetworkInterface.GetIsNetworkAvailable();
        }

        public static bool IsInternetAvailabe()
        {
            try
            {
                Dns.GetHostEntry("www.google.com");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsAuthenticated()
        {
            var user = WindowsIdentity.GetCurrent();
            return user != null && user.IsAuthenticated;
        }

        public static bool IsGuest()
        {
            var user = WindowsIdentity.GetCurrent();
            return user != null && user.IsGuest;
        }

        public static bool IsAnonymous()
        {
            var user = WindowsIdentity.GetCurrent();
            return user != null && user.IsAnonymous;
        }
    }
}
