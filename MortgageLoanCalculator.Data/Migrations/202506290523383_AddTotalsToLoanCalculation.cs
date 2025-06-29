namespace MortgageLoanCalculator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTotalsToLoanCalculation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoanCalculations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoanAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InterestRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LoanTermYears = c.Int(nullable: false),
                        MonthlyPayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTime(nullable: false),
                        UserId = c.String(),
                        TotalPrincipalPaid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalInterestPaid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FinalBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LoanCalculations");
        }
    }
}
