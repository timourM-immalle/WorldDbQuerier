using System;

namespace WorldDbQuerier
{
    class Program
    {
        private static string versie = "0.1";

        static void Main(string[] args)
        {
            if (args.Length > 0)
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
        }
    }
}