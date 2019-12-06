namespace lab6
{
    public class Client: IBuilder
    {
        private string name = null;
        private string surname = null;
        private string address = null;
        private int passportNo = -1;

        public Account account;

        public bool isSuspicious()
        {
            if (surname == null || address == null) return true;
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
}