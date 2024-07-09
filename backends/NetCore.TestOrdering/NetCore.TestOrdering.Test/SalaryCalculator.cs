namespace NetCore.TestOrdering.Test
{
    public static class SalaryCalculator
    {
        public static decimal IncomeTaxRate { get; set; }
        public static decimal SocialSecurityTax { get; set; }
        
        public static decimal GrossSalary { get; private set; }        
        public static decimal Discounts { get; private set; }

        public static decimal NetSalary{ get; private set; }

        public static void CalcDiscounts(decimal grossSalary)
        {
            if (IncomeTaxRate == 0 || SocialSecurityTax == 0) { return; }

            GrossSalary = grossSalary;
            Discounts = grossSalary * IncomeTaxRate + grossSalary * SocialSecurityTax;
        }

        public static void CalcNetSalary()
        {
            NetSalary = GrossSalary - Discounts;
        }
    }
}
