using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class CustomerModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string ProductName { get; set; }
        public float PayoutAmount { get; set; }
        public float AnnualPremium { get; set; }
        public float CreditCharge { get; set; }
        public float TotalPremium { get; set; }
        public float AverageMonthlyPremium { get; set; }
        public int IntialMonthlyPaymentAmount { get; set; }
        public int OtherMontlyPaymentAmounts { get; set; }
    }


}
