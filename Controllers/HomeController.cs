using ApplicantDetail.DAL;
using ApplicantDetail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApplicantDetail.Controllers
{
    public class HomeController : Controller
    {
        private CandidateExpContext db = new CandidateExpContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public class CandidateMasterVM
        {
            public Int64 Id { get; set; }
            public string Name { get; set; }
            public string Qualification { get; set; }
            public string Technology { get; set; }
            public string Experience { get; set; }

        }
        public class CandidateWorkExpVM
        {
            public Int64 Id { get; set; }
            public Int64 CandidateId { get; set; }
            public string CompanyName { get; set; }
            public DateTime JobStartDate { get; set; }
            public string City { get; set; }
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult InsertCandidateDetail(CandidateMasterVM req)
        {
            CandidateMaster _candidate = new CandidateMaster();
            _candidate.Name = req.Name;
            _candidate.Qualification = req.Qualification;
            _candidate.Technology = req.Technology;
            db.CandidateMaster.Add(_candidate);            
            db.SaveChanges();
            string []splitExp = req.Experience.Split(',');
            for(int i=0;i< splitExp.Length;i++)
            {             
                string []_splitExpAgain = splitExp[i].Split('#');
                CandidateWorkExp _candExp = new CandidateWorkExp();
                _candExp.CandidateId = _candidate.Id;
                _candExp.CompanyName = _splitExpAgain[0].ToString();
                _candExp.JobStartDate= Convert.ToDateTime(_splitExpAgain[1].ToString());
                _candExp.City = _splitExpAgain[2].ToString();
                db.CandidateWorkExp.Add(_candExp);
                db.SaveChanges();
            }

            return Json(1);
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetCandidateDetail()
        {
            CandidateMaster _candidate = new CandidateMaster();
            CandidateWorkExp _candExp = new CandidateWorkExp();
            List<CandidateMaster> query = db.CandidateMaster.AsQueryable().Where(x => x.Technology.Contains("C#")).ToList();
            return Json(query, JsonRequestBehavior.AllowGet);
        }
    }
}