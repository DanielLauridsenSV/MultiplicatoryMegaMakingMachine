using System.Collections.Generic;

namespace MultiplicatoryMegaMakingMachine
{
    class MainMethod
    {
        public static void Main(string[] args)
        {
            Storage storage = new();
            Production production = new();
            BlueprintProvider blueprintprovider = new();
            production.SendblueprintsToFactory( blueprintprovider.ProvideBlueprints());

            while (true)
            {
                List<Inventory_Item> chosenRawMaterials = storage.UserPicksMaterials();
                production.SendBlueprintAndMaterialsToFactory(chosenRawMaterials);

                production.DeterminePossibleproducts();
                production.DisplayPossibleProducts();
                production.ProduceGoods();

                List<Inventory_Item> unusedmaterialsandprodukt = production.CollectUnusedMaterialAndProduct();
                storage.AddtoStorage(unusedmaterialsandprodukt);
            }
        }
    }
}

