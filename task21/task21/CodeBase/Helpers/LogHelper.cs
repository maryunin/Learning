using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Composing;
using CodeBase;


/// <summary>
/// TODO: log4newt,serilog others logging system
/// </summary>
namespace CodeBase.Helpers
{
   public  class LogHelper:ILogHelper
    {
        public string AddLog<T>(string message, Exception ex = null, int level = 0) 
        {
            return "";
        }
    }

    public interface ILogHelper
    {
            string AddLog<T>(string message, Exception ex = null, int level = 0);
    }
}
