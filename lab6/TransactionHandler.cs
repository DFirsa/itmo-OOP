namespace lab6
{
    public abstract class TransactionHandler
    {
        protected TransactionHandler next;
        protected Account account;

        public TransactionHandler(Account account)
        {
            this.account = account;
        }

        public void setNext(TransactionHandler next)
        {
            if (this.next != null) this.next.setNext(next);
            else this.next = next;
        }

        public abstract void handleRequest(double sum);
    }
    
    public class ReplanishHandler: TransactionHandler
    {
        public ReplanishHandler(Account account) : base(account)
        {
        }

        public override void handleRequest(double sum)
        {
            account.toReplenish(sum);
            if (next != null) next.handleRequest(sum);
        }
    }

    public class RefillHandler : TransactionHandler
    {
        public RefillHandler(Account account) : base(account)
        {
        }

        public override void handleRequest(double sum)
        {
            account.toRefill(sum);
            if (next != null) next.handleRequest(sum);
        }
    }
}