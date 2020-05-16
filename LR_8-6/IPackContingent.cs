namespace LR_8
{
    interface IPackСontingent
    {
        bool AteRecently { get; set; }

        bool RestRecently { get; set; }

        void PrintHungry();

        void PrintTired();

        void Walk();

        ushort Quantity { get; set; }

        string Name { get; set; }

        void IsHungry();
        void IsTired();

        void RandomSpirits();

        void HaveARest();

        void EatSomeone();
        void WhoIsPack();

        void Ending();

        void ReduceQuantity(ushort n);
    }
}
