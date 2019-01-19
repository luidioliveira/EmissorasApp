namespace EmissorasApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class audiencia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Audiencia",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        pontosAudiencia = c.Single(nullable: false),
                        dataHoraAudiencia = c.DateTime(nullable: false),
                        emissoraAudiencia = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Audiencia");
        }
    }
}
