using InsurancePolicy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsurancePolicy.Data
{
    public class PolicyRepository
    {
        private static readonly List<Policy> policies = new List<Policy>
        {
            new Policy
            {
                PolicyNumber = "TX123456",
                EffectiveDate = new DateTime(2025, 1, 1),
                PremiumAmount = 1200.50m,
                Limits = new List<CoverageLimit>
                {
                    new CoverageLimit { Coverage = "Property", Limit = 1000000 },
                    new CoverageLimit { Coverage = "Liability", Limit = 500000 }
                }
            },
            new Policy
            {
                PolicyNumber = "CA654321",
                EffectiveDate = new DateTime(2025, 3, 15),
                PremiumAmount = 800.75m,
                Limits = new List<CoverageLimit>
                {
                    new CoverageLimit { Coverage = "Property", Limit = 750000 }
                }
            }
        };

        public Policy GetPolicy(string policyNumber)
        {
            return policies.FirstOrDefault(p => p.PolicyNumber.Equals(policyNumber, StringComparison.OrdinalIgnoreCase));
        }
    }
}
