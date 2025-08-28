using Bank_Project.Models;
using Bank_Project.Models.Entites;
using System.Diagnostics;
using System.Text.Json;
namespace Bank_Project
{
    internal class Program
    {

        static void Main(string[] args)
        {
            var i  = CryptoHelper.Decrypt("9y1Ry4ScCb8pINaXGcAG6Q==");
            Console.WriteLine(i);
            Console.ReadLine();
        }
    }
}
