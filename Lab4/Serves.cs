using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Lab4
{
    public class Serves
    {
        private MySQLDAO sqlDao;
//        private FileDAO fileDao;

        public Serves()
        {
            sqlDao = new MySQLDAO("localhost", 3306, "StoreInfo", "root", "qoe74859");
        }

        public void createStore(string store)
        {
            sqlDao.CreateStore(store);
        }
        
        
    }
}