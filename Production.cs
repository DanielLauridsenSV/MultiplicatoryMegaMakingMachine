using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiplicatoryMegaMakingMachine
{
    public class Production
    {
        private List<Inventory_Item> ProvidedMaterials { get; set; }
        private List<ICraftable_Items> Availableproducts { get; set; }

        public void PopulateAvailableMaterials()
        {
            Car car = new();
            Toaster toaster = new();
            Wheel wheel = new();
            Availableproducts = new();
            Availableproducts.Add(car);
            Availableproducts.Add(toaster);
            Availableproducts.Add(wheel); ;
        }
        public void Getmaterials(List<Inventory_Item> materialsfromstorage)
        {
            ProvidedMaterials = new();
            ProvidedMaterials = materialsfromstorage;
        }

        public List<ICraftable_Items> Discernavailableproducts() 
        {
            List<ICraftable_Items> produceableprodukt = new();
            Console.Clear();
            Console.WriteLine("you can create the following items\n");
            
            for (int i = 0; i < Availableproducts.Count; i++)
            {
                if (Availableproducts[i].CanProduce(
                    ProvidedMaterials.FindAll(x => x.GetType() == typeof(Rubber)).Count,
                    ProvidedMaterials.FindAll(x => x.GetType() == typeof(Steel)).Count,
                    ProvidedMaterials.FindAll(x => x.GetType() == typeof(Wheel)).Count))
                {
                    produceableprodukt.Add(Availableproducts[i]);
                }
            }
            return produceableprodukt;
        }
        public void DisplayPossibleProducts(List<ICraftable_Items> possibleproducts)
        {
            possibleproducts = possibleproducts.OrderBy(X => X.Name).ToList();
            for (int i = 0; i < possibleproducts.Count; i++)
            {
                Console.WriteLine($"* {possibleproducts[i].Name,-5}");
            }
        }
        public void ProduceGoods(List<ICraftable_Items> producableproduct)
        {
           
            Console.WriteLine("\nchose the product you want to create\n");

            while (true)
            {
                ICraftable_Items product = Parsechoice();
                if (producableproduct.Contains(product))
                {
                    ProvidedMaterials.Add((Inventory_Item)product);
                    ProvidedMaterials = product.RemoveUsedMaterials(ProvidedMaterials);
                }
                else
                { Console.WriteLine("you do not have enough material for that products, try again"); }
            }
     
        }
        private ICraftable_Items Parsechoice()
        {
            while (true)
            {
                string choice = Console.ReadLine().ToLower();
                if (Availableproducts.Find(X => X.Name == choice).Name.ToLower() == choice)
                {
                    return Availableproducts.Find(X => X.Name == choice); 
                }

                Console.WriteLine("you have not chosen a valid material, try again");
            }
        }
        public List<Inventory_Item> CollectUnusedMaterialAndProduct() => ProvidedMaterials;
    }
}


