namespace ApplicantDetail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CandidateMasters",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Qualification = c.String(),
                        Technology = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CandidateWorkExps",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CandidateId = c.Long(nullable: false),
                        CompanyName = c.String(),
                        JobStartDate = c.DateTime(nullable: false),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CandidateWorkExps");
            DropTable("dbo.CandidateMasters");
        }
    }
}
