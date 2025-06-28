using MortgageLoanCalculator.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageLoanCalculator.Core.Services
{
    public interface ILoanService
    {
        decimal CalculateMonthlyPayment(decimal loanAmount, decimal interestRate, int loanTermYears);
        List<AmortizationEntry> GetAmortizationSchedule(decimal loanAmount, decimal interestRate, int loanTermYears);
    }
}
