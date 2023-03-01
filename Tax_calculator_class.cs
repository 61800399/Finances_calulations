using System;
using System.ComponentModel;

public class Calc_Finances
{
	public bool Taxed() // currently unused method, funtionallity not implemented
	{
		Console.Write("Do you pay taxes on this: ");
		string ans = Console.ReadLine();
		if (ans.Contains("yes")) 
		{
			return true;
		}
		else if (ans.Contains("no"))
		{
			return false;
		}
		else
		{
			throw new Exception("invalid answer");
		}
	}
    public string Get_Pay_Method()
    {
        Console.Write("how do you get paid? \n1: Salary\n2: Weekly\n3: Bi-Weekly\n4: Other\n: ");
        string PayMethod = Console.ReadLine();
        if (PayMethod.Contains("1"))
        {
            return "salary (monthly)";
        }
        else if (PayMethod.Contains("2"))
        {
           return "weekly";
        }
        else if (PayMethod.Contains("3"))
        {
            return "bi-weekly";
        }
        else if (PayMethod.Contains("4"))
        {
            return "other";
        }
		else
		{
			throw new Exception("invalid pay scale");
		}
    }
    public int times_paid(string pay_type)
	{
		if (pay_type == "salary")
		{
			return 12;
		}
		else if (pay_type == "weekly")
		{
			return 52;
		}
		else if (pay_type == "bi-weekly")
		{
			return 26;
		}
		else if (pay_type == "other")
		{
			Console.Write("How many times do you get paid a year?: ");
			bool integer = int.TryParse(Console.ReadLine(), out int paydays_a_year);
			if (integer)
			{
                return paydays_a_year;
            }
			else
			{
				throw new Exception("invalid int!");
			}
		}
		else
		{
			throw new Exception("Not valid method!");
		}
	}
	
	public double Tax_rate(double income, bool Joint_status)
	{
		if (Joint_status)
		{
			/* 10% 0-20550
			 * 12% 20551-83550
			 * 22% 83551-178150
			 * 24% 178151-340100
			 * 32% 340101-431900
			 * 35% 431901-647850
			 * 37% Greater than 647851
			 */
			if (income < 20550)
			{
				return 10.00;
			}
			else if (income >= 20551 && income < 83550)
			{
				return 12.00;
			}
			else if (income >= 83551 && income < 178150)
			{
				return 22.00;
			}
			else if (income >= 178151 && income < 340100)
			{
				return 24.00;
			}
			else if (income >= 340101 && income < 431900)
			{
				return 32.00;
			}
			else if (income >= 431901 && income < 647850)
			{
				return 35.00;
			}
			else if (income >= 647850)
			{
				return 37.00;
			}
			else
			{
				throw new Exception();
			}
		}
		else
		{
            if (income <= 10275 && income >= 0)
            {
                return 10.00;
            }
            else if (income <= 41775 && income >= 10276)
            {
                return 12.00;
            }
            else if (income <= 89075 && income <= 41776)
            {
                return 22.00;
            }
            else if (income <= 170050 && income >= 89076)
            {
                return 24.00;
            }
            else if (income <= 215950 && income >= 170051)
            {
                return 32.00;
            }
            else if (income <= 539900 && income >= 215951)
            {
                return 35.00;
            }
            else if (income >= 53901)
            {
                return 37.00;
            }
            else
            {
                return 0.00;
            }
        }
		
    }
	public double Wage_taxed(double income, double tax_rate, int times_paid)
	{
		double taxed_pay = (income*((100 - tax_rate)/ 100))/times_paid;
		return taxed_pay;
	}
	public double Dependant_deduct(double taxed_income)
	{
		int deducted = 0;
		Console.Write("How many dependants do you have?: ");
		string Dependants = Console.ReadLine();
		int.TryParse(Dependants, out int dependants);
		List<int> Ages = new List<int>();
		if (dependants > 0)
		{
			for (int x = 0;  x < dependants; x++)
			{
				Console.Write($"how old is dependant {x+1}: ");
				if (int.TryParse(Console.ReadLine(), out int age))
				{
                    Ages.Add(age);
                }
				else
				{
					throw new Exception();
				}
            }
			foreach (int x in Ages)
			{
				if (x < 6)
				{
					deducted += 3600;
				}
				else if (x >= 6 && x < 17)
				{
                    deducted += 3000;
				}
				else
				{
					
				}
			}
			

        }
		if (deducted > taxed_income)
		{
            int.TryParse(taxed_income.ToString(), out int t);
			deducted = t;
		}
		return deducted;
	}
	//public double Bank_Balance(double income, double saved, bool bi_weekly)
	//{
		
	//}
}
