using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Project.Models.Entites
{
    public class Accountc
    {
        public int ID { get; set; }

        public string Fname { get; set; }

        public string Lname { get; set; }

        public string Account_Name { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public decimal Balance { get; set; }
        // عرض الأعمدة (Spaces)
        private const int ID_Space = 5;
        private const int Fname_Space = 17;
        private const int Lname_Space = 17;
        private const int Account_Name_Space = 20;
        private const int Password_Space = 15;
        private const int Phone_Space = 15;
        private const int Email_Space = 25;
        private const int Balance_Space = 12;
        public List<Transactions>? Transactions = new List<Transactions>();

        public override string ToString()
        {

            int totalWidth = ID_Space + Fname_Space + Lname_Space + Account_Name_Space
                           + Password_Space + Phone_Space + Email_Space + Balance_Space
                           + 9 * 3; 

            string line = new string('=', totalWidth);

            return
    $@"{line}
{"ID",-ID_Space} | {"First Name",-Fname_Space} | {"Last Name",-Lname_Space} | {"Username",-Account_Name_Space} | {"Password",-Password_Space} | {"Phone",-Phone_Space} | {"Email",-Email_Space} | {"Balance",-Balance_Space}
{new string('-', totalWidth)}
{ID,-ID_Space} | {Fname,-Fname_Space} | {Lname,-Lname_Space} | {Account_Name,-Account_Name_Space} | {CryptoHelper.Decrypt(Password),-Password_Space} | {Phone,-Phone_Space} | {Email,-Email_Space} | {Balance,Balance_Space:C}
{line}";
        }

    }

}
