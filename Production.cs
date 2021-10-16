using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiplicatoryMegaMakingMachine
{
    public class Production
    {
        private List<IItems> ProvidedMaterials { get; set; }
        private List<ICraftable_Items> Blueprints { get; set; }
        private List<ICraftable_Items> ProduceableProducts { get; set; }
        public Production()
        {
            ProvidedMaterials = new();
            Blueprints = new();
            ProduceableProducts = new();
        }

        public void DeterminePossibleproducts()
        {
            ProduceableProducts.Clear();

            foreach (var blueprint in Blueprints)
            {
                if (blueprint.CanProduce(
                  ProvidedMaterials.FindAll(x => x.GetType() == typeof(Rubber)).Count,
                  ProvidedMaterials.FindAll(x => x.GetType() == typeof(Steel)).Count,
                  ProvidedMaterials.FindAll(x => x.GetType() == typeof(Wheel)).Count)
                  )
                {
                    ProduceableProducts.Add(blueprint);
                }
            }
        }
        public void DisplayPossibleProducts()
        {
            Console.Clear();
            Console.WriteLine("you can create the following items\n");
            ProduceableProducts = ProduceableProducts.OrderBy(X => X.Name).ToList();
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
                    ProvidedMaterials.Add((IItems)product);
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
                string choice = Console.ReadLine().ToLower();
                if (ProduceableProducts.Find(X => X.Name.ToLower() == choice).Name.ToLower() == choice)
                {
                    return ProduceableProducts.Find(X => X.Name.ToLower() == choice);
                }
                Console.WriteLine("you have not chosen a valid material, try again");
            }
        }
        public void SendMaterialsToFactory(List<IItems> materialsfromstorage) => ProvidedMaterials = materialsfromstorage;
        public void SendBlueprintsToFactory(List<ICraftable_Items>blueprintsList)=> Blueprints = blueprintsList;
        public List<IItems> CollectUnusedMaterialAndProduct() => ProvidedMaterials;
    }
}


