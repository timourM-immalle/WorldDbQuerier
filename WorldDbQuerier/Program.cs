using System;
using MySql.Data.MySqlClient;

namespace WorldDbQuerier
{
    class Program
    {
        //0.1
        //command parser
        private static string versie = "0.1";

        static void Main(string[] args)
        {
            if (args.Length > 0) //controleren of er elementen inzitten
            {
                switch (args[0])
                {
                    case "-v":
                        Console.WriteLine("Versie " + versie);
                        break;
                    default:
                        Console.WriteLine("Onbekende argmuenten");
                        break;
                }
            }
            else
            {
                Console.WriteLine("hello World");
            }

            //0.2
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "Server=192.168.56.121; Port=3306; Database=world; Uid=imma; Pwd=r00t;"

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT Name FROM world.Country";

            con.Open();
        }
    }
}
/* U kan het ook anders doen: Porperties, Debug, evt. "New ..." profiel aanmaken, Application Arguments: -v, opslaan*/