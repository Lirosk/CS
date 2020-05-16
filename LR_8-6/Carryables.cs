using System;
using System.Threading;

namespace LR_8
{
    class Carryables : IPackСontingent //people maybe
    {
        public void PrintHungry()
        {
            Console.WriteLine("Someone hungry..\n");
        }
        public void PrintTired()
        {
            Console.WriteLine("Someone tired..\n");
        }

        public bool AteRecently { get; set; }
        public bool RestRecently { get; set; }
        public void Walk()
        {
            if (Quantity > 0)
            {
                Console.WriteLine("Still walking");
            }
            else
            {
                //Console.WriteLine("No one to go");
                throw new Exception("No one to go");
            }
        }

        public ushort Quantity { get; set; }

        public string Name { get; set; }

        public void IsHungry()
        {
            if (Quantity == 0)
            {
                //Console.WriteLine("There are no CarryAbless to be hungry...\n");
                throw new Exception("There are no CarryAbless to be hungry...\n");
            }
            else if (AteRecently)
            {
                Console.WriteLine("There are no dreams about food now.");//("Everybody feels fine");
            }
            else
            {
                if (new Random().Next(0, 4) != 0)
                {
                    byte a = (byte)new Random().Next(1, 11);

                    if (a >= Quantity)
                    {
                        Console.WriteLine("All of them are hungry.\nEveryone sees the light at the end of the tunnel...\n");

                        Quantity = 0; 
                        //reduceQuantity?.Invoke(this, Quantity);
                    }
                    else
                    {
                        Console.WriteLine($"There are {a} dying of hunger.\nRemains {Quantity - a} who can continue.");

                        Quantity -= a;
                        //reduceQuantity?.Invoke(this, a);
                    }
                }
                else
                {
                    Console.WriteLine("They don't told to you...\n");
                    RandomSpirits();
                }
            }
        }

        public void IsTired()
        {
            if (Quantity == 0)
            {
                //Console.WriteLine("There are no CarryAbless to be tired...");
                throw new Exception("There are no CarryAbless to be tired...");
            }
            else if (RestRecently)
            {
                Console.WriteLine("There are no dreams about having a rest.");//("Everybody feels fine");
            }
            else
            {
                if (new Random().Next(0, 4) != 0)
                {
                    byte a = (byte)new Random().Next(1, 11);

                    if (a >= Quantity)
                    {
                        Console.WriteLine("All of them are tired.\nThey fell to the ground...\n");

                        Quantity = 0;
                        //reduceQuantity?.Invoke(this, Quantity);
                    }
                    else
                    {
                        Console.WriteLine($"There are {a} dying of tiredness.\nRemains {Quantity - a} who can continue.");

                        Quantity -= a;
                        //reduceQuantity?.Invoke(this, a);
                    }
                }
                else
                {
                    Console.WriteLine("They dont told to you...\n");
                    RandomSpirits();
                }
            }
        }

        public Carryables(ushort value = 0)
        {

            Quantity = value;

            this.Name = "Carryables";
            AteRecently = false;
            RestRecently = false;

            
        }

        public void RandomSpirits()
        {
            if (Quantity == 0)
            {
                return;
            }

            if (new Random().Next(0, 2) == 1)
            {
                byte a = (byte)new Random().Next(1, 7);
                if (a >= Quantity)
                {

                    Console.WriteLine($"The remaining {Quantity} CarryAbless just disappeared...\n");

                    Quantity = 0;
                    //reduceQuantity?.Invoke(this, Quantity);
                }
                else if (Quantity == 1)
                {
                    Console.WriteLine("Your last CarryAbles hears the voices...\n");
                    Thread.Sleep(3000);
                    Console.WriteLine("Last member just disappeared...\n");

                    Quantity = 0;
                    //reduceQuantity?.Invoke(this, 1);

                    Thread.Sleep(3000);
                }
                else
                {
                    Console.WriteLine($"{a} from your pack just disappeared. Nobody saw them...\nRemain {Quantity - a} CarryAbless.\n");

                    Quantity -= a;
                    //reduceQuantity?.Invoke(this, a);
                }
            }
        }

        public void HaveARest()
        {
            if (Quantity == 0)
            {
                //Console.WriteLine("There is no one to rest...\n");
                throw new Exception("There is no one to rest...\n");
            }
            else if (RestRecently)
            {
                Console.WriteLine("There are no dreams about food having a rest.");//("Everybody feels fine");
                return;
            }


            Console.WriteLine("Your pack having a rest...");
            Thread.Sleep(3000);
            Console.WriteLine("They are glad that they can sleep...");
            Thread.Sleep(3000);
            RandomSpirits();
        }

        public void EatSomeone()
        {
            if (Quantity == 0)
            {
                //Console.WriteLine("There is no one to eat...\n");
                throw new Exception("There is no one to eat...\n");
            }
            else if (AteRecently)
            {
                Console.WriteLine("There are no dreams about food now.");//("Everybody feels fine");
                return;
            }
            byte a = (byte)new Random().Next(1, 4);

            if (a == 1 && Quantity == 1)
            {
                Console.WriteLine("You have 1 CarryAbles in your pack...\n");
                Thread.Sleep(3000);
                Console.WriteLine("It cuts off its leg...\n");
                Thread.Sleep(3000);
                Console.WriteLine("Last member just died...\n");

                Quantity = 0;
                //reduceQuantity?.Invoke(this, 1);

            }
            else if (a >= Quantity)
            {
                Console.WriteLine("The fight began for a decision who will be eaten...\n");
                Thread.Sleep(3000);
                Console.WriteLine("Everyone want to live...\n");
                Thread.Sleep(3000);
                Console.WriteLine("But injuries incompatible with life...\n");
                Thread.Sleep(3000);
                Console.WriteLine("Your pack just died...\n");
                Thread.Sleep(3000);
                Console.WriteLine("Their bodies will remain here for a while...");
                Thread.Sleep(3000);

                Quantity = 0;
                //reduceQuantity?.Invoke(this, Quantity);
            }
            else
            {
                Console.WriteLine("Your pack decided to eat {0} comrades...\n{1} members left", a, Quantity - a);

                Quantity -= a;
                //reduceQuantity?.Invoke(this, a);
            }
        }

        public void WhoIsPack()
        {
            Console.WriteLine("No matter who, the main thing that they can carry..\n");
        }

        public void Ending()
        {
            Console.Clear();
            Console.WriteLine("Your pack has crossed the border...\n");
            Thread.Sleep(3000);
            Console.WriteLine("They see people on the horizon...\n");
            Thread.Sleep(3000);
            Console.WriteLine("Silence...\n");
            Thread.Sleep(3000);
            Console.WriteLine("Shots...\n");
            Thread.Sleep(5000);
        }
    }
}
