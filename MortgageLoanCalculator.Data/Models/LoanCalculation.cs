using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageLoanCalculator.Data.Models
{
    public class LoanCalculation
    {
        public int Id { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal InterestRate { get; set; }
        public int LoanTermYears { get; set; }
        public decimal MonthlyPayment { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; }


        // New fields for totals
        public decimal TotalPrincipalPaid { get; set; }
        public decimal TotalInterestPaid { get; set; }
        public decimal TotalPayment { get; set; }
        public decimal FinalBalance { get; set; }
    }
}
