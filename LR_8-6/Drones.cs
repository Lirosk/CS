using System;
using System.Threading;

namespace LR_8
{
    class Drones : IPackСontingent //it could be the drones...
    {
        public delegate void ReduceQuantityDelegate(object sender, ushort arg);
        event IPackСontingent.ReduceQuantityDelegate reduceQuantity;

        event IPackСontingent.ReduceQuantityDelegate IPackСontingent.ReduceQuantityEvent
        {
            add
            {
                reduceQuantity += value;
            }

            remove
            {
                reduceQuantity = null;
            }
        }

        public void PrintHungry()
        {

        }
        public void PrintTired()
        {
            Console.WriteLine("Someone's battery low..\n");
        }

        public bool AteRecently { get; set; }
        public bool RestRecently { get; set; }
        public void Walk()
        {
            if (Quantity != 0)
            {
                Console.WriteLine("Drones are flying.\nWzzzuuuuuuhh in the wind..\n");
            }
            else
            {
                throw new Exception("No drones to fly");
            }
        }

        public Drones(ushort value = 0)
        {

            Quantity = value;

            this.Name = "drones";

            AteRecently = false;
            RestRecently = false;

            IPackСontingent drones = (IPackСontingent)this;

            drones.ReduceQuantityEvent -= null;

            drones.ReduceQuantityEvent += (Drones, n) =>
            {
                Quantity -= n;

                Console.Write("\nFrom lambda event-handler: \"Quantity has reduced!\"\n");
            };
        }



        public ushort Quantity { get; set; }

        public string Name { get; set; }

        public void IsHungry() //cant be hungry
        {

        }

        public void IsTired() //only if battery
        {

            if (Quantity == 0)
            {
                //Console.WriteLine("There are no drones to be need for battery charge...");
                throw new Exception("There are no drones to be need for battery charge...");
            }
            else if (RestRecently)
            {
                Console.WriteLine("Batteries are full.");//("Everybody feels fine");
            }
            else
            {
                if (new Random().Next(0, 4) != 0)
                {
                    byte a = (byte)new Random().Next(1, 6);

                    if (a >= Quantity)
                    {
                        //Quantity = 0;
                        Console.WriteLine("All of their batteries are low.\nThey fell to the ground...\n");

                        reduceQuantity?.Invoke(this, Quantity);
                    }
                    else
                    {
                        //Quantity -= a;
                        Console.WriteLine($"There are {a} with low battery.\nRemains {Quantity - a} who can continue.");

                        reduceQuantity?.Invoke(this, a);
                    }
                }
                else
                {
                    Console.WriteLine("They told beep-bop to you, but you don't understand beep-bop...\n");
                    RandomSpirits();
                }
            }
        }

        public void RandomSpirits() //spirits?
        {
            if (Quantity == 0)
            {
                return;
            }

            if (new Random().Next(0, 2) == 1)
            {
                byte a = (byte)new Random().Next(1, 4);
                Console.WriteLine("\n\nElectro-magnetic storm make vzvzvzvvzzzzzzvzvzvzz...\n");
                Thread.Sleep(2000);

                if (a >= Quantity)
                {
                    Console.WriteLine($"The remaining {Quantity} drones just have made beep-bop and then turned off...\n");

                    reduceQuantity?.Invoke(this, Quantity);
                }
                else if (Quantity == 1)
                {
                    Console.WriteLine("Your last drone's scanners detect the beep-bop-beep...\n");
                    Thread.Sleep(3000);
                    Console.WriteLine("Last drone just made its last beep-bop and turned off...\n");

                    //Quantity = 0;
                    reduceQuantity?.Invoke(this, 1);

                    Thread.Sleep(3000);
                }
                else
                {
                    Console.WriteLine($"{a} drones from your pack just disappeared. Scanners can't detect them...\nRemain {Quantity - a} drones.\n");

                    //Quantity -= a;
                    reduceQuantity?.Invoke(this, a);
                    Thread.Sleep(3000);
                }
            }
        }

        public void HaveARest() //battery charge
        {

            if (Quantity == 0)
            {
                //Console.WriteLine("There is no drones for battery charge...\n");
                throw new Exception("There is no drones for battery charge...\n");
            }
            else if (RestRecently)
            {
                Console.WriteLine("All of batteries are full.");//("Everybody feels fine");
                return;
            }

            Console.WriteLine("Drones make beep-bop and charging their batteries...");
            Thread.Sleep(3000);
            Console.WriteLine("They are \"bop-beep\" that they can charge batteries...");
            Thread.Sleep(3000);
            RandomSpirits();
        }

        public void EatSomeone() //battery charge?
        {
            //Console.WriteLine("Drones can't eat each other... Drones can't even eat...\n");
            throw new Exception("Drones can't eat each other... Drones can't even eat...\n");
        }

        public void WhoIsPack()
        {
            Console.WriteLine("Beep-bop?\nDrones!\n");
        }

        public void Ending()
        {
            Console.Clear();
            Console.WriteLine("Your pack has crossed the border...\n");
            Thread.Sleep(3000);
            Console.WriteLine("They see somethings scanners can't detect on the horizon...\n");
            Thread.Sleep(3000);
            Console.WriteLine("Silence...\n");
            Thread.Sleep(3000);
            Console.WriteLine("Electro-magnetic pulse...\n");
            Thread.Sleep(5000);
        }
    }
}
