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
            con.ConnectionString = "Server=192.168.56.121; Port=3306; Database=world; Uid=imma; Pwd=r00t;";

            MySqlCommand cmd1 = new MySqlCommand();
            cmd1.Connection = con;
            cmd1.CommandText = "SELECT COUNT(Name) FROM world.Country";

            con.Open();

            Console.WriteLine("aantal landen: " + cmd1.ExecuteScalar());

            //0.3
            MySqlCommand cmd2 = new MySqlCommand();

            Console.WriteLine("Kies (vul het cijfer in):");
            Console.WriteLine("1. Het aantal landen aanwezig in de database afdrukken");
            Console.WriteLine("2. Een lijst met alle landen aanwezig in de database afdrukken:");

            cmd2.Connection = con;

            if (Console.ReadLine() == "1")
            {
                cmd2.CommandText = cmd1.CommandText;
            }
            else if (Console.ReadLine() == "2")
            {
                cmd2.CommandText = "SELECT Name FROM world.Country";
            }
            else
            {
                Console.WriteLine("Error: verkeerde input");
            }

            

            //con.Open();

            Console.WriteLine(cmd2.ExecuteScalar());
        }
    }
}
/* U kan het ook anders doen: Porperties, Debug, evt. "New ..." profiel aanmaken, Application Arguments: -v, opslaan*/