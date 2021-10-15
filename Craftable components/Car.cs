using System.Collections.Generic;

namespace MultiplicatoryMegaMakingMachine
{
    class Car : Inventory_Item, ICraftable_Items
    {
        public static int Requiredsteel { get; } = 3;
        public static int Requiredrubber { get; } = 2;
        public static int Requiredwheels { get; } = 4;
        public Car() => Name = "Car";

        public bool CanProduce(int providedrubber, int providedsteel, int providedwheels)
        {
            bool enoughrubber = providedrubber >= Requiredrubber;
            bool enoughsteel = providedsteel >= Requiredsteel;
            bool enoughwheels = providedwheels >= Requiredwheels;
            if ( enoughrubber&& enoughsteel && enoughwheels )
            { return true; }
            else
            { return false; }
        }
        public List<Inventory_Item> RemoveUsedMaterials(List<Inventory_Item> providedmaterials)
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
