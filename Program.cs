using System.Runtime.InteropServices;

namespace Finances
{
     internal class Program
    {
         static void Main(string[] args)
         {
            Console.Write("Are you filling jointly (married)? y/n: ");
            string Joint = Console.ReadLine();
            bool joint_status;
            if (Joint.Contains("y"))
            {
                joint_status = true;
            }
            else
            {
                joint_status = false;
            }
            Console.Write("What is your total/joint yearly income: ");
            string incom = Console.ReadLine();
            
            if (double.TryParse(incom, out double income))
            {
                Calc_Finances tax = new Calc_Finances();
                string Pay_method = tax.Get_Pay_Method();
                int Paydays = tax.times_paid(Pay_method);
                double federal_tax_rate = tax.Tax_rate(income, joint_status);
                double taxed_amount = income * (tax.Tax_rate(income, joint_status) / 100);
                double Child_deduct = tax.Dependant_deduct(taxed_amount);
                Console.Clear();
                Console.WriteLine($"With an income of ${income} a year, you will pay {federal_tax_rate}% tax rate which is about ${(income * (tax.Tax_rate(income, joint_status) / 100)) - Child_deduct}\n");
                Console.WriteLine($"You Would get paid ${Math.Round((income/Paydays) + (Child_deduct/Paydays), 2)} {Paydays} times a year before tax\n");
                Console.WriteLine($"You get paid ${Math.Round((tax.Wage_taxed(income, federal_tax_rate, Paydays)) + (Child_deduct/Paydays))} every {Pay_method} pay period\n");
                Console.WriteLine($"Your children got you got of ${Child_deduct} worth of taxes");
            }
            else
            {
                throw new Exception("income not feasable");
            }

            
         }
        
    }
}