using System;
using System.Threading;

namespace LR_6
{
    class Program
    {
        static void Main()
        {
            Pack<Smth> pack = new Pack<Smth>(new Smth("unknown"), new CarryAbles(30));         

            char a;

            uint turn = 0;

            while (turn < 16)
            {
                Console.Clear();
                if (pack.Contingent.Quantity != 0)
                {
                    if (pack.Contingent.AteRecently)
                    {
                        if (new Random().Next(0, 5) == 0 && pack.Contingent.Name != "drones")
                        {
                            pack.Contingent.AteRecently = false;
                        }
                    }
                    if (pack.Contingent.RestRecently)
                    {
                        if (new Random().Next(0, 5) == 0)
                        {
                            pack.Contingent.RestRecently = false;
                        }
                    }

                    Console.WriteLine($"{pack.Contingent.Quantity} {pack.Contingent.Name} in your pack\npack's Contingent still going over the border with Staff...\n\n\n");

                    if (!pack.Contingent.AteRecently && pack.Contingent.Name != "drones")
                    {
                        pack.Contingent.PrintHungry();
                    }
                    if (!pack.Contingent.RestRecently)
                    {
                        pack.Contingent.PrintTired();
                    }
                }


                Console.WriteLine(
                    "\n\n'h' to check if someone is hungry\n" +
                    "'t' to check if someone if tired\n" +
                    "'k' to just keep walking\n" +
                    "'r' to have a rest\n" +
                    "'e' to eat someone from your pack\n" +
                    "'s' - Staff?\n" +
                    "'c' to check the Staff\n" +
                    "'w' - who in my pack?\n" +
                    "'n' to change Contingent of pack\n\n"
                    ) ;

                Char.TryParse(Console.ReadLine(), out a);

                Console.Write("\n\n");

                switch (a)
                {
                    case ('h'):
                        {
                            pack.Contingent.IsHungry();
                            break;
                        }
                    case ('t'):
                        {
                            pack.Contingent.IsTired();
                            break;
                        }
                    case ('k'):
                        {
                            pack.Contingent.Walk();
                            Console.Write("\n");

                            Thread.Sleep(2000);
                            if (!pack.Contingent.AteRecently && pack.Contingent.Name != "drones")
                            {
                                pack.Contingent.PrintHungry();
                                Thread.Sleep(1000);
                                pack.Contingent.RandomSpirits();
                            }
                            if (!pack.Contingent.RestRecently)
                            {
                                pack.Contingent.PrintTired();
                                Thread.Sleep(1000);
                                pack.Contingent.RandomSpirits();
                            }

                            Thread.Sleep(2000);

                            turn++;
                            break;
                        }
                    case ('r'):
                        {
                            pack.Contingent.HaveARest();
                            pack.Contingent.RestRecently = true;
                            break;
                        }
                    case ('e'):
                        {
                            pack.Contingent.EatSomeone();
                            pack.Contingent.AteRecently = true;
                            break;
                        }
                    case ('w'):
                        {
                            pack.Contingent.WhoIspack();
                            break;
                        }
                    case ('c'):
                        {
                            pack.CheckStaff();
                            break;
                        }
                    case ('s'):
                        {
                            Console.WriteLine($"\"{pack.Staff.Name}\" - you can hear..\n");
                            break;
                        }
                    case ('n'):
                        {
                            Console.WriteLine($"All of {pack.Contingent.Name} prey to God of interfaces for transforming...");

                            if (pack.Contingent.Name == "CarryAbless")
                            {                              
                                pack.Contingent = new Drones(pack.Contingent.Quantity/2);                          
                            }
                            else //if (pack.Contingent.Name == "drones")
                            {                                
                                pack.Contingent = new CarryAbles(pack.Contingent.Quantity*2);
                            }
                            

                            Thread.Sleep(2000);
                            Console.WriteLine("Transformation...");
                            Thread.Sleep(2000);
                            Console.WriteLine($"Now it {pack.Contingent.Name}!");
                            Thread.Sleep(2000);
                            Console.WriteLine("Praise the interfaces!\n");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Unknown decision...\n");
                            pack.Contingent.RandomSpirits();
                            break;
                        }
                }
                Thread.Sleep(5000);

                if (pack.Contingent.Quantity == 0)
                {
                    Console.WriteLine("\n\nGAME OVER...\n\n");
                    return;
                }
            }

            pack.Contingent.Quantity = 0;
            pack.Contingent.Ending();

            while (true)
            {
                Console.Clear();

                Console.WriteLine(
                    "\n\n'h' to check if someone is hungry\n" +
                    "'t' to check if someone if tired\n" +
                    "'k' to just keep walking\n" +
                    "'r' to have a rest\n" +
                    "'e' to eat someone from your pack\n" +
                    "'s' - Staff?\n" +
                    "'c' to check the Staff\n" +
                    "'w' - who in my pack?\n" +
                    "'n' to change Contingent of pack\n\n"
                    );

                Char.TryParse(Console.ReadLine(), out a);

                switch (a)
                {
                    case ('h'):
                        {
                            pack.Contingent.IsHungry();
                            break;
                        }
                    case ('t'):
                        {
                            pack.Contingent.IsTired();
                            break;
                        }
                    case ('k'):
                        {
                            pack.Contingent.Walk();

                            break;
                        }
                    case ('r'):
                        {
                            pack.Contingent.HaveARest() ;
                            break;
                        }
                    case ('e'):
                        {
                            pack.Contingent.EatSomeone();
                            break;
                        }
                    case ('w'):
                        {
                            Console.WriteLine("No members in pack..\n");
                            break;
                        }
                    case ('c'):
                        {
                            pack.CheckStaff();
                            break;
                        }
                    case ('s'):
                        {
                            Console.WriteLine("Staff?...\n");
                            break;
                        }
                    case ('n'):
                        {
                            Console.WriteLine("There is no pack to transform...\n");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Unknown decision...\n");
                            //pack.Contingent.RandomSpirits();
                            break;
                        }
                }
                Thread.Sleep(5000);
            }
        }
    }
}
