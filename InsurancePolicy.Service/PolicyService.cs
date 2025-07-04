using InsurancePolicy.Domain;
using InsurancePolicy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsurancePolicy.Service
{
    public class PolicyService
    {
        private readonly PolicyRepository _policyRepository;

        public PolicyService(PolicyRepository policyRepository)
        {
            _policyRepository = policyRepository;
        }

        public Policy GetPolicy(string policyNumber)
        {
            return _policyRepository.GetPolicy(policyNumber);
        }
    }
}
