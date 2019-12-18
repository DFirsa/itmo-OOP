using System;

namespace lab6
{

    public class Account
    {
        protected readonly double operationLimit;

        protected double balance;
        protected int percent; // %

        private Client Client;

        public Account(double operationLimit, Client client)
        {
            Client = client;
            balance = 0;
            percent = 0;
            this.operationLimit = operationLimit;
        }

        public override string ToString()
        {
            return balance.ToString();
        }

        protected bool isSuspicious()
        {
            return Client.isSuspicious();
        }

        public void toRefill(double sum)
        {
            balance += sum;
        }

        public virtual void toReplenish(double sum)
        {
            if (isSuspicious() && sum > operationLimit) throw new SuspiciousAccException();
            else if (balance < sum) throw new NotEnoughMoneyException();
            else balance -= sum;
        }

        public virtual void transfer(double sum, Account recipient)
        {
            if (isSuspicious() && sum > operationLimit) throw new SuspiciousAccException();
            else
            {
                try
                {
                    TransactionHandler transaction = new ReplanishHandler(this);
                    TransactionHandler refill = new RefillHandler(recipient);
                    transaction.setNext(refill);
                    transaction.handleRequest(sum);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw new Exception();
                }
            }
        }

        public void interestPayment(double sum)
        {
            toRefill(percent * sum / 100);
        }
    }
    
    public class Deposit: Account
    {
        private DateTime depositEnd;
        
        public Deposit(double operationLimit, Client client, DateTime depositEnd, double startSum, int percent) : base(operationLimit, client)
        {
            this.depositEnd = depositEnd;
            base.percent = percent;
            toRefill(startSum);
        }

        public override void toReplenish(double sum)
        {
            if (DateTime.Now < depositEnd) throw new DepositTimeNotExpiredException();
            else base.toReplenish(sum);
        }
    }
    
    public class CurrentAccount: Account
    {
        public CurrentAccount(double operationLimit, Client client, int percent) : base(operationLimit, client)
        {
            base.percent = percent;
        }
    }
    
    public class CreditAccount: Account
    {
        private double creditLimit;
        private int commission; // %

        public CreditAccount(double operationLimit, Client client, int commission, double creditLimit) : base(operationLimit, client)
        {
            this.commission = commission;
            this.creditLimit = creditLimit;
        }

        public override void toReplenish(double sum)
        {
            if (Math.Abs(balance - sum) > creditLimit && balance <= 0) throw new CreditLimitExceededException();
            else if (isSuspicious() && sum > operationLimit) throw new SuspiciousAccException();
            else balance -= sum*(1+(double)commission/100);
        }

        public override void transfer(double sum, Account recipient)
        {
            try
            {
                TransactionHandler transaction = new ReplanishHandler(this);
                TransactionHandler refill = new RefillHandler(recipient);
                transaction.setNext(refill);
                transaction.handleRequest(sum);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception();
            }
        }
    }

    public abstract class AccountCreator
    {
        protected double operationLimit;

        public AccountCreator(double opLim)
        {
            operationLimit = opLim;
        }
        public abstract Account CreateAccount(int perc, Client client, double startSum);
    }

    public class DepositCreator : AccountCreator
    {
        private TimeSpan duration;
        public DepositCreator(double opLim, TimeSpan duration) : base(opLim)
        {
            this.duration = duration;
        }

        public override Account CreateAccount(int perc, Client client, double startSum)
        {
            return new Deposit(operationLimit, client, DateTime.Now + duration, startSum, perc);
        }
    }

    public class CurrentAccountCreator : AccountCreator
    {
        public CurrentAccountCreator(double opLim) : base(opLim)
        {
        }

        public override Account CreateAccount(int perc, Client client, double startSum)
        {
            return new CurrentAccount(operationLimit, client, perc);
        }
    }
    
    public class CreditAccauntCreator: AccountCreator
    {
        private double creditLimit;
        private int commision;
        public CreditAccauntCreator(double opLim, double creditLimit, int commision) : base(opLim)
        {
            this.creditLimit = creditLimit;
            this.commision = commision;
        }

        public override Account CreateAccount(int perc, Client client, double startSum)
        {
            return new CreditAccount(operationLimit, client, commision, creditLimit);
        }
    }
}