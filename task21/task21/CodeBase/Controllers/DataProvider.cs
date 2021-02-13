using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using System.Text.Json;
using CodeBase.Helpers;

namespace CodeBase.Controllers
{
    public class DataProviderController : SurfaceController
    {      
        public ActionResult GetGridItems(int pageSize = 5, int skip = 0)
        {
            var fileContents = System.IO.File.ReadAllText(Server.MapPath(@"~/gridData2.json"));
            var jsonFileObjects = JsonSerializer.Deserialize<myItem[]>(fileContents);
            var total = jsonFileObjects.Count();
            var data = jsonFileObjects.Skip<myItem>(skip).Take<myItem>(pageSize).ToList();
            return Json(new { total = total, data = data });
        }
    }
}
