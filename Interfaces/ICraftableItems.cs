using System.Collections.Generic;

namespace MultiplicatoryMegaMakingMachine
{
   public interface ICraftable_Items:IItems
    {
        public  Dictionary<string, int> Requirements { get; set; }

        public bool CanProduce(Dictionary<string,int> sortedinventory);
        public List<IItems> RemoveUsedMaterials(List<IItems> providedmaterials);
    }
}
