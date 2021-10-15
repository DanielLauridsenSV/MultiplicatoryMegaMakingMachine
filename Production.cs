using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiplicatoryMegaMakingMachine
{
    public class Production
    {
        private List<Inventory_Item> ProvidedMaterials { get; set; }
        private List<ICraftable_Items> Availableproducts { get; set; }
        List<ICraftable_Items> Produceableproducts = new();
        public Production()
        {
            Car car = new();
            Toaster toaster = new();
            Wheel wheel = new();
            Availableproducts = new();
            Availableproducts.Add(car);
            Availableproducts.Add(toaster);
            Availableproducts.Add(wheel);
        }

        public void Getmaterials(List<Inventory_Item> materialsfromstorage)
        {
            ProvidedMaterials = new();
            ProvidedMaterials = materialsfromstorage;
        }

        public void Discernavailableproducts() 
        {
            Produceableproducts.Clear();
            Console.Clear();
            Console.WriteLine("you can create the following items\n");
            
            for (int i = 0; i < Availableproducts.Count; i++)
            {
                if (Availableproducts[i].CanProduce(
                    ProvidedMaterials.FindAll(x => x.GetType() == typeof(Rubber)).Count,
                    ProvidedMaterials.FindAll(x => x.GetType() == typeof(Steel)).Count,
                    ProvidedMaterials.FindAll(x => x.GetType() == typeof(Wheel)).Count))
                {
                    Produceableproducts.Add(Availableproducts[i]);
                }
            }
        }

        public void DisplayPossibleProducts()
        {
            Produceableproducts = Produceableproducts.OrderBy(X => X.Name).ToList();
            for (int i = 0; i < Produceableproducts.Count; i++)
            {
                Console.WriteLine($"* {Produceableproducts[i].Name,-5}");
            }
        }
        public void ProduceGoods()
        {     
            Console.WriteLine("\nchose the product you want to create\n");

            while (true)
            {
                ICraftable_Items product = ParseICraftable_ITem();
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
        private ICraftable_Items ParseICraftable_ITem()
        {
            while (true)
            {
                string choice = Console.ReadLine().ToLower();
                if (Availableproducts.Find(X => X.Name.ToLower() == choice).Name.ToLower() == choice)
                {
                    return Availableproducts.Find(X => X.Name.ToLower() == choice); 
                }

                Console.WriteLine("you have not chosen a valid material, try again");
            }
        }
        public List<Inventory_Item> CollectUnusedMaterialAndProduct() => ProvidedMaterials;
    }
}


