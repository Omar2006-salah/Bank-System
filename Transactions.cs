using Bank_Project.Models.Enums;
using System.Diagnostics;

namespace Bank_Project.Models.Entites
{
    public class Transactions
    {
        public int ID { get; set; }

        public  int Account_ID { get; set; }

        public Transaction_Types Type { get; set; } // -- enum (withdraw , deposite , translation)

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public string Some_Notes { get; set; }

        public Accountc Navigation_Account { get; set; }

        public const int ID_Space = 5;
        public const int Account_ID_Space = 12;
        public const int Type_Space = 15;
        public const int Amount_Space = 12;
        public const int Date_Space = 22;
        public const int Notes_Space = 30;

        public Transactions(int account_ID, Transaction_Types type, decimal amount, DateTime date, string some_Notes = "")
        {
            Account_ID = account_ID;
            Type = type;
            Amount = amount;
            Date = date;
            Some_Notes = some_Notes;
        }

        public override string ToString()
        {
            // مجموع الأعمدة + عدد الفواصل (6 أعمدة = 5 فواصل)
            int totalWidth = ID_Space + Account_ID_Space + Type_Space +
                             Amount_Space + Date_Space + Notes_Space +
                             6 * 3;

            string line = new string('=', totalWidth);

            return
    $@"{line}
{"ID",-ID_Space} | {"Account ID",-Account_ID_Space} | {"Type",-Type_Space} | {"Amount",-Amount_Space} | {"Date",-Date_Space} | {"Notes",-Notes_Space}
{new string('-', totalWidth)}
{ID,-ID_Space} | {Account_ID,-Account_ID_Space} | {Type,-Type_Space} | {Amount,Amount_Space:C} | {Date,-Date_Space} | {Some_Notes,-Notes_Space}
{line}";
        }
    }

}
