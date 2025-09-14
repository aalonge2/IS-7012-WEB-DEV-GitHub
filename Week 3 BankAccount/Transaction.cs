namespace Classes
{
    public class Transaction
    {
        public decimal Amount { get; }
        public DateTime Date { get; }
        public string Notes { get; }

        public Transaction(decimal amount, DateTime date, string note)
        {
            Amount = amount;
            Date = date;
            Notes = note;
        }
    }

    public class TransactionManager
    {
        private List<Transaction> _allTransactions = new List<Transaction>();

        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in _allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            _allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            _allTransactions.Add(withdrawal);
        }

        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in _allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }

            return report.ToString();
        }
    }

    public class BankAccount
    {
        private static int s_accountNumberSeed = 1;
        public string Number { get; }
        public string Owner { get; set; }
        private TransactionManager _transactionManager = new TransactionManager();

        public BankAccount(string name, decimal initialBalance)
        {
            if (initialBalance <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(initialBalance), "Initial balance must be positive");
            }

            Number = s_accountNumberSeed.ToString();
            s_accountNumberSeed++;
            Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        }

        public decimal Balance => _transactionManager.Balance;

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            _transactionManager.MakeDeposit(amount, date, note);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            _transactionManager.MakeWithdrawal(amount, date, note);
        }

        public string GetAccountHistory()
        {
            return _transactionManager.GetAccountHistory();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Example usage/testing
        var account = new Classes.BankAccount("John Doe", 1000);

        account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
        Console.WriteLine(account.Balance);

        account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
        Console.WriteLine(account.Balance);

        // Test that the initial balances must be positive.
        try
        {
            var invalidAccount = new Classes.BankAccount("invalid", -55);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine("Exception caught creating account with negative balance");
            Console.WriteLine(e.ToString());
        }

        // Test for a negative balance.
        try
        {
            account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine("Exception caught trying to overdraw");
            Console.WriteLine(e.ToString());
        }

        // Print account history
        Console.WriteLine(account.GetAccountHistory());
    }
}