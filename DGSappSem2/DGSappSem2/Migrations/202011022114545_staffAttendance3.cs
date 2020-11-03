namespace DGSappSem2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class staffAttendance3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StaffAttendances", "Staffrecord", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StaffAttendances", "Staffrecord", c => c.String());
        }
    }
}
