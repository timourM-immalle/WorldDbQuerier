﻿using System;

namespace WorldDbQuerier
{
    class Program
    {
        private static string versie = "0.1";

        static void Main(string[] args)
        {
            //args[0] = Console.ReadLine();

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
        }
    }
}
/* U kan het ook anders doen: Porperties, Debug, ...*/