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
        protected virtual Lazy<Site> GetCurrentSite => new Lazy<Site>(() =>
         {
             var r = this.Ancestor<Site>();
             return r;
         });
        public virtual Site CurrentSite => GetCurrentSite.Value;


        public string PageTitle => this.Title;
        
        public string MenuTitle => string.IsNullOrWhiteSpace( this.Menu?.FirstOrDefault()?.Tilte) ? PageTitle : this.Menu?.FirstOrDefault()?.Tilte;

        public string BreadcrumpTitle => string.IsNullOrWhiteSpace(this.Menu?.FirstOrDefault()?.BrTitle) ? MenuTitle : this.Menu?.FirstOrDefault()?.BrTitle;

        
    }
}
