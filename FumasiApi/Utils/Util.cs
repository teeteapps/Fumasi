using Bmat.Tools;
using FumasiApi.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FumasiApi.Utils
{
    public class Util
    {
        public static IConfigurationRoot Configuration { get; set; }

        public static string GetDbConnString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            Configuration = builder.Build();
            if (string.IsNullOrEmpty(AppData.DbConnectionString))
            {
                string connId = Configuration["DbConnData:Id"];
                string connKey = Configuration["DbConnData:Key"];
                string connData = Configuration["DbConnData:Data"];

                ConnectionManager conMan = new ConnectionManager();
                string connString = conMan.GetConnectionString(connData, connId, connKey);

                AppData.DbConnectionString = connString;

                return connString;
            }
            else
                return AppData.DbConnectionString;

        }

        public static string GetTenantDbConnString(string connId, string connKey, string connData)
        {
            ConnectionManager conMan = new ConnectionManager();
            string connString = conMan.GetConnectionString(connData, connId, connKey);
            return connString;
        }

        public static void LogError(string userName, Exception ex, bool isError = true)
        {
            try
            {
                string logDir = Path.Combine(Directory.GetCurrentDirectory(), "logs");

                //---- Create Directory if it does not exist              
                if (!Directory.Exists(logDir))
                {
                    Directory.CreateDirectory(logDir);
                }
                string logFile = Path.Combine(logDir, "ErrorLog.log");
                //--- Delete log if it more than 500Kb
                if (File.Exists(logFile))
                {
                    FileInfo fi = new FileInfo(logFile);
                    if ((fi.Length / 1000) > 500)
                        fi.Delete();
                }
                //--- Create stream writter
                StreamWriter stream = new StreamWriter(logFile, true);
                stream.WriteLine(string.Format("{0}|{1:dd-MMM-yyyy HH:mm:ss}|{2}|{3}",
                    isError ? "ERROR" : "INFOR",
                    DateTime.Now,
                    userName,
                    isError ? ex.ToString() : ex.Message));
                stream.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static string GetLogFile()
        {
            try
            {
                string logDir = Path.Combine(Directory.GetCurrentDirectory(), "logs");

                //---- Create Directory if it does not exist              
                if (!Directory.Exists(logDir))
                {
                    Directory.CreateDirectory(logDir);
                }
                return Path.Combine(logDir, "ErrorLog.log");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static UserDataModel GetCurrentUserData(IEnumerable<ClaimsIdentity> claims)
        {
            string userData = claims.First(u => u.IsAuthenticated && u.HasClaim(c => c.Type == "userData")).FindFirst("userData").Value;
            if (string.IsNullOrEmpty(userData))
                return null;

            return JsonConvert.DeserializeObject<UserDataModel>(userData);
        }
    }

    public class Alert
    {
        public const string TempDataKey = "TempDataAlerts";
        public string AlertStyle { get; set; }
        public string Message { get; set; }
        public bool Dismissable { get; set; }
        public string IconClass { get; set; }
    }

    public static class AlertStyles
    {
        public const string Success = "success";
        public const string Information = "info";
        public const string Warning = "warning";
        public const string Danger = "danger";
    }
}
