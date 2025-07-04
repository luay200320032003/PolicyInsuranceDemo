using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsurancePolicy.Domain
{
    public class Policy
    {
        public string PolicyNumber { get; set; }
        public DateTime EffectiveDate { get; set; }
        public decimal PremiumAmount { get; set; }
        public List<CoverageLimit> Limits { get; set; }
    }
    public class CoverageLimit
    {
        public string Coverage { get; set; }
        public decimal Limit { get; set; }
    }
}
