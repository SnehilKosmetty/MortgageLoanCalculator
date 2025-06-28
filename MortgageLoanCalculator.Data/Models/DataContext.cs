using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageLoanCalculator.Data.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=DefaultConnection") { }
        public DbSet<LoanCalculation> LoanCalculations { get; set; }
    }
}
