﻿using System.Collections.Generic;

namespace MultiplicatoryMegaMakingMachine
{
    class Wheel : Inventory_Item, ICraftable_Items
    {
        public  int Requiredsteel { get; } = 3;
        public  int Requiredrubber { get; } = 2;
        public  int Requiredwheels { get; } = 0;
        public Wheel() => Name = "Wheel";
        public bool CanProduce(int providedrubber, int providedsteel, int providedwheels)
        {
            if (providedrubber >= Requiredrubber && providedsteel >= Requiredsteel && providedwheels >= Requiredwheels)
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