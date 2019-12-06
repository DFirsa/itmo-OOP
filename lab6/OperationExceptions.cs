using System;

namespace lab6
{
    public class NotEnoughMoneyException : Exception
    {
        public override string Message
        {
            get { return "Achtung!!!!\nNot Enough money for operation"; }
        }
    }

    public class SuspiciousAccException : Exception
    {
        public override string Message
        {
            get { return "Achtung!!!\nUnavailable operation for this account"; }
        }
    }

    public class DepositTimeNotExpiredException : Exception
    {
        public override string Message
        {
            get { return "Achtung!!!\nTime not expired to replanish"; }
        }
    }

    public class CreditLimitExceededException : Exception
    {
        public override string Message
        {
            get { return "Achtung!!!\nUnavailable operation. Credit limit exceeded"; }
        }
    }
}