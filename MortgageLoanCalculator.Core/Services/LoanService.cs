using MortgageLoanCalculator.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageLoanCalculator.Core.Services
{
    public class LoanService : ILoanService
    {
        public decimal CalculateMonthlyPayment(decimal loanAmount, decimal interestRate, int loanTermYears)
        {
            decimal monthlyRate = interestRate / 100 / 12;
            int numberOfPayments = loanTermYears * 12;
            if (monthlyRate == 0) return loanAmount / numberOfPayments;
            return loanAmount * (monthlyRate * (decimal)Math.Pow((double)(1 + monthlyRate), numberOfPayments)) /
                   ((decimal)Math.Pow((double)(1 + monthlyRate), numberOfPayments) - 1);
        }

        public List<AmortizationEntry> GetAmortizationSchedule(decimal loanAmount, decimal interestRate, int loanTermYears)
        {
            var schedule = new List<AmortizationEntry>();
            decimal monthlyPayment = CalculateMonthlyPayment(loanAmount, interestRate, loanTermYears);
            decimal monthlyRate = interestRate / 100 / 12;
            decimal balance = loanAmount;
            int numberOfPayments = loanTermYears * 12;

            for (int i = 1; i <= numberOfPayments; i++)
            {
                decimal interest = balance * monthlyRate;
                decimal principal = monthlyPayment - interest;
                balance -= principal;
                schedule.Add(new AmortizationEntry
                {
                    PaymentNumber = i,
                    PaymentAmount = monthlyPayment,
                    Principal = principal,
                    Interest = interest,
                    Balance = Math.Max(balance, 0)
                });
            }
            return schedule;
        }
    }
}
