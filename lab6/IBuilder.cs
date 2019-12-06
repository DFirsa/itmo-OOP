namespace lab6
{
    public interface IBuilder
    {
        void addFullName(string name, string surname);

        void addAdress(string adress);

        void addPassportNo(int passportNo);
    }
    
    public class ClientBuilder: IBuilder
    {
        Client client = new Client();

        public ClientBuilder()
        {
            Reset();
        }
        
        public void Reset()
        {
            client = new Client();
        }
        
        public void addFullName(string name, string surname)
        {
            client.addFullName(name, surname);
        }

        public void addAdress(string adress)
        {
            client.addAdress(adress);
        }

        public void addPassportNo(int passportNo)
        {
            client.addPassportNo(passportNo);
        }

        public Client GetClient()
        {
            Client res = client;
            Reset();
            return res;
        }
    }

    public class ClientDirector
    {
        private IBuilder builder;

        public IBuilder Builder
        {
            set { builder = value; }
        }

        public void CreateMinInfoClient(string name, string surname)
        {
            builder.addFullName(name, surname);
        }

        public void CreateFullInfoClient(string name, string surname, string address, int no)
        {
            builder.addFullName(name, surname);
            builder.addAdress(address);
            builder.addPassportNo(no);
        }
    }
}