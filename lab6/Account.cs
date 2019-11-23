using System;

namespace lab6
{

    public class Account
    {
        protected readonly double operationLimit;
        protected readonly bool isSuspicious;
        
        protected double balance;
        protected int percent; // %

        public Account(bool isSuspicious, double operationLimit)
        {
            this.isSuspicious = isSuspicious;
            balance = 0;
            percent = 0;
            this.operationLimit = operationLimit;
        }

        public void toRefill(double sum)
        {
            balance += sum;
        }

        public virtual void toReplenish(double sum)
        {
            if (isSuspicious && sum > operationLimit) throw new Exception();
            else if (balance < sum) throw new Exception();
            else balance -= sum;
        }

        public virtual void transfer(double sum, Account recipient)
        {
            if (isSuspicious && sum > operationLimit) throw new Exception();
            else
            {
                try
                {
                    toReplenish(sum);
                    recipient.toRefill(sum);
                }
                catch (Exception)
                {
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
        private int daysUntilEnd;
        
        public Deposit(bool isSuspicious, double operationLimit, int percent, int daysUntilEnd) : base(isSuspicious, operationLimit)
        {
            this.percent = percent;
            this.daysUntilEnd = daysUntilEnd;
        }

        public override void toReplenish(double sum)
        {
            if (daysUntilEnd > 0 ) throw new Exception();
            else base.toReplenish(sum);
        }
    }
    
    public class CurrentAccount: Account
    {
        public CurrentAccount(bool isSuspicious, double operationLimit, int percent) : base(isSuspicious, operationLimit)
        {
            this.percent = percent;
        }
    }
    
    public class CreditAccount: Account
    {
        private double creditLimit;
        private int commission; // %
        public CreditAccount(bool isSuspicious, double operationLimit, int commission) : base(isSuspicious, operationLimit)
        {
            this.commission = commission;
        }

        public override void toReplenish(double sum)
        {
            if (Math.Abs(balance) > creditLimit && balance <= 0) throw new Exception();
            else if (isSuspicious && sum > operationLimit) throw new Exception();
            else balance -= sum*((double)commission/100);
        }

        public override void transfer(double sum, Account recipient)
        {
            try
            {
                toReplenish(sum);
                recipient.toRefill(sum);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }

    public abstract class AccountCreator
    {
        public abstract Account CreateAccount();
    }

    public class DepositCreator : AccountCreator
    {
        public override Account CreateAccount()
        {
            throw new NotImplementedException();
        }
    }
}