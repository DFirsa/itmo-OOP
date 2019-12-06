using System;
using System.Collections.Generic;

namespace lab6
{
    public class Bank
    {
        private List<Client> clients;
        
        private TimeSpan depositDuration;
        private double operationLimit;
        private double creditLimit;
        private int comission;
        private int defaultPercent;

        private List<double> money;
        private List<int> percent;

        private AccountCreator factory;

        public Bank(TimeSpan depositDuration, double operationLimit, double creditLimit, int comission, List<double> moneyGraduate, List<int> percentGraduate, int defaultPercent)
        {
            this.clients = new List<Client>();
            this.depositDuration = depositDuration;
            this.operationLimit = operationLimit;
            this.creditLimit = creditLimit;
            this.comission = comission;
            this.money = moneyGraduate;
            this.percent = percentGraduate;
            this.defaultPercent = defaultPercent;
        }

        private int DepositPercent(double startSum)
        {
            for (int i = 1; i < money.Count; i++)
            {
                if (startSum < money[i]) return percent[i - 1];
            }

            return percent[percent.Count - 1];
        }

        public void CreateDeposit(Client client, double startSum)
        {
            factory = new DepositCreator(operationLimit, depositDuration);
            client.createAccount(factory.CreateAccount(DepositPercent(startSum), client, startSum));
        }

        public void CreateCurrentAcc(Client client)
        {
            factory = new CurrentAccountCreator(operationLimit);
            client.createAccount(factory.CreateAccount(defaultPercent, client, 0));
        }

        public void CreateCreditAccount(Client client)
        {
            factory = new CreditAccauntCreator(operationLimit, creditLimit,  comission);
            client.createAccount(factory.CreateAccount(0, client, 0));
        }

        public void addClient(Client client)
        {
            clients.Add(client);
        }
    }
}