﻿using System.Collections.Generic;

namespace MultiplicatoryMegaMakingMachine
{
   public interface ICraftable_Items:IItems
    {
        public bool CanProduce(int providedrubber, int providedsteel, int providedwheels);
        public List<IItems> RemoveUsedMaterials(List<IItems> providedmaterials);
    }
}