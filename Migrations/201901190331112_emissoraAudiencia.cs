namespace EmissorasApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emissoraAudiencia : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Audiencia", "emissoraAudiencia", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Audiencia", "emissoraAudiencia", c => c.String());
        }
    }
}
