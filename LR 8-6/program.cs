using System;
using System.Threading;

namespace LR_6
{
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    interface IPackСontingent
    {
        delegate void ReduceQuantityDelegate(object sender, ushort a);
        event ReduceQuantityDelegate ReduceQuantityEvent;

        bool AteRecently { get; set; }

        bool RestRecently { get; set; }

        void printHungry();

        void printTired();

        void Walk();

        ushort quantity { get; set; }

        string Name { get; set; }

        void IsHungry();
        
        void IsTired();

        void RandomSpirits();

        void HaveARest();

        void EatSomeone();
        
        void WhoIsPack();

        void ending();
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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

        public void printHungry()
        {

        }
        public void printTired()
        {
            Console.WriteLine("Someone's battery low..\n");
        }

        public bool AteRecently { get; set; }
        public bool RestRecently { get; set; }
        public void Walk()
        {
            if (quantity != 0)
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
            
            quantity = value;

            this.Name = "drones";

            AteRecently = false;
            RestRecently = false;

            IPackСontingent drones = (IPackСontingent)this;

            drones.ReduceQuantityEvent -= null;

            drones.ReduceQuantityEvent += (Drones, n) =>
            {
                quantity -= n;

                Console.Write("\nFrom lambda event-handler: \"quantity has reduced!\"\n");
            };
        }        

        public ushort quantity { get; set; }

        public string Name { get; set; }

        public void IsHungry() //cant be hungry
        {

        }

        public void IsTired() //only if battery
        {

            if (quantity == 0)
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

                    if (a >= quantity)
                    {
                        //quantity = 0;
                        Console.WriteLine("All of their batteries are low.\nThey fell to the ground...\n");

                        reduceQuantity?.Invoke(this, quantity);
                    }
                    else
                    {
                        //quantity -= a;
                        Console.WriteLine($"There are {a} with low battery.\nRemains {quantity - a} who can continue.");

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
            if (quantity == 0)
            {
                return;
            }

            if (new Random().Next(0, 2) == 1)
            {
                byte a = (byte)new Random().Next(1, 4);
                Console.WriteLine("\n\nElectro-magnetic storm make vzvzvzvvzzzzzzvzvzvzz...\n");
                Thread.Sleep(2000);

                if (a >= quantity)
                {
                    Console.WriteLine($"The remaining {quantity} drones just have made beep-bop and then turned off...\n");

                    reduceQuantity?.Invoke(this, quantity);
                }
                else if (quantity == 1)
                {
                    Console.WriteLine("Your last drone's scanners detect the beep-bop-beep...\n");
                    Thread.Sleep(3000);
                    Console.WriteLine("Last drone just made its last beep-bop and turned off...\n");

                    //quantity = 0;
                    reduceQuantity?.Invoke(this, 1);

                    Thread.Sleep(3000);
                }
                else
                {
                    Console.WriteLine($"{a} drones from your pack just disappeared. Scanners can't detect them...\nRemain {quantity - a} drones.\n");

                    //quantity -= a;
                    reduceQuantity?.Invoke(this, a);
                    Thread.Sleep(3000);
                }
            }
        }

        public void HaveARest() //battery charge
        {

            if (quantity == 0)
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

        public void ending()
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

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    class CarryAble : IPackСontingent //people maybe
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

        public void printHungry()
        {
            Console.WriteLine("Someone hungry..\n");
        }
        public void printTired()
        {
            Console.WriteLine("Someone tired..\n");
        }

        public bool AteRecently { get; set; }
        public bool RestRecently { get; set; }
        public void Walk()
        {
            if (quantity > 0)
            {
                Console.WriteLine("Still walking");
            }
            else
            {
                //Console.WriteLine("No one to go");
                throw new Exception("No one to go");
            }
        }

        public ushort quantity { get; set; }

        public string Name { get; set; }

        public void IsHungry()
        {
            if (quantity == 0)
            {
                //Console.WriteLine("There are no carryables to be hungry...\n");
                throw new Exception("There are no carryables to be hungry...\n");
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

                    if (a >= quantity)
                    {
                        Console.WriteLine("All of them are hungry.\nEveryone sees the light at the end of the tunnel...\n");

                        //quantity = 0; 
                        reduceQuantity?.Invoke(this, quantity);
                    }
                    else
                    {
                        Console.WriteLine($"There are {a} dying of hunger.\nRemains {quantity - a} who can continue.");

                        //quantity -= a;
                        reduceQuantity?.Invoke(this, a);
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
            if (quantity == 0)
            {
                //Console.WriteLine("There are no carryables to be tired...");
                throw new Exception("There are no carryables to be tired...");
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

                    if (a >= quantity)
                    {
                        Console.WriteLine("All of them are tired.\nThey fell to the ground...\n");

                        //quantity = 0;
                        reduceQuantity?.Invoke(this, quantity);
                    }
                    else
                    {
                        Console.WriteLine($"There are {a} dying of tiredness.\nRemains {quantity - a} who can continue.");

                        //quantity -= a;
                        reduceQuantity?.Invoke(this, a);
                    }
                }
                else
                {
                    Console.WriteLine("They dont told to you...\n");
                    RandomSpirits();
                }
            }
        }

        public CarryAble(ushort value = 0)
        {

           quantity = value;

            this.Name = "carryables";
            AteRecently = false;
            RestRecently = false;

            IPackСontingent carryAbles = (IPackСontingent)this;

            carryAbles.ReduceQuantityEvent -= null;

            carryAbles.ReduceQuantityEvent += delegate (object sender, ushort n)
            {
                quantity -= n;

                Console.Write("\nFrom anonymous delegate event-handler: \"quantity has reduced!\"\n");
            };
        }

        public void RandomSpirits()
        {
            if (quantity == 0)
            {
                return;
            }

            if (new Random().Next(0, 2) == 1)
            {
                byte a = (byte)new Random().Next(1, 7);
                if (a >= quantity)
                {

                    Console.WriteLine($"The remaining {quantity} carryables just disappeared...\n");

                    //quantity = 0;
                    reduceQuantity?.Invoke(this, quantity);
                }
                else if (quantity == 1)
                {
                    Console.WriteLine("Your last carryable hears the voices...\n");
                    Thread.Sleep(3000);
                    Console.WriteLine("Last member just disappeared...\n");

                    //quantity = 0
                    reduceQuantity?.Invoke(this, 1);

                    Thread.Sleep(3000);
                }
                else
                {
                    Console.WriteLine($"{a} from your pack just disappeared. Nobody saw them...\nRemain {quantity - a} carryables.\n");

                    //quantity -= a;
                    reduceQuantity?.Invoke(this, a);
                }
            }
        }

        public void HaveARest()
        {
            if (quantity == 0)
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
            if (quantity == 0)
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

            if (a == 1 && quantity == 1)
            {
                Console.WriteLine("You have 1 carryable in your pack...\n");
                Thread.Sleep(3000);
                Console.WriteLine("It cuts off its leg...\n");
                Thread.Sleep(3000);
                Console.WriteLine("Last member just died...\n");

                //quantity = 0;
                reduceQuantity?.Invoke(this, 1);

            }
            else if (a >= quantity)
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

                //quantity = 0;
                reduceQuantity?.Invoke(this, quantity);
            }
            else
            {
                Console.WriteLine("Your pack decided to eat {0} comrades...\n{1} members left", a, quantity - a);

                //quantity -= a;
                reduceQuantity?.Invoke(this, a);
            }
        }

        public void WhoIsPack()
        {
            Console.WriteLine("No matter who, the main thing that they can carry..\n");
        }

        public void ending()
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

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    class smth
    {
        public smth(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    class pack<T>
    {
        public IPackСontingent contingent { get; set; }
        public Type typeOfContingent { get; set; }
        public T staff { get; set; }

        public delegate void CheckTheStaffDelegate(ushort q);
        public CheckTheStaffDelegate checkTheStaffDelegate = delegate(ushort q)
        {
            if (q == 0)
            {
                Console.WriteLine("Staff has been stolen...\n");
            }
            else
            {
                Console.WriteLine("Staff still here.");
            }
        };

        public void CheckStaff(CheckTheStaffDelegate checkTheStaffDelegate)
        {
            checkTheStaffDelegate?.Invoke(contingent.quantity);
        }

        public pack(T staff, IPackСontingent contingent = null)
        {
            this.staff = staff;
            this.contingent = contingent;
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                Random r = new Random();

                pack<smth> Pack = new pack<smth>(new smth("unknown"), new CarryAble(30));

                char a;

                //Console.WriteLine("Quantity of your pack is {0}\n", Pack.contingent.quantity);

                uint turn = 0;

                while (turn < 16)
                {
                    Console.Clear();
                    if (Pack.contingent.quantity != 0)
                    {
                        if (Pack.contingent.AteRecently)
                        {
                            if (r.Next(0, 5) == 0 && Pack.contingent.Name != "drones")
                            {
                                Pack.contingent.AteRecently = false;
                            }
                        }
                        if (Pack.contingent.RestRecently)
                        {
                            if (r.Next(0, 5) == 0)
                            {
                                Pack.contingent.RestRecently = false;
                            }
                        }

                        Console.WriteLine($"{Pack.contingent.quantity} {Pack.contingent.Name} in your pack\nPack's contingent still going over the border with staff...\n\n\n");

                        if (!Pack.contingent.AteRecently && Pack.contingent.Name != "drones")
                        {
                            Pack.contingent.printHungry();
                        }
                        if (!Pack.contingent.RestRecently)
                        {
                            Pack.contingent.printTired();
                        }
                    }


                    Console.WriteLine(
                        "\n\n" +
                        (Pack.contingent.Name != "drones" ? "'h' to check if someone is hungry\n" : "") +
                        "'t' to check if someone if tired\n" +
                        "'k' to just keep walking\n" +
                        "'r' to have a rest\n" +
                        "'e' to eat someone from your pack\n" +
                        "'s' - staff?\n" +
                        "'c' to check the staff\n" +
                        "'w' - who in my pack?\n" +
                        "'n' to change contingent of pack\n\n"
                        );

                    if (!Char.TryParse(Console.ReadLine(), out a))
                    {
                        continue;
                    }

                    Console.Write("\n\n");

                    if (a == 't')
                    {
                        Pack.contingent.IsTired();
                    }
                    else if (a == 'k')
                    {
                        Pack.contingent.Walk();
                        Console.Write("\n");

                        Thread.Sleep(2000);
                        if (!Pack.contingent.AteRecently && Pack.contingent.Name != "drones")
                        {
                            Pack.contingent.printHungry();
                            Thread.Sleep(1000);
                            Pack.contingent.RandomSpirits();
                        }
                        if (!Pack.contingent.RestRecently)
                        {
                            Pack.contingent.printTired();
                            Thread.Sleep(1000);
                            Pack.contingent.RandomSpirits();
                        }

                        Thread.Sleep(2000);

                        turn++;
                    }
                    else if (a == 'r')
                    {
                        Pack.contingent.HaveARest();
                        Pack.contingent.RestRecently = true;
                    }
                    else if (a == 'e')
                    {
                        Pack.contingent.EatSomeone();
                        Pack.contingent.AteRecently = true;
                    }
                    else if (a == 'w')
                    {
                        Pack.contingent.WhoIsPack();
                    }
                    else if (a == 'c')
                    {
                        Pack.CheckStaff(Pack.checkTheStaffDelegate);
                    }
                    else if (a == 's')
                    {
                        Console.WriteLine($"\"{Pack.staff.Name}\" - you can hear..\n");
                    }
                    else if (a == 'n')
                    {
                        Console.WriteLine($"All of {Pack.contingent.Name} prey to God of interfaces for transforming...");

                        if (Pack.contingent.Name == "carryables")
                        {
                            Pack.contingent = new Drones((ushort)(Pack.contingent.quantity / 2));
                        }
                        else //if (Pack.contingent.Name == "drones")
                        {
                            Pack.contingent = new CarryAble((ushort)(Pack.contingent.quantity * 2));
                        }

                        Thread.Sleep(2000);
                        Console.WriteLine("Transformation...");
                        Thread.Sleep(2000);
                        Console.WriteLine($"Now it {Pack.contingent.Name}!");
                        Thread.Sleep(2000);
                        Console.WriteLine("Praise the interfaces!\n");
                    }
                    else if (Pack.contingent.Name != "drones" && a == 'h')
                    {
                        Pack.contingent.IsHungry();
                    }
                    else
                    {
                        Console.WriteLine("Unknown decision...\n");
                        Pack.contingent.RandomSpirits();
                    }

                    if (Pack.contingent.quantity == 0)
                    {
                        Console.WriteLine("\n\nGAME OVER...\n\n");
                        return;
                    }

                    Thread.Sleep(5000);
                }            

                Pack.contingent.quantity = 0;
                Pack.contingent.ending();

                while (true)
                {
                    Console.Clear();

                    Console.WriteLine(
                        "'h' to check if someone is hungry\n" +
                        "'t' to check if someone if tired\n" +
                        "'k' to just keep walking\n" +
                        "'r' to have a rest\n" +
                        "'e' to eat someone from your pack\n" +
                        "'s' - staff?\n" +
                        "'c' to check the staff\n" +
                        "'w' - who in my pack?\n" +
                        "'n' to change contingent of pack\n\n"
                        , Pack.contingent.quantity);

                    Char.TryParse(Console.ReadLine(), out a);

                    try
                    {
                        switch (a)
                        {
                            case ('h'):
                                {
                                    Pack.contingent.IsHungry();
                                    break;
                                }
                            case ('t'):
                                {
                                    Pack.contingent.IsTired();
                                    break;
                                }
                            case ('k'):
                                {
                                    Pack.contingent.Walk();

                                    break;
                                }
                            case ('r'):
                                {
                                    Pack.contingent.HaveARest();
                                    break;
                                }
                            case ('e'):
                                {
                                    Pack.contingent.EatSomeone();
                                    break;
                                }
                            case ('w'):
                                {
                                    Console.WriteLine("No members in pack..\n");
                                    break;
                                }
                            case ('c'):
                                {
                                    Pack.CheckStaff(Pack.checkTheStaffDelegate);
                                    break;
                                }
                            case ('s'):
                                {
                                    Console.WriteLine("staff?...\n");
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
                                    //Pack.contingent.RandomSpirits();
                                    break;
                                }
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception!\n" + ex.Message + " //0 members in pack so it wrong to execute methods that change(decrease) the unsigned quantity, right?");
                        Thread.Sleep(3000);
                    }
                    Thread.Sleep(3000);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
