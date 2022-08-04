using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicantDetail.Models
{
    public class CandidateWorkExp
    {
        public Int64 Id { get; set; }
        public Int64 CandidateId { get; set; }
        public string CompanyName { get; set; }
        public DateTime JobStartDate { get; set; }
        public string City { get; set; }
    }
}