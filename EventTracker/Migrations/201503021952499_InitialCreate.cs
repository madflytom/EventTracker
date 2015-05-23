namespace EventTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Location = c.String(),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        OwnerENT = c.String(),
                        BlockDuration = c.Int(nullable: false),
                        Seats = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventId);
            
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        ParticipantId = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        ParticipantENT = c.String(),
                        SeatId = c.Int(nullable: false),
                        BlockId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ParticipantId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Participants");
            DropTable("dbo.Events");
        }
    }
}
