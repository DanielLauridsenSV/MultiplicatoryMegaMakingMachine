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
                List<Inventory_Item> chosenRawMaterials = storage.UserPicksMaterials();
                production.SendMaterialsToFactory(chosenRawMaterials);

                production.DeterminePossibleproducts();
                production.DisplayPossibleProducts();
                production.ProduceGoods();

                List<Inventory_Item> unusedmaterialsandprodukt = production.CollectUnusedMaterialAndProduct();
                storage.AddtoStorage(unusedmaterialsandprodukt);

            }
        }
    }
}

