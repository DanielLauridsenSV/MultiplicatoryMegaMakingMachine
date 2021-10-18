using System.Collections.Generic;


namespace MultiplicatoryMegaMakingMachine
{
    class Toaster : InventoryItem, ICraftable_Items
    {
        public static int Requiredsteel { get; } = 3;
        public static int Requiredrubber { get; } = 2;
        public static int Requiredwheels { get; } = 4;
        public Dictionary<string, int> Requirements { get ; set ; } = new Dictionary<string, int>
        { 
            { "Rubber", 1 },
            { "Steel", 2 }, 
        };

        public Toaster() => Name = "Toaster";
        public bool CanProduce(Dictionary<string, int> sortedinventory)
        {
            bool produceable = true;
            foreach (var item in Requirements)
            {

                if (sortedinventory.ContainsKey(item.Key) == false || sortedinventory[item.Key] < item.Value)
                {
                    produceable = false;
                    break;
                }
            }
            return produceable;
        }

        public List<IItems> RemoveUsedMaterials(List<IItems> providedmaterials)
        {
            foreach (var item in Requirements)
            {
                for (int i = 0; i < item.Value; i++)
                {
                    providedmaterials.Remove(providedmaterials.Find(x => x.Name == item.Key));
                }
            }
            return providedmaterials;
        }
    }
}

