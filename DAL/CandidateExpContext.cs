using ApplicantDetail.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ApplicantDetail.DAL
{
    public class CandidateExpContext : DbContext
    {
        public DbSet<CandidateMaster> CandidateMaster { get; set; }
        public DbSet<CandidateWorkExp> CandidateWorkExp { get; set; }
    }
}