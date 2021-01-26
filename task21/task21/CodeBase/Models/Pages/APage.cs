using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Web;
namespace CodeBase.Models
{
    public partial class APage
    {
        public Site GetCurrentSite()
        {
            //Debugger.Launch();
            var r = this.Ancestor<Site>();
            return r;
        }
    }
}
