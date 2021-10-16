using System.Collections.Generic;


namespace MultiplicatoryMegaMakingMachine
{
    class Toaster : InventoryItem, ICraftable_Items
    {
        public  int Requiredsteel { get; } = 2;
        public  int Requiredrubber { get; } = 1;
        public  int Requiredwheels { get; } = 0;
        public Toaster() => Name = "Toaster";
        public bool CanProduce(int providedrubber, int providedsteel, int providedwheels)
        {
            bool enoughRubber = providedrubber >= Requiredrubber;
            bool enoughsteel = providedsteel >= Requiredsteel;
            bool enoughwheels = providedwheels >= Requiredwheels;

            if (enoughRubber && enoughsteel && enoughwheels)
            { return true; }
            else
            { return false; }
        }

        public List<IItems> RemoveUsedMaterials(List<IItems> providedmaterials)
        {
            for (int i = 0; i < Requiredrubber; i++)
            { providedmaterials.Remove(providedmaterials.Find(x => x.GetType() == typeof(Rubber))); }

            for (int i = 0; i < Requiredsteel; i++)
            { providedmaterials.Remove(providedmaterials.Find(x => x.GetType() == typeof(Steel))); }

            for (int i = 0; i < Requiredwheels; i++)
            { providedmaterials.Remove(providedmaterials.Find(x => x.GetType() == typeof(Wheel))); }

            return providedmaterials;
        }
    }
}

