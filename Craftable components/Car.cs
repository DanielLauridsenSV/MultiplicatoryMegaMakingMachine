using System.Collections.Generic;
using System.Linq;

namespace MultiplicatoryMegaMakingMachine
{
    class Car : InventoryItem, ICraftable_Items
    {
        public static int Requiredsteel { get; } = 3;
        public static int Requiredrubber { get; } = 2;
        public static int Requiredwheels { get; } = 4;
        public Car() => Name = "Car";

        public bool CanProduce(int providedrubber, int providedsteel, int providedwheels)
        {
          return  providedsteel >= Requiredsteel && providedrubber >= Requiredrubber && providedwheels >= Requiredwheels;
        }
         
        public List<IItems> RemoveUsedMaterials(List<IItems> providedmaterials)
        {
            for (int i = 0; i < Requiredrubber; i++)
            { providedmaterials.Remove(providedmaterials.Find(x => x.GetType() == typeof(Rubber))); }

            for (int i = 0; i < Requiredsteel; i++)
            { providedmaterials.Remove(providedmaterials.Find(x => x.GetType() == typeof(Steel))); }

            for (int i = 0; i < Requiredwheels; i++)
            {providedmaterials.Remove(providedmaterials.Find(x => x.GetType() == typeof(Wheel))); }

            return providedmaterials;
        }
    }
}
