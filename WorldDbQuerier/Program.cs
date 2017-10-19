﻿using System;
using MySql.Data.MySqlClient;

namespace WorldDbQuerier
{
    class Program
    {
        private static MySqlConnection con = new MySqlConnection();
        private static string connectieString = "Server=192.168.56.121; Port=3306; Database=world; Uid=imma; Pwd=r00t;"; //zet de database world eerst als "Default Schema" (RM)
        private static string aantalLanden = "SELECT COUNT(Name) FROM world.Country";

        private static void ToonAantalLanden()
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = connectieString; 

            MySqlCommand cmd1 = new MySqlCommand();
            cmd1.Connection = con;
            cmd1.CommandText = aantalLanden;

            con.Open();

            Console.WriteLine("aantal landen: " + cmd1.ExecuteScalar());
        }

        private static void ToonAlleLanden()
        {
            
        }

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
            ToonAantalLanden();

            //0.3
            MySqlCommand cmd2 = new MySqlCommand();

            Console.WriteLine();
            Console.WriteLine("Kies (vul het cijfer in en druk op Enter):");
            Console.WriteLine("1. Het aantal landen aanwezig in de database afdrukken");
            Console.WriteLine("2. Een lijst met alle landen aanwezig in de database afdrukken:");

            cmd2.Connection = con;

            switch (Console.ReadLine())
            {
                case "1":
                    cmd2.CommandText = aantalLanden;
                    break;
                case "2":
                    cmd2.CommandText = "SELECT world.Country.Name FROM world.Country";
                    break;
                default:
                    Console.WriteLine("Error: verkeerde input");
                    break;
            }

            //con.Open();

            Console.WriteLine(cmd2.ExecuteScalar());
        }
    }
}
/* U kan het ook anders doen: Porperties, Debug, evt. "New ..." profiel aanmaken, Application Arguments: -v, opslaan*/