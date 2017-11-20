using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace WorldDbQuerier
{
    class Program
    {
        //private static MySqlConnection con = new MySqlConnection();
        private static string connectieString = "Server=192.168.56.121; Port=3306; Database=world; Uid=imma; Pwd=r00t;"; //zet de database world eerst als "Default Schema" (RM)
        //using om connectie te openen?
        

        private static void ToonAantalLanden()
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = connectieString;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT COUNT(Name) FROM world.Country";

            con.Open();
            Console.WriteLine(cmd.ExecuteScalar());
        }

        //private static void ToonAantalLanden()
        //{
        //    Console.WriteLine(Landen());
        //}

        private static void ToonAlleLanden()
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = connectieString;
            
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT world.Country.Name FROM world.Country";
            //cmd2.ExecuteScalar();//"connection must be opened"

            MySqlDataReader lezer;

            con.Open();
            lezer = cmd.ExecuteReader();

            while (lezer.Read())
            {
                Console.WriteLine(lezer["Name"]); //niet lezer["world.Country.Name"]
            }

        }

        private static void ZoekOpNaamEnPrint()
        {
            string land = Console.ReadLine();
            MySqlDataReader lezer;
            MySqlParameter parameter = new MySqlParameter();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = connectieString;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM World.Country"; //Aanpassen? Ja: "select " + ... + " from World.Country";

            
            con.Open();
            lezer = cmd.ExecuteReader(); //error

            while (lezer.Read())
            {
                if (lezer["Name"].ToString().ToLower() != land.ToLower() || lezer["Code"].ToString().ToLower() != land.ToLower())
                {
                    //...
                    for (int i = 0; i <= 15; i++)
                    {
                        if (i < 15)
                        {
                            Console.WriteLine(lezer[i]/*of met namen werken ipv met indices*/ + " | ");
                        }
                        else
                        {
                            Console.WriteLine(lezer[i]);
                        }
                    }
                    continue;
                }
                else
                {
                    /*land is begin van Country*/
                    //Vergelijk de tekens van lezer["Name"] met die van land/landTekens! Als de tekens overeenkomen (in juiste volgorde!), wordt hetzefde gedaan als hierboven.
                    bool overeengekomenTekens;

                    int i = 0;
                    int j = 0;

                    foreach (char teken in land)
                    {
                        i++;
                    }

                    foreach (char teken in land)
                    {
                        j++;
                    }

                    char[] landTekens = new char[i];
                    char[] landnaamTekens = new char[j];

                    for (int k = 0; k <= i; k++)
                    {
                        int l = k;
                        if (landTekens[k] == landnaamTekens[l])
                        {
                            overeengekomenTekens = true;
                        }
                        else
                        {
                            overeengekomenTekens = false;
                            continue;
                        }
                    }
                }
            }
        }

        //0.1
        //command parser
        private static string versie = "0.3";

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
                        Console.WriteLine("Onbekende argumenten");
                        break;
                }
            }
            else
            {
                Console.WriteLine("hello World");
            }

            //0.3
            Console.WriteLine();
            Console.WriteLine("Kies (vul het cijfer in en druk op Enter):");
            Console.WriteLine("1. Het aantal landen aanwezig in de database afdrukken");
            Console.WriteLine("2. Een lijst met alle landen aanwezig in de database afdrukken");
            Console.WriteLine("3. Zoeken op een (gedeeltelijke) landnaam en alle info erover afdrukken (vul hierna eerst het land in, een deel ervan of de code ervan)");

            switch (Console.ReadLine()) //Console.ReadLine andere opmaak?
            {
                case "1":
                    ToonAantalLanden();
                    break;
                case "2":
                    ToonAlleLanden();
                    break;
                //0.4
                case "3":
                    ZoekOpNaamEnPrint(); //error
                    break;
                default:
                    Console.WriteLine("Error: verkeerde input");
                    break;
            }

            //0.4: af te maken tot hier!!!

        }
    }
}
/* U kan het ook anders doen: Porperties, Debug, evt. "New ..." profiel aanmaken, Application Arguments: -v, opslaan*/