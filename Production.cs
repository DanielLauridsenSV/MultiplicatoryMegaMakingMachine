using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiplicatoryMegaMakingMachine
{
    public class Production
    {
        private List<Inventory_Item> ProvidedMaterials { get; set; }
        private List<ICraftable_Items> blueprints { get; set; }
        private List<ICraftable_Items> Produceableproducts { get; set; }
        public Production()
        {
            ProvidedMaterials = new();
            blueprints = new();
            Produceableproducts = new();
        }

        public void DeterminePossibleproducts()
        {
            Produceableproducts.Clear();

            foreach (var blueprint in blueprints)
            {
                if (blueprint.CanProduce(
                  ProvidedMaterials.FindAll(x => x.GetType() == typeof(Rubber)).Count,
                  ProvidedMaterials.FindAll(x => x.GetType() == typeof(Steel)).Count,
                  ProvidedMaterials.FindAll(x => x.GetType() == typeof(Wheel)).Count)
                  )
                {
                    Produceableproducts.Add(blueprint);
                }
            }
        }
        public void DisplayPossibleProducts()
        {
            Console.Clear();
            Console.WriteLine("you can create the following items\n");
            Produceableproducts = Produceableproducts.OrderBy(X => X.Name).ToList();
            for (int i = 0; i < Produceableproducts.Count; i++)
            {
                Console.WriteLine($"* {Produceableproducts[i].Name,-5}");
            }
        }
        public void Produce()
        {
            Console.WriteLine("\nchose the product you want to create\n");

            while (true)
            {
                ICraftable_Items product = ParseICraftable_Item();
                if (Produceableproducts.Contains(product))
                {
                    ProvidedMaterials.Add((Inventory_Item)product);
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
                if (Produceableproducts.Find(X => X.Name.ToLower() == choice).Name.ToLower() == choice)
                {
                    return Produceableproducts.Find(X => X.Name.ToLower() == choice);
                }
                Console.WriteLine("you have not chosen a valid material, try again");
            }
        }
        public void SendBlueprintAndMaterialsToFactory(List<Inventory_Item> materialsfromstorage) => ProvidedMaterials = materialsfromstorage;
        public void SendBlueprintsToFactory(List<ICraftable_Items>blueprintsList)=> blueprints = blueprintsList;
        public List<Inventory_Item> CollectUnusedMaterialAndProduct() => ProvidedMaterials;
    }
}


