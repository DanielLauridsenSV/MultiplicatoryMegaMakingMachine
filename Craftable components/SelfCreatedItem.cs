using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplicatoryMegaMakingMachine
{
    class SelfCreatedItem : InventoryItem, ICraftable_Items
    {
        public Dictionary<string, int> Requirements { get; set ; }

        public SelfCreatedItem(string name,Dictionary<string,int> givenRequirements)
        {
            Name = name;
            Requirements = givenRequirements;
        }
        public bool CanProduce(Dictionary<string, int> sortedinventory)
        {
            foreach (var item in Requirements)
            {
                if (sortedinventory.ContainsKey(item.Key) == false || sortedinventory[item.Key] < item.Value)
                {
                    return false;
                }
            }
            return true;
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
