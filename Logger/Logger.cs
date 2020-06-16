using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utilities;

namespace Logger
{
    public static class Logger
    {
        static ReaderWriterLockSlim objReaderWriterLockSlim = new ReaderWriterLockSlim();

        public static void FuncOpen(string PageName, string MethodName, params string[] parameters)
        {
            objReaderWriterLockSlim.EnterWriteLock();
            try
            {
                string LogsPath = AppDomain.CurrentDomain.BaseDirectory;
                string baseDir = LogsPath;
                DateTime dateTime = DateTime.Now;
                string Year = dateTime.ToString("yyyy");
                string Month = dateTime.ToString("MMM");
                string LogFileName = dateTime.ToString("dd-MMM-yyyy") + ".txt";
                string LogDirName = CommonObjects.GetCongifValue(ConfigKeys.LogDir);
                string LogFileDirName = CommonObjects.GetCongifValue(ConfigKeys.InformationLogDir);
                string InfoLogFilePath = Path.Combine(baseDir, LogDirName, LogFileDirName, Year, Month, LogFileName);

                if (!Directory.Exists(baseDir))
                    Directory.CreateDirectory(baseDir);
                if (!Directory.Exists(Path.Combine(baseDir, LogDirName)))
                    Directory.CreateDirectory(Path.Combine(baseDir, LogDirName));
                if (!Directory.Exists(Path.Combine(baseDir, LogDirName, LogFileDirName)))
                    Directory.CreateDirectory(Path.Combine(baseDir, LogDirName, LogFileDirName));
                if (!Directory.Exists(Path.Combine(baseDir, LogDirName, LogFileDirName, Year)))
                    Directory.CreateDirectory(Path.Combine(baseDir, LogDirName, LogFileDirName, Year));
                if (!Directory.Exists(Path.Combine(baseDir, LogDirName, LogFileDirName, Year, Month)))
                    Directory.CreateDirectory(Path.Combine(baseDir, LogDirName, LogFileDirName, Year, Month));
                if (File.Exists(InfoLogFilePath))
                {
                    RemoveFileReadOnly(InfoLogFilePath);
                    using (StreamWriter writer = new StreamWriter(InfoLogFilePath, true))
                    {
                        writer.WriteLine("-------------------Function Open-------------" + DateTime.Now);
                        string parametersLine = string.Empty;
                        foreach (string dict in parameters)
                        {
                            parametersLine = parametersLine + "  " + dict;
                        }
                        if (!string.IsNullOrEmpty(parametersLine))
                        {
                            writer.WriteLine("ClassName : " + PageName + " MethodName " + MethodName + " Parameters : " + parametersLine);
                        }
                        else
                        {
                            writer.WriteLine("ClassName : " + PageName + " MethodName " + MethodName);
                        }
                    }
                }
                else
                {
                    StreamWriter writer = File.CreateText(InfoLogFilePath);
                    writer.WriteLine("-------------------Function Open-------------" + DateTime.Now);
                    string parametersLine = string.Empty;
                    foreach (string dict in parameters)
                    {
                        parametersLine = parametersLine + "  " + dict;
                    }
                    if (!string.IsNullOrEmpty(parametersLine))
                    {
                        writer.WriteLine("ClassName : " + PageName + " MethodName " + MethodName + " Parameters : " + parametersLine);
                    }
                    else
                    {
                        writer.WriteLine("ClassName : " + PageName + " MethodName " + MethodName);
                    }
                    writer.Close();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                objReaderWriterLockSlim.ExitWriteLock();
            }
        }

        public static void Information(string PageName, string MethodName, params string[] parameters)
        {
            objReaderWriterLockSlim.EnterWriteLock();
            try
            {
                string LogsPath = AppDomain.CurrentDomain.BaseDirectory;
                string baseDir = LogsPath;
                DateTime dateTime = DateTime.Now;
                string Year = dateTime.ToString("yyyy");
                string Month = dateTime.ToString("MMM");
                string LogFileName = dateTime.ToString("dd-MMM-yyyy") + ".txt";
                string LogDirName = CommonObjects.GetCongifValue(ConfigKeys.LogDir);
                string LogFileDirName = CommonObjects.GetCongifValue(ConfigKeys.InformationLogDir);
                string InfoLogFilePath = Path.Combine(baseDir, LogDirName, LogFileDirName, Year, Month, LogFileName);

                if (!Directory.Exists(baseDir))
                    Directory.CreateDirectory(baseDir);
                if (!Directory.Exists(Path.Combine(baseDir, LogDirName)))
                    Directory.CreateDirectory(Path.Combine(baseDir, LogDirName));
                if (!Directory.Exists(Path.Combine(baseDir, LogDirName, LogFileDirName)))
                    Directory.CreateDirectory(Path.Combine(baseDir, LogDirName, LogFileDirName));
                if (!Directory.Exists(Path.Combine(baseDir, LogDirName, LogFileDirName, Year)))
                    Directory.CreateDirectory(Path.Combine(baseDir, LogDirName, LogFileDirName, Year));
                if (!Directory.Exists(Path.Combine(baseDir, LogDirName, LogFileDirName, Year, Month)))
                    Directory.CreateDirectory(Path.Combine(baseDir, LogDirName, LogFileDirName, Year, Month));
                if (File.Exists(InfoLogFilePath))
                {
                    RemoveFileReadOnly(InfoLogFilePath);
                    using (StreamWriter writer = new StreamWriter(InfoLogFilePath, true))
                    {
                        string parametersLine = string.Empty;
                        foreach (string dict in parameters)
                        {
                            parametersLine = parametersLine + "  " + dict;
                        }
                        if (!string.IsNullOrEmpty(parametersLine))
                        {
                            writer.WriteLine("ClassName : " + PageName + " MethodName " + MethodName + " Information " + "Parameters : " + parametersLine);
                        }
                    }
                }
                else
                {
                    StreamWriter writer = File.CreateText(InfoLogFilePath);
                    string parametersLine = string.Empty;
                    foreach (string dict in parameters)
                    {
                        parametersLine = parametersLine + "  " + dict;
                    }
                    if (string.IsNullOrEmpty(parametersLine))
                    {
                        writer.WriteLine("ClassName : " + PageName + " MethodName " + MethodName + " Information " + "Parameters : " + parametersLine);
                    }
                    writer.Close();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                objReaderWriterLockSlim.ExitWriteLock();
            }
        }

        public static void FuncClose(string PageName, string MethodName)
        {
            objReaderWriterLockSlim.EnterWriteLock();
            try
            {
                string LogsPath = AppDomain.CurrentDomain.BaseDirectory;
                string baseDir = LogsPath;
                DateTime dateTime = DateTime.Now;
                string Year = dateTime.ToString("yyyy");
                string Month = dateTime.ToString("MMM");
                string LogFileName = dateTime.ToString("dd-MMM-yyyy") + ".txt";
                string LogDirName = CommonObjects.GetCongifValue(ConfigKeys.LogDir);
                string LogFileDirName = CommonObjects.GetCongifValue(ConfigKeys.InformationLogDir);
                string InfoLogFilePath = Path.Combine(baseDir, LogDirName, LogFileDirName, Year, Month, LogFileName);

                if (!Directory.Exists(baseDir))
                    Directory.CreateDirectory(baseDir);
                if (!Directory.Exists(Path.Combine(baseDir, LogDirName)))
                    Directory.CreateDirectory(Path.Combine(baseDir, LogDirName));
                if (!Directory.Exists(Path.Combine(baseDir, LogDirName, LogFileDirName)))
                    Directory.CreateDirectory(Path.Combine(baseDir, LogDirName, LogFileDirName));
                if (!Directory.Exists(Path.Combine(baseDir, LogDirName, LogFileDirName, Year)))
                    Directory.CreateDirectory(Path.Combine(baseDir, LogDirName, LogFileDirName, Year));
                if (!Directory.Exists(Path.Combine(baseDir, LogDirName, LogFileDirName, Year, Month)))
                    Directory.CreateDirectory(Path.Combine(baseDir, LogDirName, LogFileDirName, Year, Month));
                if (File.Exists(InfoLogFilePath))
                {
                    RemoveFileReadOnly(InfoLogFilePath);
                    using (StreamWriter writer = new StreamWriter(InfoLogFilePath, true))
                    {
                        writer.WriteLine("ClassName : " + PageName + " MethodName " + MethodName);
                        writer.WriteLine("-------------------Function Close-------------" + DateTime.Now);
                    }
                }
                else
                {
                    StreamWriter writer = File.CreateText(InfoLogFilePath);
                    writer.WriteLine("ClassName : " + PageName + " MethodName " + MethodName);
                    writer.WriteLine("-------------------Function Close-------------" + DateTime.Now);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                objReaderWriterLockSlim.ExitWriteLock();
            }
        }

        public static void WriteErrorLog(string PageName, string MethodName, Exception exception)
        {
            objReaderWriterLockSlim.EnterWriteLock();
            try
            {
                string LogsPath = AppDomain.CurrentDomain.BaseDirectory;
                string baseDir = LogsPath;
                DateTime dateTime = DateTime.Now;
                string Year = dateTime.ToString("yyyy");
                string Month = dateTime.ToString("MMM");
                string LogFileName = dateTime.ToString("dd-MMM-yyyy") + ".txt";
                string LogDirName = CommonObjects.GetCongifValue(ConfigKeys.LogDir);
                string LogFileDirName = CommonObjects.GetCongifValue(ConfigKeys.ErrorLogDir);
                string ErrorLogFilePath = Path.Combine(baseDir, LogDirName, LogFileDirName, Year, Month, LogFileName);

                if (!Directory.Exists(baseDir))
                    Directory.CreateDirectory(baseDir);
                if (!Directory.Exists(Path.Combine(baseDir, LogDirName)))
                    Directory.CreateDirectory(Path.Combine(baseDir, LogDirName));
                if (!Directory.Exists(Path.Combine(baseDir, LogDirName, LogFileDirName)))
                    Directory.CreateDirectory(Path.Combine(baseDir, LogDirName, LogFileDirName));
                if (!Directory.Exists(Path.Combine(baseDir, LogDirName, LogFileDirName, Year)))
                    Directory.CreateDirectory(Path.Combine(baseDir, LogDirName, LogFileDirName, Year));
                if (!Directory.Exists(Path.Combine(baseDir, LogDirName, LogFileDirName, Year, Month)))
                    Directory.CreateDirectory(Path.Combine(baseDir, LogDirName, LogFileDirName, Year, Month));
                if (File.Exists(ErrorLogFilePath))
                {
                    RemoveFileReadOnly(ErrorLogFilePath);
                    using (StreamWriter writer = new StreamWriter(ErrorLogFilePath, true))
                    {
                        writer.WriteLine("-------------------START-------------" + DateTime.Now);
                        writer.WriteLine("ClassName : " + PageName + " MethodName " + MethodName);
                        writer.WriteLine("Error Message: " + exception.Message);
                        writer.WriteLine("Error Stack Trace: " + exception.StackTrace);
                        writer.WriteLine("-------------------END-------------" + DateTime.Now);
                    }
                }
                else
                {
                    StreamWriter writer = File.CreateText(ErrorLogFilePath);
                    writer.WriteLine("-------------------START-------------" + DateTime.Now);
                    writer.WriteLine("ClassName : " + PageName + " MethodName " + MethodName);
                    writer.WriteLine("Error Message: " + exception.Message);
                    writer.WriteLine("Error Stack Trace: " + exception.StackTrace);
                    writer.WriteLine("-------------------END-------------" + DateTime.Now);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                objReaderWriterLockSlim.ExitWriteLock();
            }
        }

        public static void RemoveFileReadOnly(string FilePath)
        {
            if (IsFileReadOnly(FilePath))
            {
                FileAttributes Attributes = File.GetAttributes(FilePath);
                Attributes = RemoveFileAttribute(Attributes, FileAttributes.ReadOnly);
                File.SetAttributes(FilePath, Attributes);
            }
        }

        public static bool IsFileReadOnly(string FilePath)
        {
            return (File.GetAttributes(FilePath) & FileAttributes.ReadOnly) ==
                    FileAttributes.ReadOnly;
        }

        private static FileAttributes RemoveFileAttribute(FileAttributes Attributes, FileAttributes AttributeToRemove)
        {
            return Attributes & ~AttributeToRemove;
        }
    }
}
