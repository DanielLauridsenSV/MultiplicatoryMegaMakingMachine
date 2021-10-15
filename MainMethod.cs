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

            List<Inventory_Item> chosenRawMaterials = new();
            List<Inventory_Item> unusedmaterialsandprodukt = new();

            while (true)
            {
                storage.PopulateItemsinstorage();
                chosenRawMaterials = storage.UserPicksMaterials();

                production.Getmaterials(chosenRawMaterials);
                production.Discernavailableproducts();
                production.DisplayPossibleProducts();
                production.ProduceGoods();

                unusedmaterialsandprodukt = production.CollectUnusedMaterialAndProduct();
                storage.AddtoStorage(unusedmaterialsandprodukt);

            }
        }
    }
}

