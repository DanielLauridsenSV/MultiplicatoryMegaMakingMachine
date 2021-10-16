using System.Collections.Generic;

namespace MultiplicatoryMegaMakingMachine
{
    class MainMethod
    {
        public static void Main(string[] args)
        {
            Storage storage = new();
            Production production = new();
            BlueprintProvider blueprintProvider = new();
            List<ICraftable_Items> blueprints = blueprintProvider.ProvideBlueprints();
            production.SendBlueprintsToFactory(blueprints);

            while (true)
            {
                List<IItems> chosenRawMaterials = storage.UserPicksMaterials();
                production.SendMaterialsToFactory(chosenRawMaterials);

                production.DeterminePossibleproducts();
                production.DisplayPossibleProducts();
                production.Produce();

                List<IItems> unusedmaterialsandprodukt = production.CollectUnusedMaterialAndProduct();
                storage.AddtoStorage(unusedmaterialsandprodukt);
            }
        }
    }
}

