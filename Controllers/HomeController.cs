using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShadowSocketChangePort.Models;

namespace ShadowSocketChangePort.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ShadowSocketConfig model = new ShadowSocketConfig();
            try
            {
                string configStr = System.IO.File.ReadAllText(Common.Utils.GetConfigPath());
                model = JsonConvert.DeserializeObject<ShadowSocketConfig>(configStr);
            }
            catch
            {
            }
            ViewData["MethodList"] = ShadowSocketConfig.MenthodList;
            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public JsonResult ChangePort(ShadowSocketConfig model)
        {
            bool result = false;
            string msg = "ojb not k";
            try
            {
                string configStr = JsonConvert.SerializeObject(model, Formatting.Indented);
                System.IO.File.WriteAllText(Common.Utils.GetConfigPath(), configStr);
                result = true;
                msg = Common.Utils.RunCommand("/usr/local/bin/ssserver",
                $" -c {Common.Utils.GetConfigPath()} -d restart");
            }
            catch
            {

            }
            return new JsonResult(new { result, msg });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
