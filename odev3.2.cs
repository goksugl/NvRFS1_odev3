
//odev3.2

using System;

namespace BankApplication
{
    public class BankAccount
    {
        public string AccountHolder { get; set; }  
        public double Balance { get; set; }        

        public BankAccount(string accountHolder, double balance)
        {
            AccountHolder = accountHolder;
            Balance = balance;
        }

        public virtual void CalculateInterest()
        {
            Console.WriteLine("Bu metod alt sınıflar tarafından override edilmelidir.");
        }
    }

    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(string accountHolder, double balance)
            : base(accountHolder, balance)
        {
        }

        public override void CalculateInterest()
        {
            double interest = Balance * 0.05; // %5 faiz hesapla
            Console.WriteLine($"{AccountHolder} için hesaplanan faiz: {interest:C}");
        }
    }

    public class CheckingAccount : BankAccount
    {
        public CheckingAccount(string accountHolder, double balance)
            : base(accountHolder, balance)
        {
        }

        public override void CalculateInterest()
        {
            Console.WriteLine($"{AccountHolder} için vadesiz hesaplarda faiz kazancı yok.");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Vadeli Hesap Açma *****");
            Console.Write("Hesap Sahibinin Adı: ");
            string savingsHolder = Console.ReadLine();

            Console.Write("Başlangıç Bakiyesi: ");
            double savingsBalance = Convert.ToDouble(Console.ReadLine());

            SavingsAccount savings = new SavingsAccount(savingsHolder, savingsBalance);

            Console.WriteLine("\n***** Vadesiz Hesap Açma *****");
            Console.Write("Hesap Sahibinin Adı: ");
            string checkingHolder = Console.ReadLine();

            Console.Write("Başlangıç Bakiyesi: ");
            double checkingBalance = Convert.ToDouble(Console.ReadLine());

            CheckingAccount checking = new CheckingAccount(checkingHolder, checkingBalance);

            Console.WriteLine("\n***** Hesap Faiz Bilgileri *****");
            savings.CalculateInterest();
            checking.CalculateInterest();
        }
    }
}