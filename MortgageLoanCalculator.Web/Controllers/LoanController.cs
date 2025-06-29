using MortgageLoanCalculator.Core.Models;
using MortgageLoanCalculator.Core.Services;
using MortgageLoanCalculator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MortgageLoanCalculator.Web.Controllers
{
    public class LoanController : Controller
    {

        private readonly ILoanService _loanService;
        private readonly DataContext _context;

        public LoanController()
        {
            _loanService = new LoanService(); // For simplicity; use dependency injection in production
            _context = new DataContext();
        }



        // GET: Loan
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Calculate(decimal loanAmount, decimal interestRate, int loanTermYears)
        {
            if (loanAmount <= 0 || interestRate < 0 || loanTermYears <= 0)
            {
                ViewBag.Error = "Invalid input values.";
                return View("Index");
            }

            var monthlyPayment = _loanService.CalculateMonthlyPayment(loanAmount, interestRate, loanTermYears);
            var schedule = _loanService.GetAmortizationSchedule(loanAmount, interestRate, loanTermYears);
            ViewBag.MonthlyPayment = monthlyPayment;
            ViewBag.Schedule = schedule;
            ViewBag.LoanAmount = loanAmount;
            ViewBag.InterestRate = interestRate;
            ViewBag.LoanTermYears = loanTermYears;
            return View("Result");
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult SaveCalculation(decimal loanAmount, decimal interestRate, int loanTermYears, decimal monthlyPayment)
        {

            var schedule = _loanService.GetAmortizationSchedule(loanAmount, interestRate, loanTermYears) as List<AmortizationEntry>;
            var totalPrincipal = schedule.Sum(entry => entry.Principal);
            var totalInterest = schedule.Sum(entry => entry.Interest);
            var totalPayments = monthlyPayment * (loanTermYears * 12);
            var finalBalance = schedule.Any() ? schedule.Last().Balance : 0m;

            var calculation = new MortgageLoanCalculator.Data.Models.LoanCalculation
            {
                LoanAmount = loanAmount,
                InterestRate = interestRate,
                LoanTermYears = loanTermYears,
                MonthlyPayment = monthlyPayment,
                CreatedAt = DateTime.UtcNow,
                UserId = User.Identity.Name,
                TotalPrincipalPaid = totalPrincipal,
                TotalInterestPaid = totalInterest,
                TotalPayment = totalPayments,
                FinalBalance = finalBalance
            };
            _context.LoanCalculations.Add(calculation);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}