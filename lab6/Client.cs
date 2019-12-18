namespace lab6
{
    public class Client: IBuilder
    {
        public string name = null;
        public string surname = null;
        public string address = null;
        public int passportNo = -1;

        public Account account;

        public virtual bool isSuspicious()
        {
            return false;
        }
        
        public void addFullName(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }

        public void addAdress(string adress)
        {
            this.address = adress;
        }

        public void addPassportNo(int passportNo)
        {
            this.passportNo = passportNo;
        }

        public override string ToString()
        {
            string info = $"{name} {surname}";
            if (address != null) info = $" {info}, address: {address}";
            if (passportNo != -1) info = $" {info}, passport: {passportNo}";
            return info;
        }

        public void createAccount(Account acc)
        {
            account = acc;
        }
    }

    public class SuspiciousClient : Client
    {
        public SuspiciousClient(Client client)
        {
            name = client.name;
            surname = client.surname;
            passportNo = client.passportNo;
            address = client.address;
        }

        public override bool isSuspicious()
        {
            return true;
        }
    }
}