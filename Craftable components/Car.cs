using System.Collections.Generic;
using System.Linq;

namespace MultiplicatoryMegaMakingMachine
{
    class Car : InventoryItem, ICraftable_Items
    {
        public Dictionary<string, int> Requirements { get; set; } = new Dictionary<string, int>
        {
            { "Rubber", 3 },
            { "Steel", 2 },
            { "wheel", 4 }
        };
        public Car() => Name = "Car";


        public bool CanProduce(Dictionary<string, int> sortedinventory)
        {
            bool produceable = true;
            foreach (var item in Requirements)
            {
                
                if (sortedinventory.ContainsKey(item.Key) == false ||sortedinventory[item.Key]  < item.Value)
                {
                    produceable=  false;
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
