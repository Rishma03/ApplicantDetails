using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicantDetail.Models
{
    public class CandidateMaster
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string Qualification { get; set; }
        public string Technology { get; set; }
    }
}