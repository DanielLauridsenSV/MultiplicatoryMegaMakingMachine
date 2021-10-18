using System;
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
                Console.WriteLine(" do you want to create your own item? enter \"yes\" otherwise, press enter to enter the factory");
                if (Console.ReadLine().Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    Workshop workshop = new();
                    SelfCreatedItem item = workshop.CreateItemblueprint();
                    production.SendBlueprintsToFactory(item);
                    Console.Clear();
                }

                List<IItems> chosenRawMaterials = new (storage.UserPicksMaterials());
                production.SendMaterialsToFactory(chosenRawMaterials);

                production.DeterminePossibleProducts();
                production.DisplayPossibleProducts();
                production.Produce();

                List<IItems> unusedmaterialsandprodukt = production.CollectUnusedMaterialAndProduct();
                storage.AddtoStorage(unusedmaterialsandprodukt);
                Console.Clear();
            }
        }
    }
}

