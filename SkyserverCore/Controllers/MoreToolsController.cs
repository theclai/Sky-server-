using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using SkyserverCore.Models;
using SkyServerCore.Common;

using Microsoft.Extensions.Configuration;
using System.Net.Http;
using SkyserverCore.Common;

namespace SkyserverCore.Controllers
{
    public class MoreToolsController : Controller
    {
        Globals globals = new Globals();
        private static readonly HttpClient client = new HttpClient();

        private IConfiguration _configuration;

        public MoreToolsController(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }
        public void setAuth()
        {
            UserAccess user = Authentication.TryUserLogin(HttpContext);
          ViewBag.GenericModel = new GenericModel() { AuthenticationURL_Login = globals.AuthenticationURL_Login, AuthenticationURL_Logout = globals.AuthenticationURL_Logout};
            ViewData["authURL"] = globals.AuthenticationURL_Login;
        }

        public IActionResult Index()
        {
            setAuth();
            return View();
        }
        public IActionResult UserHistory()
        {
            //  string Parameters = "TaskName=Skyserver.UserHistory&format=dataset&DoShowAllHistory=" + globals.doShowAllHistory.ToString() + "&limit=" + globals.topRowsDefault.ToString();
            // string requestURI = globals.UserHistoryWS;

            setAuth();

            ViewData["authURL"] = globals.AuthenticationURL_Login;
            ViewData["userHistoryUrl"] = globals.UserHistoryWS;
            ViewData["doShowAllHistory"] = globals.doShowAllHistory;
            ViewData["topRowsDefault"] = globals.topRowsDefault;

            return PartialView("UserHistory");
        }
        public IActionResult scrollhome()
        {
            setAuth();
            return PartialView("scrollhome");
        }
        public IActionResult browser()
        {
            setAuth();
            return PartialView("browser");
        }
        public IActionResult getimghome()
        {
            setAuth();
            return PartialView("getimghome");
        }
        public IActionResult fields()
        {
            setAuth();
            return PartialView("fields");
        }
        public IActionResult spectra()
        {
            setAuth();
            return PartialView("spectra");
        }
        public IActionResult plate()
        {
            setAuth();
            return PartialView("plate");
        }
    }
}