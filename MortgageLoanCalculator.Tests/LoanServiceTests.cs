using Microsoft.VisualStudio.TestTools.UnitTesting;
using MortgageLoanCalculator.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageLoanCalculator.Tests
{
    [TestClass]
    public class LoanServiceTests
    {
        private readonly ILoanService _loanService = new LoanService();

        [TestMethod]
        public void CalculateMonthlyPayment_ValidInput_ReturnsCorrectPayment()
        {
            decimal loanAmount = 100000;
            decimal interestRate = 5;
            int loanTermYears = 30;
            decimal expected = 536.82M; // Approximate value

            var result = _loanService.CalculateMonthlyPayment(loanAmount, interestRate, loanTermYears);

            Assert.AreEqual(expected, Math.Round(result, 2));
        }

        [TestMethod]
        public void GetAmortizationSchedule_ValidInput_ReturnsCorrectSchedule()
        {
            decimal loanAmount = 10000;
            decimal interestRate = 6;
            int loanTermYears = 1;

            var schedule = _loanService.GetAmortizationSchedule(loanAmount, interestRate, loanTermYears);

            Assert.AreEqual(12, schedule.Count);
            Assert.IsTrue(schedule[schedule.Count - 1].Balance < 0.01M); // Balance near zero
        }
    }
}
