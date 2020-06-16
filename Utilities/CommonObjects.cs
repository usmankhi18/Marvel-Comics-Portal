
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Threading;

namespace Utilities
{
    public class CommonObjects
    {
        public static string GetCongifValue(string ConfigKey)
        {
            return ConfigurationManager.AppSettings[ConfigKey].ToString();
        }

        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings[GenericConstants.ConnectionStringKey].ConnectionString;
        }

        public static void CreateMonthYearImages(string CitizenID)
        {
            ReaderWriterLockSlim objReaderWriterLockSlim = new ReaderWriterLockSlim();
            objReaderWriterLockSlim.EnterWriteLock();
            try
            {
                string baseLocalDir = AppDomain.CurrentDomain.BaseDirectory;
                string CreateLocalFolder = FolderPaths.LocalImages;
                DateTime dateTime = DateTime.Now;
                string Year = dateTime.ToString("yyyy");
                string Month = dateTime.ToString("MMM");
                string ErrorLogLocalFilePath = Path.Combine(baseLocalDir, CreateLocalFolder, Year, Month);

                if (!Directory.Exists(Path.Combine(baseLocalDir, CreateLocalFolder, Year)))
                    Directory.CreateDirectory(Path.Combine(baseLocalDir, CreateLocalFolder, Year));
                if (!Directory.Exists(Path.Combine(baseLocalDir, CreateLocalFolder, Year, Month)))
                    Directory.CreateDirectory(Path.Combine(baseLocalDir, CreateLocalFolder, Year, Month));
                if (!Directory.Exists(Path.Combine(baseLocalDir, CreateLocalFolder, Year, Month, CitizenID)))
                    Directory.CreateDirectory(Path.Combine(baseLocalDir, CreateLocalFolder, Year,Month, CitizenID));

            }
            catch (Exception ex)
            {

            }
            finally
            {
                objReaderWriterLockSlim.ExitWriteLock();
            }
        }

    }
}
