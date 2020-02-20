using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AjaxING.ErrorLogging
{
    public sealed class ErrorLogger
    {
        private static ErrorLogger instance = null;
        private static readonly object padlock = new object();

        private ErrorLogger()
        {
        }

        public static ErrorLogger Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ErrorLogger();
                    }
                    return instance;
                }
            }
        }

        public  static void LogError(Exception ex)
        {
            DBEntities dBEntities = new DBEntities();
            ErrorLog objErrorLog = new ErrorLog();
            objErrorLog.ErrorDescription = ex.StackTrace;
            dBEntities.ErrorLogs.Add(objErrorLog);
            dBEntities.SaveChanges();
        }
    }
}