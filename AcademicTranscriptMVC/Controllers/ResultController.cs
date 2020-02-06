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
        //get
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new ResultMVC());
            }
            else
            {
                HttpResponseMessage fetchResult = GlobalVariable.WebApiClient.GetAsync("Result/" +id.ToString() ).Result;
                var resultList = fetchResult.Content.ReadAsAsync<ResultMVC>().Result;
                return View(resultList);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(ResultMVC result)
        {
            if(result.Id == 0)
            {
                HttpResponseMessage fetchResult = GlobalVariable.WebApiClient.PostAsJsonAsync("Result", result).Result;
                TempData["SucessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage fetchResult = GlobalVariable.WebApiClient.PutAsJsonAsync("Result/", result.Id).Result;
                TempData["SucessMessage"] = "Update Successfully";
            }

            
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            HttpResponseMessage fetchResult = GlobalVariable.WebApiClient.DeleteAsync("Result/"+id.ToString()).Result;
            TempData["SucessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}