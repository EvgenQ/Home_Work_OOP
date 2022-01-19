using System;
using System.Diagnostics;

namespace HW2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<BankAccount> accounts = new List<BankAccount>();
            bool choice = true;
            while (choice)
            {
                Console.WriteLine("Хотите завести счет в банке?\nНажмите 1 - Да 2 - Нет");
                int.TryParse(Console.ReadLine(), out int select);
                if (select < 1 || select > 2)
                {
                    choice = true;
                    Console.Clear();
                    int timer = 5;
                    while (timer != 0)
                    {
                        Console.WriteLine($"Неверный ввод попробуйте еще раз {timer}");
                        Thread.Sleep(500);
                        Console.Clear();
                        timer--;
                    }
                }
                if (select == 2)
                {
                    choice = false;
                    Console.Clear();
                    Console.WriteLine("Всего доброго, будем рады видеть Вас снова.");
                    Process.GetCurrentProcess().Kill();
                }
                if (select == 1) choice = false;
            }
            choice = true;
            Console.Clear();
            decimal sum = 0;
            do
            {
                Console.Write("Введите сумму которую хотите положить на счет: ");
                decimal.TryParse(Console.ReadLine(), out decimal select);
                if (select == 0)
                {
                    Console.WriteLine("Не корректо введена сумма или вы ввели ноль");
                    Thread.Sleep(3000);
                    Console.Clear();
                }
                if (select > 0)
                {
                    choice = false;
                    sum = (decimal)select;
                }
            } while (choice);
            choice = true;
            do
            {
                string x = "Выберите тип счета из списка: ";
                Console.Clear();
                Console.WriteLine(x);
                int count = 1;
                foreach (var item in Enum.GetValues(typeof(TypeAccount)))
                {
                    Console.WriteLine($"{count} - {item}");
                    count++;
                }
                Console.SetCursorPosition(x.Length, 0);
                int.TryParse(Console.ReadLine(), out int select);
                Console.Clear();
                switch (select)
                {
                    case 1:
                        accounts.Add(new BankAccount(sum, TypeAccount.Бюджетный));
                        choice = false;
                        break;
                    case 2:
                        accounts.Add(new BankAccount(sum, TypeAccount.Расчётный));
                        choice = false;
                        break;
                    case 3:
                        accounts.Add(new BankAccount(sum, TypeAccount.Общий));
                        choice = false;
                        break;
                    case 4:
                        accounts.Add(new BankAccount(sum, TypeAccount.Накопительный));
                        choice = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Такого счета нет в списке, попробуйте еще раз.");
                        Thread.Sleep(3000);
                        break;
                }
            } while (choice);



            BankAccount account = accounts[0];
            Console.WriteLine($"Номер счета {account.AccountNumber}\nБаланс {account.Balance}\nТип счета {account.TypeAccount}\n");
            account.PutOnTheAccount(1200);
            Console.WriteLine($"Номер счета {account.AccountNumber}\nБаланс {account.Balance}\nТип счета {account.TypeAccount}\n");
            account.Withdraw(2000);
            Console.WriteLine($"Номер счета {account.AccountNumber}\nБаланс {account.Balance}\nТип счета {account.TypeAccount}\n");
            account.Withdraw(1000);
            Console.WriteLine($"Номер счета {account.AccountNumber}\nБаланс {account.Balance}\nТип счета {account.TypeAccount}\n");
        }
    }
}
