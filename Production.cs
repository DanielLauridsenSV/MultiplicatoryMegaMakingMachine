using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiplicatoryMegaMakingMachine
{
    public class Production
    {
        private List<IItems> ProvidedMaterials { get; set; }
        private Dictionary<string, int> SortedMaterials { get; set; }
        private List<ICraftable_Items> ProduceableProducts { get; set; }
        private List<ICraftable_Items> Blueprints { get; set; }

        public Production()
        {
            ProvidedMaterials = new();
            Blueprints = new();
            ProduceableProducts = new();
            SortedMaterials = new();
        }

        private void Sortinventory()
        {
            SortedMaterials.Clear();
            for (int i = 0; i < ProvidedMaterials.Count; i++)
            {
                if (SortedMaterials.ContainsKey(ProvidedMaterials[i].Name) == false)
                {
                    SortedMaterials.Add(
                    ProvidedMaterials[i].Name,
                    ProvidedMaterials.FindAll(x => x.Name == ProvidedMaterials[i].Name).Count);
                }
            }
        }
        public void DeterminePossibleProducts()
        {
            ProduceableProducts.Clear();
            Sortinventory();
            foreach (var blueprint in Blueprints)
            {
                if (blueprint.CanProduce(SortedMaterials))
                {
                    ProduceableProducts.Add(blueprint);
                }
            }

        }
        public void DisplayPossibleProducts()
        {
            Console.Clear();
            ProduceableProducts = ProduceableProducts.OrderBy(X => X.Name).ToList();

            Console.WriteLine("you can create the following items\n");
            for (int i = 0; i < ProduceableProducts.Count; i++)
            {
                Console.WriteLine($"* {ProduceableProducts[i].Name,-5}");
            }
        }
        public void Produce()
        {
            Console.WriteLine("\nchose the product you want to create\n");

            while (true)
            {
                ICraftable_Items product = ParseICraftable_Item();
                if (ProduceableProducts.Contains(product))
                {
                    ProvidedMaterials.Add(product);
                    ProvidedMaterials = product.RemoveUsedMaterials(ProvidedMaterials);
                    break;
                }
                else
                { Console.WriteLine("you do not have enough material for that products, try again"); }
            }
        }
        private ICraftable_Items ParseICraftable_Item()
        {
            while (true)
            {
                string choice = Console.ReadLine();
                if (ProduceableProducts.Any(X => X.Name.Equals(choice,StringComparison.OrdinalIgnoreCase)))
                {
                    return ProduceableProducts.Find(X => X.Name.ToLower() == choice);
                }
                Console.WriteLine("you have not chosen a valid material, try again");
            }
        }
        public void SendMaterialsToFactory(List<IItems> materialsfromstorage) => ProvidedMaterials = materialsfromstorage;
        public void SendBlueprintsToFactory(List<ICraftable_Items> blueprintsList) => Blueprints = blueprintsList;
        public List<IItems> CollectUnusedMaterialAndProduct() => ProvidedMaterials;
    }
}


