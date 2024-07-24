using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace BAnkingAppAdmin
{
    public class SerialDeserial
    {
        public static void SerializeData(Account[] accounts)
        {
            File.WriteAllText("Account.json",JsonConvert.SerializeObject(accounts));
        }

        public static Account[] DesrializeData()
        {
            Account[] accounts = new Account[4];
            string fileName = "Account.json";
            if (File.Exists(fileName))
            {
                string json= File.ReadAllText(fileName);
                accounts = JsonConvert.DeserializeObject<Account[]>(json);
            }
            
            return accounts;

        }

    }
}
