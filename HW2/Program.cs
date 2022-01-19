using System;
using System.Diagnostics;

namespace HW2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Домашнее задание №3 пункт 1

            Console.Clear();
            var from = new BankAccount(10000, TypeAccount.Общий);
            var to = new BankAccount(1000, TypeAccount.Общий);
            Console.WriteLine($"Номер счета from {from.AccountNumber}\nБаланс {from.Balance}\nТип счета {from.TypeAccount}\n");
            Console.WriteLine($"Номер счета  to {to.AccountNumber}\nБаланс {to.Balance}\nТип счета {to.TypeAccount}\n");
            to.TransferBetweenAccounts(ref from, 5000);
            Console.WriteLine($"Номер счета from {from.AccountNumber}\nБаланс {from.Balance}\nТип счета {from.TypeAccount}\n");
            Console.WriteLine($"Номер счета  to {to.AccountNumber}\nБаланс {to.Balance}\nТип счета {to.TypeAccount}\n");

            // Домашнее задание №3 пункт 2

            Console.Clear();
            void ReversWord(string s)
            {
                for (int i = s.Length - 1; i >= 0; i--)
                {
                    Console.Write(s[i]);
                }
            }
            ReversWord("Qwerty");

            // Домашнее задание №3 пункт 3
            string path = $@"{Directory.GetCurrentDirectory()}\Sample.txt";
            string path2 = $@"{Directory.GetCurrentDirectory()}\Emails.txt";
            string text = "Кучма Андрей Витальевич & Kuchma@mail.ru Мизинцев Павел Николаевич & Pasha@mail.ru";
            File.AppendAllText(path, text);
            void SearchMail(ref string s)
            {
                string[] emails = s.Split(new char[] { '&', ' ' });
                StreamWriter writer = new StreamWriter(path2);
                foreach (string email in emails)
                {
                    if (email.Contains('@'))
                    {
                        writer.WriteLine(email);
                    }
                }
                writer.Close();
            }
            SearchMail(ref text);
        }
    }
}
