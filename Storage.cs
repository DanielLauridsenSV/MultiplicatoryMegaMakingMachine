using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiplicatoryMegaMakingMachine
{
    public class Storage
    {
        static List<Inventory_Item> MaterialInStorage { get; set; }
        static List<Inventory_Item> MaterialToFactory { get; set; }
        public Storage()
        {
            MaterialInStorage = new();
            MaterialToFactory = new();   
        }
        private void PopulateItemsinstorage()
        {
            Steel steel = new();
            Rubber rubber = new();
            MaterialInStorage.Add(steel);
            MaterialInStorage.Add(steel);
            MaterialInStorage.Add(steel);
            MaterialInStorage.Add(steel);
            MaterialInStorage.Add(rubber);
            MaterialInStorage.Add(rubber);
            MaterialInStorage.Add(rubber);
            MaterialInStorage.Add(rubber);
        }

        public List<Inventory_Item> Userpicksmaterials()
        {
            PopulateItemsinstorage();
            MaterialToFactory.Clear();

            while (true)
            {
                Storageview();
                Inventory_Item choice = ParseMaterial();
                if (MaterialInStorage.Contains(choice))
                {
                    MaterialToFactory.Add(MaterialInStorage.Find(x => x.GetType() == choice.GetType()));
                    MaterialInStorage.Remove(MaterialInStorage.Find(x => x.GetType() == choice.GetType()));
                }
                else
                {
                    Console.WriteLine(" The material you selected does not exist in the inventory");
                }

                Console.WriteLine("\nif you want to proceed to the factory, write \"deliver\", else press enter");
                if (Console.ReadLine().ToLower() == "deliver")
                {break;}
            }
            return MaterialToFactory;
        }
        private Inventory_Item ParseMaterial()
        {
            Console.WriteLine("\nchoose material\n");
            while (true)
            {
                Inventory_Item choice = ParseMaterial();
                if (MaterialInStorage.Contains(choice))
                {
                    return MaterialInStorage.Find(x => x.GetType() == choice.GetType());
                }
                Console.WriteLine("you have not chosen a valid material, try again");
            }
        }
        private void Storageview()
        {
            Console.Clear();
            List<Inventory_Item> displaystorage = new();
            List<Inventory_Item> displaytofactory = new();

            displaystorage.AddRange(MaterialInStorage.OrderBy(x => x.Name));
            displaytofactory.AddRange(MaterialToFactory.OrderBy(x => x.Name));


            Console.WriteLine("items in storage");
            for (int i = 0; i < displaystorage.Count; i++)
            { Console.WriteLine(displaystorage[i].Name); }

            Console.WriteLine("\nThese are the items headed for the factory");
            for (int i = 0; i < displaytofactory.Count; i++)
            { Console.WriteLine(displaytofactory[i].Name); }
        }
        // I know these are bad and can induce unwanted sideeffects, but they are the best I can produce right now.
        public void AddtoStorage(Inventory_Item product) => MaterialInStorage.Add(product);
        public void AddtoStorage(List<Inventory_Item> unusedmaterials) => MaterialInStorage.AddRange(unusedmaterials);

    }

}
