namespace lab6
{
    public class Client: IBuilder
    {
        private string name = null;
        private string surname = null;
        private string address = null;
        private int passportNo = -1;

        public Account account;
        private ClientDecorator decorator = new ClientDecorator();

        public bool isSuspicious;

        public void addFullName(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
            decorator.decorate(this);
        }

        public void addAdress(string adress)
        {
            this.address = adress;
            decorator.decorate(this);
        }

        public void addPassportNo(int passportNo)
        {
            this.passportNo = passportNo;
            decorator.decorate(this);
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
    
    public class ClientDecorator
    {
        public void decorate(Client client)
        {
            if (client.ToString().Contains("address:") && client.ToString().Contains("passport:"))
                client.isSuspicious = false;
            else client.isSuspicious = true;
        }
    }
}