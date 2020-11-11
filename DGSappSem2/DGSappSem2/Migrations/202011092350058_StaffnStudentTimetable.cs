namespace DGSappSem2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StaffnStudentTimetable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StaffTimetables",
                c => new
                    {
                        StaffTimetableId = c.Int(nullable: false, identity: true),
                        StaffId = c.Int(nullable: false),
                        Term = c.String(nullable: false),
                        M1 = c.String(nullable: false),
                        M2 = c.String(nullable: false),
                        M3 = c.String(nullable: false),
                        M4 = c.String(nullable: false),
                        M5 = c.String(nullable: false),
                        M6 = c.String(nullable: false),
                        T1 = c.String(nullable: false),
                        T2 = c.String(nullable: false),
                        T3 = c.String(nullable: false),
                        T4 = c.String(nullable: false),
                        T5 = c.String(nullable: false),
                        T6 = c.String(nullable: false),
                        W1 = c.String(nullable: false),
                        W2 = c.String(nullable: false),
                        W3 = c.String(nullable: false),
                        W4 = c.String(nullable: false),
                        W5 = c.String(nullable: false),
                        W6 = c.String(nullable: false),
                        Th1 = c.String(nullable: false),
                        Th2 = c.String(nullable: false),
                        Th3 = c.String(nullable: false),
                        Th4 = c.String(nullable: false),
                        Th5 = c.String(nullable: false),
                        Th6 = c.String(nullable: false),
                        F1 = c.String(nullable: false),
                        F2 = c.String(nullable: false),
                        F3 = c.String(nullable: false),
                        F4 = c.String(nullable: false),
                        F5 = c.String(nullable: false),
                        F6 = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StaffTimetableId)
                .ForeignKey("dbo.Staffs", t => t.StaffId, cascadeDelete: true)
                .Index(t => t.StaffId);
            
            CreateTable(
                "dbo.StudentTimetables",
                c => new
                    {
                        StaffTimetableId = c.Int(nullable: false, identity: true),
                        ClassName = c.String(nullable: false),
                        Term = c.String(nullable: false),
                        M1 = c.String(nullable: false),
                        M2 = c.String(nullable: false),
                        M3 = c.String(nullable: false),
                        M4 = c.String(nullable: false),
                        M5 = c.String(nullable: false),
                        M6 = c.String(nullable: false),
                        T1 = c.String(nullable: false),
                        T2 = c.String(nullable: false),
                        T3 = c.String(nullable: false),
                        T4 = c.String(nullable: false),
                        T5 = c.String(nullable: false),
                        T6 = c.String(nullable: false),
                        W1 = c.String(nullable: false),
                        W2 = c.String(nullable: false),
                        W3 = c.String(nullable: false),
                        W4 = c.String(nullable: false),
                        W5 = c.String(nullable: false),
                        W6 = c.String(nullable: false),
                        Th1 = c.String(nullable: false),
                        Th2 = c.String(nullable: false),
                        Th3 = c.String(nullable: false),
                        Th4 = c.String(nullable: false),
                        Th5 = c.String(nullable: false),
                        Th6 = c.String(nullable: false),
                        F1 = c.String(nullable: false),
                        F2 = c.String(nullable: false),
                        F3 = c.String(nullable: false),
                        F4 = c.String(nullable: false),
                        F5 = c.String(nullable: false),
                        F6 = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StaffTimetableId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StaffTimetables", "StaffId", "dbo.Staffs");
            DropIndex("dbo.StaffTimetables", new[] { "StaffId" });
            DropTable("dbo.StudentTimetables");
            DropTable("dbo.StaffTimetables");
        }
    }
}
