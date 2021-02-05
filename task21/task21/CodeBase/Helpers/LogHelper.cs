using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Composing;
using CodeBase;
using Serilog;

/// <summary>
/// TODO: log4newt,serilog others logging system
/// </summary>
namespace CodeBase.Helpers
{
   public  class LogHelper:ILogHelper
    {
        public string AddLog<T>(string message, Exception ex = null, int level = 0) 
        {
            if (level > 0)
                Current.Logger.Error(typeof(LogHelper), ex, message);
            else if (level == 0)
                Current.Logger.Warn(typeof(LogHelper), message);
            else if (level < 0)
                Current.Logger.Info(typeof(LogHelper), message);
            return "";
        }
    }

    public interface ILogHelper
    {
        string AddLog<T>(string message, Exception ex = null, int level = 0);
               
    }
}
