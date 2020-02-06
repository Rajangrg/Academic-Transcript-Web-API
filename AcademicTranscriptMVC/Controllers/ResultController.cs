using AcademicTranscriptMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace AcademicTranscriptMVC.Controllers
{
    public class ResultController : Controller
    {
        // GET: Result
        public ActionResult Index()
        {
            IEnumerable<ResultMVC> resultList;
            HttpResponseMessage fetchResult = GlobalVariable.WebApiClient.GetAsync("Result").Result;
            resultList = fetchResult.Content.ReadAsAsync<IEnumerable<ResultMVC>>().Result;

            return View(resultList);
        }
    }
}