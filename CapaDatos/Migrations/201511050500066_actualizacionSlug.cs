namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actualizacionSlug : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cursoes", "urlSlug", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cursoes", "urlSlug");
        }
    }
}
