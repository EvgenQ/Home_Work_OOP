using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{

    public enum TypeAccount
    {
        Бюджетный = 1,
        Расчётный = 2,
        Общий = 3,
        Накопительный = 4,
    }
    public class BankAccount
    {
        static int unicAccountNumber;
        private int _accountNumber;
        private decimal _balance;
        private TypeAccount _typeAccount;

        public int AccountNumber { get { return _accountNumber; } set { _accountNumber = value; } }
        public decimal Balance { get { return _balance; } set { _balance = value; } }
        public TypeAccount TypeAccount { get { return _typeAccount; } set { _typeAccount = value; } }

        public BankAccount(decimal balance)
        {
            _accountNumber = UnicNumber();
            _balance = balance;
        }
        public BankAccount(TypeAccount typeAccount)
        {
            _accountNumber = UnicNumber();
            _typeAccount = typeAccount;
        }
        public BankAccount(decimal balance, TypeAccount typeAccount) 
        {
            _accountNumber = UnicNumber();
            _balance = balance;
            _typeAccount = typeAccount;
        }

        public void GetInformationBankAccount() 
        {
            Console.WriteLine($"Номер счета: {_accountNumber}\nБаланс: {_balance}\nТип счета: {_typeAccount}\n");
        }

        private int UnicNumber() 
        {
            return ++unicAccountNumber;
        }

        public void PutOnTheAccount(decimal add) 
        {
            _balance += add;
        }

        public bool Withdraw(decimal sum) 
        {
            if (_balance >= sum) 
            {
                _balance -= sum;
                return true;
            }
            Console.WriteLine("Вы хотите снять больше чем у вас на балансе");
            return false;
        }
        private bool WithdrawFromAccount(decimal sum)
        {
            if (_balance >= sum)
            {
                _balance -= sum;
                return true;
            }
            Console.WriteLine("Не достаточно средств на балансе");
            return false;
        }

        public void TransferBetweenAccounts(ref BankAccount account, decimal amount) 
        {
            account.WithdrawFromAccount(amount);
            PutOnTheAccount(amount);
        }


    }
}
