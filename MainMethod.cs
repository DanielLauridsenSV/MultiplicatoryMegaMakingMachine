using System;
using System.Collections.Generic;
using MultiplicatoryMegaMakingMachine;

namespace MultiplicatoryMegaMakingMachine
{
    class MainMethod
    {
        public static void Main(string[] args)
        {
            Storage storage = new();
            Production production = new();

            while (true)
            {
                production.PopulateAvailableMaterials();

                List<Inventory_Item> chosenRawMaterials = new();
                chosenRawMaterials.AddRange(storage.Userpicksmaterials());
                production.Getmaterials(chosenRawMaterials);

                List<ICraftable_Items> produceableproducts = production.Discernavailableproducts();
                production.DisplayPossibleProducts(produceableproducts);
                production.ProduceGoods(produceableproducts);
                List<Inventory_Item> unusedmaterialsandprodukt = production.CollectUnusedMaterialAndProduct();
                storage.AddtoStorage(unusedmaterialsandprodukt);

            }
        }
    }
}

